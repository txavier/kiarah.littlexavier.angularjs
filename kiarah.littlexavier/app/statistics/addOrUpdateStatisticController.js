(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateStatisticController', addOrUpdateStatisticController);

    addOrUpdateStatisticController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateStatisticController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.statistics = [];
        vm.statistic = {};
        vm.key = '';
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getStatistic($routeParams.key, $routeParams.statisticId);
            setKey($routeParams.key);

            return vm;
        }

        function setKey(key) {
            vm.key = key;

            return vm.key;
        }

        function getStatistic(key, statisticId) {
            if (!key) {
                return;
            }
            return dataService.getEntity('statistics', statisticId || key).then(function (data) {
                vm.statistic = data.length > 0 ? data[0] : null;

                return vm.statistic;
            });
        }

        function addOrUpdate(statistic) {
            statistic.statisticKey = statistic.statisticKey || vm.key;

            return dataService.addOrUpdateEntity('statistics', statistic)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();