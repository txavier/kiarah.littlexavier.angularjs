
angular
    .module('app', [
        'ngRoute',
        'LocalStorageModule',
        'angular-loading-bar',
        'ngResource',
        //'ui.bootstrap',
        //'ngDroplet',
        //'textAngular',
        //'shared.directives',
        //'ngToast',
        //'nya.bootstrap.select',
    ]);

angular
    .module('app')
    .config(config);

function config($routeProvider, $locationProvider) {
    $routeProvider
        .when('/index', {
            templateUrl: 'index.html',
            controller: 'indexController',
            controllerAs: 'vm'
        })
        .otherwise({ redirectTo: '/' });
}

// Add an escape filter to encode strings for use in url's.
angular
    .module('app')
    .filter('escape', function () {
        return window.encodeURIComponent;
});