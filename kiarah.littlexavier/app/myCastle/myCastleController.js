(function () {
    'use strict';

    angular
        .module('app')
        .controller('myCastleController', myCastleController);

    myCastleController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function myCastleController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.myCastles = [];
        vm.searchMyCastles = searchMyCastles;
        vm.deleteMyCastle = deleteMyCastle;
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
            searchMyCastles(vm.searchCriteria);
            searchMyCastlesCount(vm.searchCriteria);

            return vm;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyCastles(vm.searchCriteria);
        }

        function searchMyCastles(searchCriteria) {
            return dataService.searchEntity('myCastles', searchCriteria).then(function (data) {
                vm.myCastles = data;

                return vm.myCastles;
            });
        }

        function searchMyCastlesCount(searchCriteria) {
            return dataService.searchEntityCount('myCastles', searchCriteria).then(function (data) {
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
                year: $routeParams.year,
                month: $routeParams.month,
                myCastleTitle: $routeParams.myCastleTitle,
                includeProperties: ''
            }

            return vm.searchCriteria;
        }

        function deleteMyCastle(myCastleId) {
            return dataService.deleteEntity('myCastles', myCastleId)
                .then(function (data) {
                    searchMyCastles(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyCastles(vm.searchCriteria);
        }
    }
})();