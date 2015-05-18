angular
    .module('app', [
        'ngRoute',
        'LocalStorageModule',
        'angular-loading-bar',
        'ngResource',
        'textAngular'
        //'ui.bootstrap',
        //'ngDroplet',
        //'shared.directives',
        //'ngToast',
        //'nya.bootstrap.select',
    ]);

angular
    .module('app')
    .config(config);

function config($routeProvider, $locationProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: '/app/templates/home.html',
            controller: 'homeController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-blog-entry', {
            templateUrl: '/app/templates/add-or-update-blog-entry.html',
            controller: 'addOrUpdateBlogEntryController',
            controllerAs: 'vm'
        })
        .when('/posts/:year/:month/:blogEntryTitle', {
            templateUrl: '/app/templates/blog-entries.html',
            controller: 'blogEntriesController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-blog-entry-comment/:blogEntryId', {
            templateUrl: '/app/templates/add-or-update-blog-entry-comment.html',
            controller: 'addOrUpdateBlogEntryCommentController',
            controllerAs: 'vm'
        })
        .when('/login', {
            controller: 'loginController',
            templateUrl: '/app/templates/login.html'
        })
        .when('/signup', {
            controller: 'signupController',
            templateUrl: '/app/templates/signup.html'
        })
        .when("/auth-home", {
            controller: 'authHomeController',
            templateUrl: '/app/templates/auth-home.html'
        })
        .when('/statistics/:key', {
            templateUrl: '/app/templates/statistics.html',
            controller: 'statisticsController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-statistic/:key', {
            templateUrl: '/app/templates/add-or-update-statistic.html',
            controller: 'addOrUpdateStatisticController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-statistic/:key/:statisticId', {
            templateUrl: '/app/templates/add-or-update-statistic.html',
            controller: 'addOrUpdateStatisticController',
            controllerAs: 'vm'
        })
         .when('/add-or-update-my-castle', {
             templateUrl: '/app/templates/add-or-update-my-castle.html',
             controller: 'addOrUpdateMyCastleController',
             controllerAs: 'vm'
         })
         .when('/add-or-update-my-castle/:myCastleId', {
             templateUrl: '/app/templates/add-or-update-my-castle.html',
             controller: 'addOrUpdateMyCastleController',
             controllerAs: 'vm'
         })
        .when('/my-castle', {
            templateUrl: '/app/templates/my-castle.html',
            controller: 'myCastleController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-my-journey', {
            templateUrl: '/app/templates/add-or-update-my-journey.html',
            controller: 'addOrUpdateMyJourneyController',
            controllerAs: 'vm'
        })
         .when('/add-or-update-my-journey/:myJourneyId', {
             templateUrl: '/app/templates/add-or-update-my-journey.html',
             controller: 'addOrUpdateMyJourneyController',
             controllerAs: 'vm'
         })
        .when('/my-journey', {
            templateUrl: '/app/templates/my-journey.html',
            controller: 'myJourneyController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-my-family/:myFamilyId', {
            templateUrl: '/app/templates/add-or-update-my-family.html',
            controller: 'addOrUpdateMyFamilyController',
            controllerAs: 'vm'
        })
        .when('/add-or-update-my-family', {
            templateUrl: '/app/templates/add-or-update-my-family.html',
            controller: 'addOrUpdateMyFamilyController',
            controllerAs: 'vm'
        })
        .when('/my-family', {
            templateUrl: '/app/templates/my-families.html',
            controller: 'myFamilyController',
            controllerAs: 'vm'
        })
        .otherwise({ redirectTo: '/home' });

    $locationProvider.html5Mode({
        enabled: false,
        requireBase: false
    });
}

// Add an escape filter to encode strings for use in url's.
angular
    .module('app')
    .filter('escape', function () {
        return window.encodeURIComponent;
    });

angular
    .module('app')
    .run(['authService', function (authService) {
        authService.fillAuthData();
    }]);

angular
    .module('app')
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });