(function () {
    'use strict';

    angular
        .module('app')
        .controller('myFamiliesController', myFamiliesController);

    myFamiliesController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function myFamiliesController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.myFamilies = [];
        vm.searchMyFamilies = searchMyFamilies;
        vm.deleteMyFamily = deleteMyFamily;
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
            searchMyFamilies(vm.searchCriteria);
            searchMyFamiliesCount(vm.searchCriteria);

            return vm;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyFamilies(vm.searchCriteria);
        }

        function searchMyFamilies(searchCriteria) {
            return dataService.searchEntity('myFamilies', searchCriteria).then(function (data) {
                vm.myFamilies = data;

                return vm.myFamilies;
            });
        }

        function searchMyFamiliesCount(searchCriteria) {
            return dataService.searchEntityCount('myFamilies', searchCriteria).then(function (data) {
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
                myFamilyTitle: $routeParams.myFamilyTitle,
                includeProperties: 'category,myFamilyComments'
            }

            return vm.searchCriteria;
        }

        function deleteMyFamily(myFamilyId) {
            return dataService.deleteEntity('myFamilies', myFamilyId)
                .then(function (data) {
                    searchMyFamilies(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchMyFamilies(vm.searchCriteria);
        }
    }
})();