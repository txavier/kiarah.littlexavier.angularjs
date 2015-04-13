(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateBlogEntryCommentController', addOrUpdateBlogEntryCommentController);

    addOrUpdateBlogEntryCommentController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateBlogEntryCommentController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.blogEntryComments = [];
        vm.blogEntryComment = {};
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getBlogEntryComment($routeParams.blogEntryCommentId);

            return vm;
        }

        function getBlogEntryComment(blogEntryCommentId) {
            if (!blogEntryCommentId) {
                return;
            }
            return dataService.getEntity('blogEntryComments', blogEntryCommentId).then(function (data) {
                vm.blogEntryComment = data;

                return vm.blogEntryComment;
            });
        }

        function addOrUpdate(blogEntryComment) {
            // If there is a blog entry id in the url then set it to be 
            // this comments parent because this is a comment for that
            // blog entry.
            if ($routeParams.blogEntryId) {
                blogEntryComment.blogEntryId = $routeParams.blogEntryId;
            }
            return dataService.addOrUpdateEntity('blogEntryComments', blogEntryComment)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();