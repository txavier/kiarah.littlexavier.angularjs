// 'getScript' loads scripts after the page has loaded so the page can render quicker 
function getScript(url, success) {
    var script = document.createElement('script');
    script.type = "text/javascript";
    script.async = true;
    script.src = url;
    var head = document.getElementsByTagName('head')[0],
        done = false;
    script.onload = script.onreadystatechange = function () {
        if (!done && (!this.readyState || this.readyState == 'loaded' || this.readyState == 'complete')) {
            done = true;
            if (typeof success != 'undefined') { success(); }
            script.onload = script.onreadystatechange = null;
            head.removeChild(script);
        }
    };
    head.appendChild(script);
}

// --------------- Query actions --------------- //
getScript('https://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js', function () {
    var pageId = $("#pageId").attr("content");

    // -------- MVC Client Side Validation ---------- //
    getScript('http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js');
    getScript('/scripts/jquery.validate.unobtrusive.min.js');

    // Added fix - If element doesn't exist, then don't bother requesting comments.
    if ($("#commentsContainer").length > 0) {
        getComments();
        window.setInterval(getComments, 10000);
        console.log("initial service load");
    }

    // Loads in the facebook api
    getScript('https://connect.facebook.net/en_US/all.js', function () {
        FB.init({
            appId: '374162762699021',   // App ID from the app dashboard
            status: true,               // Check Facebook Login status
            xfbml: true,                // Look for social plugins on the page
            oauth: true
        });

        // When the facebook button is clicked (if it exists), then login the user
        if ($('#facebookButton').length > 0) {
            $('#facebookButton').click(function (e) {
                e.preventDefault();
                login();
            });
        }

        // The login function to retrieve and set the user details into the form.
        function login() {
            FB.getLoginStatus(function (response) {
                console.log('Welcome!  Fetching your information.... ');
                FB.api('/me', function (response) {
                    console.log('Good to see you, ' + response.name + '.');
                });

                if (response.status === 'connected') {
                    // User is already authorised and logged in
                    FB.api('me?fields=name,email,website', function (user) {
                        if (user != null) {
                            console.log("You've already provided authorisation to this website");
                            $("#commentName").val(user.name);
                            $("#commentEmail").val(user.email);
                            $("#commentWebsite").val(user.website);
                        }
                    });
                } else if (response.status === 'not_authorized') {
                    // The user is logged in but has not authenticated the app
                    console.log("Looks like you've not provided access to this application")
                } else {
                    // The user has not logged into facebook so ask them to
                    FB.login(function (response) {
                        if (response.authResponse) {
                            if (response.authResponse.accessToken) {
                                FB.api('me?fields=name,email,website', function (user) {
                                    if (user != null) {
                                        $("#commentName").val(user.name);
                                        $("#commentEmail").val(user.email)
                                        $("#commentWebsite").val(user.website);
                                    }
                                })
                            }
                        }
                        else {
                            alert("You need to log in and authorise this website before you can autofill the form.");
                        }
                    }, { scope: 'email,user_website' });
                }
            }, true);
        }
    });

    // Retrieve comments from the web service.
    function getComments() {
        console.log("running get comments");
        var strData = "{'intId':'" + pageId + "'}";

        $.ajax({
            type: "POST",
            url: "/WebServices/SmartBlogService.asmx/GetComments",
            data: strData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: loadComments,
            error: OnErrorCall
        });
    }

    // When comments have been retrieved, they're shown on the page
    function loadComments(response) {
        // Clears the comment container (debug only)
        //$("#commentsContainer").html('');

        console.log(response)

        // Counts the items to see if updates are needed
        var count = $("#commentsContainer").children().length;

        // If count differs from ajax json then update comments
        if (response.d.length != count) {
            // Loops through comments in ajax json
            for (x = 0; x < response.d.length; x++) {
                var needsAdding = true;

                // Loops through existing comments
                for (y = 0; y < $("#commentsContainer").children().length; y++) {
                    var needsRemoving = true;

                    // If existing comment does matches against any ajax json comments then it does not need removing
                    for (z = 0; z < response.d.length; z++) {
                        if ($("#commentsContainer").children()[y].id == "c" + response.d[z].intId) {
                            needsRemoving = false;
                        }
                    }

                    // If the existing comment does need removing then remove it
                    if (needsRemoving) {
                        $("#commentsContainer").children().eq(y).hide('fast', function () { $("#commentsContainer").children().eq(y).remove(); });
                    }

                    // If any ajax json comment matches any existing comment then it does not need adding
                    if ($("#commentsContainer").children()[y].id == "c" + response.d[x].intId) {
                        needsAdding = false;
                    }
                }

                // If the ajax json comment needs adding then add it
                if (needsAdding) {
                    // Create the content and element
                    var content = "<div class=\"commentInner\"><div class=\"commentName\">" + response.d[x].strName + "</div><div class=\"commentComment\">" + response.d[x].strComment + "</div><div class=\"commentDate\">" + response.d[x].strDate + "</div></div>";
                    var newComment = $("<div class=\"comment\" id=\"c" + response.d[x].intId + "\"></div>").html(content);

                    // Add the new element to the comment container
                    $("#commentsContainer").append(newComment);

                    // Get the height of the child content and animate hight to match
                    var newCommentHeight = newComment.children().eq(0).outerHeight();
                    newComment.animate({
                        height: newCommentHeight + "px"
                    });
                }
            }
        }
    }

    // Posts the comment to the web service
    function addComment() {
        var strData = "{\"intId\":\"" + pageId + "\", \"strName\":\"" + $("#commentName").val() + "\", \"strWebsite\":\"" + $("#commentWebsite").val() + "\", \"strEmail\":\"" + $("#commentEmail").val() + "\", \"strComment\":\"" + $("#commentComment").val().replace("'", "&apos;") + "\"}";

        $.ajax({
            type: "POST",
            url: "/WebServices/SmartBlogService.asmx/AddComment",
            data: strData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //success: OnSuccessCall,
            error: OnErrorCall
        });

        alert("Your comment has been added.");
    }

    // Handles form submition
    $('#commentForm').submit(function (e) {
        e.preventDefault();
        if ($('#commentForm').valid()) {
            addComment();
            //$('#commentForm')[0].reset();
            //$('#commentForm')[0].hideErrors();
        }
    });

    // Handle search input
    $("#smartSearchInput").on('focus', function () {
        if ($(this).val() == "Search") {
            $(this).val("");
        }
    });
    $("#smartSearchInput").on('focusout', function () {
        if ($(this).val() == "") {
            $(this).val("Search");
        }
    })

    // Listen for search request
    $("#smartSearchButton").on('click', function (e) {
        e.preventDefault();

        doSmartBlogSearch();
    });
    $('#smartBlogSearchForm').on('submit', function (e) {
        e.preventDefault();

        doSmartBlogSearch();
    });

    // Perform search
    function doSmartBlogSearch() {
        var address = document.URL.split('?')[0];
        var query = $("#smartSearchInput").val();

        // If no search term has been requested then alert the user,
        // else perform the search.
        if (query != "") {
            // If on a post, we need to redirect the user up a level too.
            if ($('#postPageBody').length > 0) {
                window.location = address.substr(0, address.lastIndexOf("/")) + "?q=" + query;
            }
            else {
                window.location = address + "?q=" + query;
            }
        }
        else {
            alert("Please provide a search term.")
        }
    }
});

// If any ajax call fails
function OnErrorCall(response) {
    alert(response.status + " " + response.statusText);
    console.log(response)
}