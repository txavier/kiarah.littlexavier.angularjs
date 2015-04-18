(function () {
    'use strict';

    angular
        .module('app')
        .controller('myJourneyController', myJourneyController);

    myJourneyController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function myJourneyController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.myJournies = [];
        vm.searchMyJournies = searchMyJournies;
        vm.deleteMyJourney = deleteMyJourney;
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
            searchMyJournies(vm.searchCriteria);
            searchMyJourniesCount(vm.searchCriteria);

            return vm;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyJournies(vm.searchCriteria);
        }

        function searchMyJournies(searchCriteria) {
            return dataService.searchEntity('myJournies', searchCriteria).then(function (data) {
                vm.myJournies = data;

                return vm.myJournies;
            });
        }

        function searchMyJourniesCount(searchCriteria) {
            return dataService.searchEntityCount('myJournies', searchCriteria).then(function (data) {
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
                myJourneyTitle: $routeParams.myJourneyTitle,
                includeProperties: ''
            }

            return vm.searchCriteria;
        }

        function deleteMyJourney(myJourneyId) {
            return dataService.deleteEntity('myJournies', myJourneyId)
                .then(function (data) {
                    searchMyJournies(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyJournies(vm.searchCriteria);
        }
    }
})();