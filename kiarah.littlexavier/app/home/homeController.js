(function () {
    angular
        .module('app')
        .controller('homeController', homeController);

    homeController.$inject = ['$scope', 'dataService'];

    function homeController($scope, dataService) {
        var vm = this;

        vm.blogEntries = [];
        vm.categories = [];
        vm.ageInWeeks = 0;
        vm.weightDisplay = '';
        vm.heightDisplay = '';

        activate();

        function activate() {
            getBlogEntries();
            getCategories();
            getAgeInWeeks();
            getWeightDisplay();
            getHeightDisplay();

            return vm;
        }

        function getHeightDisplay() {
            vm.heightDisplay = '23 cm tall';

            return vm.heightDisplay;
        }

        function getWeightDisplay() {
            vm.weightDisplay = '23 lbs 1 ounce';

            return vm.weightInOunces;
        }

        function getAgeInWeeks() {
            vm.ageInWeeks = 30;

            return vm.ageInWeeks;
        }

        //function getBlogEntries() {
        //    vm.blogEntries = [
        //        {
        //            year: '2014',
        //            month: 'July',
        //            messageTitle: 'First!',
        //            messageBody: 'I am the proud father of a new blog... er um proud father of a new baby that now has a blog',
        //            userName: 'theox',
        //            date: '7/22/2014'
        //        },
        //        {
        //            year: '2014',
        //            month: 'April',
        //            messageTitle: 'Happy Anniversary!',
        //            messageBody: 'Well, it has been 6 years, can you believe it!?  We have had our ups and our downs and ' +
        //                'through it all I still love you as much as the day I gave you that little necklace on your last day of ' +
        //                'your first trip to New York.  I love you Kim.  Hey, maybe someday Kiarah will read this and know ' +
        //                'that her parents are loving and committed since that day in 2006 all the way through our wedding in 2009 and ' +
        //                'then through the final days!',
        //            userName: 'theox',
        //            date: '4/11/2015'
        //        }
        //    ];

        //    return vm.blogEntries;
        //}

        function getBlogEntries() {
            return dataService.getEntity('blogEntries').then(function (data) {
                vm.blogEntries = data;

                return vm.blogEntries;
            });
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