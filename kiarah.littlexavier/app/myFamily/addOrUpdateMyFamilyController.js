(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateMyFamilyController', addOrUpdateMyFamilyController);

    addOrUpdateMyFamilyController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateMyFamilyController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.myFamilies = [];
        vm.myFamily = {};
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getMyFamily($routeParams.myFamilyId);

            return vm;
        }

        function getMyFamily(myFamilyId) {
            if (!myFamilyId) {
                return;
            }
            return dataService.getEntity('myFamilies', myFamilyId).then(function (data) {
                vm.myFamily = data;

                return vm.myFamily;
            });
        }

        function addOrUpdate(myFamily) {
            return dataService.addOrUpdateEntity('myFamilies', myFamily)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();