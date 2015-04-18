(function () {
    'use strict';

    angular
        .module('app')
        .controller('blogEntriesController', blogEntriesController);

    blogEntriesController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function blogEntriesController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.blogEntries = [];
        vm.searchBlogEntries = searchBlogEntries;
        vm.deleteBlogEntry = deleteBlogEntry;
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
            searchBlogEntries(vm.searchCriteria);
            searchBlogEntriesCount(vm.searchCriteria);

            return vm;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchBlogEntries(vm.searchCriteria);
        }

        function searchBlogEntries(searchCriteria) {
            return dataService.searchEntity('blogEntries', searchCriteria).then(function (data) {
                vm.blogEntries = data;

                return vm.blogEntries;
            });
        }

        function searchBlogEntriesCount(searchCriteria) {
            return dataService.searchEntityCount('blogEntries', searchCriteria).then(function (data) {
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
                blogEntryTitle: $routeParams.blogEntryTitle,
                includeProperties: 'category,blogEntryComments'
            }

            return vm.searchCriteria;
        }

        function deleteBlogEntry(blogEntryId) {
            return dataService.deleteEntity('blogEntries', blogEntryId)
                .then(function (data) {
                    searchBlogEntries(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchBlogEntries(vm.searchCriteria);
        }
    }
})();