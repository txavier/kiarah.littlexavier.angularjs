(function () {
    'use strict';

    angular
        .module('app')
        .controller('blogEntryCommentsController', blogEntryCommentsController);

    blogEntryCommentsController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function blogEntryCommentsController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.blogEntryComments = [];
        vm.searchBlogEntryCommentComments = searchBlogEntryCommentComments;
        vm.deleteBlogEntryComment = deleteBlogEntryComment;
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
            searchBlogEntryCommentComments(vm.searchCriteria);
            searchBlogEntryCommentCommentsCount(vm.searchCriteria);

            return vm;
        }

        function setSortOrder(orderBy) {
            vm.orderBy = orderBy;

            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchBlogEntryCommentComments(vm.searchCriteria);
        }

        function searchBlogEntryCommentComments(searchCriteria) {
            return dataService.searchEntity('blogEntryComments', searchCriteria).then(function (data) {
                vm.blogEntryComments = data;

                return vm.blogEntryComments;
            });
        }

        function searchBlogEntryCommentCommentsCount(searchCriteria) {
            return dataService.searchEntityCount('blogEntryComments', searchCriteria).then(function (data) {
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
                blogEntryCommentTitle: $routeParams.blogEntryCommentTitle
            }

            return vm.searchCriteria;
        }

        function deleteBlogEntryComment(blogEntryCommentId) {
            return dataService.deleteEntity('blogEntryComments', blogEntryCommentId)
                .then(function (data) {
                    searchBlogEntryCommentComments(vm.searchCriteria);
                });
        }

        function pageChanged() {
            setSearchCriteria(vm.currentPage, vm.itemsPerPage, vm.orderBy, vm.searchText);

            searchBlogEntryCommentComments(vm.searchCriteria);
        }
    }
})();