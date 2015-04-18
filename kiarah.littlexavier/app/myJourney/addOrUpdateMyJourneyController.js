(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateMyJourneyController', addOrUpdateMyJourneyController);

    addOrUpdateMyJourneyController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateMyJourneyController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.myJournies = [];
        vm.myJourney = {};
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getMyJourney($routeParams.myJourneyId);

            return vm;
        }

        function getMyJourney(myJourneyId) {
            if (!myJourneyId) {
                return;
            }
            return dataService.getEntity('myJournies', myJourneyId).then(function (data) {
                vm.myJourney = data;

                return vm.myJourney;
            });
        }

        function addOrUpdate(myJourney) {
            return dataService.addOrUpdateEntity('myJournies', myJourney)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();