(function () {
    'use strict';

    angular
        .module('app')
        .controller('statisticsController', statisticsController);

    statisticsController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function statisticsController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.statistics = [];
        vm.searchStatistics = searchStatistics;
        vm.deleteStatistic = deleteStatistic;
        vm.totalItems = 0;
        vm.itemsPerPage = 10;
        vm.currentPage = 1;
        vm.pageChanged = pageChanged;
        vm.setSortOrder = setSortOrder;
        vm.orderBy = null;
        vm.searchText = null;
        vm.searchCriteria = {};
        vm.searchCriteria.searchText = null;

        activate();

        function activate() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);
            searchStatistics(vm.searchCriteria);
            searchStatisticsCount(vm.searchCriteria);
            setKey();

            return vm;
        }

        function setKey() {
            vm.key = $routeParams.key;

            return vm.key;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchStatistics(vm.searchCriteria);
        }

        function searchStatistics(searchCriteria) {
            return dataService.searchEntity('statistics', searchCriteria).then(function (data) {
                vm.statistics = data;

                return vm.statistics;
            });
        }

        function searchStatisticsCount(searchCriteria) {
            return dataService.searchEntityCount('statistics', searchCriteria).then(function (data) {
                vm.totalItems = data || 0;

                return vm.totalItems;
            });
        }

        function setSearchCriteria(currentPage, itemsPerPage, orderBy, searchText) {
            vm.searchCriteria = {
                currentPage: currentPage,
                itemsPerPage: itemsPerPage,
                orderBy: orderBy,
                searchText: searchText,
                key: $routeParams.key
            }

            return vm.searchCriteria;
        }

        function deleteStatistic(statisticId) {
            return dataService.deleteEntity('statistics', statisticId)
                .then(function (data) {
                    searchStatistics(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchStatistics(vm.searchCriteria);
        }
    }
})();