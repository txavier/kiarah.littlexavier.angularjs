(function () {
    angular
        .module('app')
        .controller('indexController', indexController);

    indexController.$inject = ['$scope', '$location', '$log', 'dataService', 'authService'];

    function indexController($scope, $location, $log, dataService, authService) {
        var vm = this;

        vm.blogEntries = [];
        vm.categories = [];
        vm.ageStatistic = {};
        vm.ageStatistic.unit = 0;
        vm.ageStatistic.value = '';
        vm.ageStatistic.key = 'age';
        vm.weightStatistic = {};
        vm.heightStatistic = {};
        vm.weightStatistic.key = 'weight';
        vm.heightStatistic.key = 'height';

        vm.authentication = {};
        vm.authentication.userName = authService.authentication.userName;
        vm.authentication.sidebarAuthenticationLabel = '';
        vm.authentication.getSidebarAuthenticationLabel = getSidebarAuthenticationLabel;
        vm.authentication.loginlogout = loginlogout;

        // Scope references needed for deep watch on service variable.
        // http://stackoverflow.com/questions/12576798/how-to-watch-service-variables
        $scope.authService = authService;
        $scope.authService.authentication = authService.authentication;
        $scope.authService.authentication.userName = authService.authentication.userName;

        activate();

        function activate() {
            getBlogEntries();
            getCategories();
            getAgeInWeeks();
            getWeightDisplay();
            getHeightDisplay();

            return vm;
        }

        $scope.$watch('authService.authentication.userName', function (current, original) {
            $log.info('authService.authentication.userName was %s', original);
            $log.info('authService.authentication.userName is now %s', current);

            vm.authentication.userName = current;
            getSidebarAuthenticationLabel();
        });

        function getSidebarAuthenticationLabel() {
            vm.authentication.sidebarAuthenticationLabel = vm.authentication.userName ? vm.authentication.userName + ' ' + 'Sign Out' : 'Sign In';

            return vm.authentication.sidebarAuthenticationLabel;
        }

        // If the person is logged in then this method will log them out.
        // If the person is logged out then this method will take them to
        // the log in page.
        function loginlogout() {
            // If the is auth is false then we want to login now.
            if (authService.authentication.isAuth) {
                authService.logOut();
            }
            else {
                $location.path("/login");
            }
        }

        function getHeightDisplay() {
            return dataService.getEntity('statistics', vm.heightStatistic.key).then(function (data) {
                vm.heightStatistic.unit = data[0].statisticUnit;
                vm.heightStatistic.value = data[0].statisticValue;

                return vm.heightStatistic;
            });
        }

        function getWeightDisplay() {
            return dataService.getEntity('statistics', vm.weightStatistic.key).then(function (data) {
                vm.weightStatistic.unit = data[0].statisticUnit;
                vm.weightStatistic.value = data[0].statisticValue;

                return vm.weightStatistic;
            });
        }

        function getAgeInWeeks() {
            return dataService.getEntity('statistics', vm.ageStatistic.key).then(function (data) {
                vm.ageStatistic.unit = data[0].statisticUnit;
                vm.ageStatistic.value = data[0].statisticValue;

                return vm.ageStatistic;
            });
        }

        function getBlogEntries() {
            vm.blogEntries = [
                {
                    year: '2014',
                    month: 'July',
                    messageTitle: 'First!',
                    messageBody: 'I am the proud father of a new blog... er um proud father of a new baby that now has a blog',
                    userName: 'theox',
                    date: '7/22/2014'
                },
                {
                    year: '2014',
                    month: 'April',
                    messageTitle: 'Happy Anniversary!',
                    messageBody: 'Well, it has been 6 years, can you believe it!?  We have had our ups and our downs and ' +
                        'through it all I still love you as much as the day I gave you that little necklace on your last day of ' +
                        'your first trip to New York.  I love you Kim.  Hey, maybe someday Kiarah will read this and know ' +
                        'that her parents are loving and committed since that day in 2006 all the way through our wedding in 2009 and ' +
                        'then through the final days!',
                    userName: 'theox',
                    date: '4/11/2015'
                }
            ];

            return vm.blogEntries;
        }

        function getCategories() {
            vm.categories = [
                {
                    name: 'Other',
                },
                {
                    name: 'Person'
                },
                {
                    name: 'News'
                }
            ]

            return vm.categories;
        }

        //function getCounts() {
        //    return dataService.getCounts().then(function (data) {
        //        vm.counts = data;

        //        return vm.counts;
        //    });
        //}
    }
})();