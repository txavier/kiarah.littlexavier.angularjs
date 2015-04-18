(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateMyCastleController', addOrUpdateMyCastleController);

    addOrUpdateMyCastleController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateMyCastleController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.myCastles = [];
        vm.myCastle = {};
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getMyCastle($routeParams.myCastleId);

            return vm;
        }

        function getMyCastle(myCastleId) {
            if (!myCastleId) {
                return;
            }
            return dataService.getEntity('myCastles', myCastleId).then(function (data) {
                vm.myCastle = data;

                return vm.myCastle;
            });
        }

        function addOrUpdate(myCastle) {
            return dataService.addOrUpdateEntity('myCastles', myCastle)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();