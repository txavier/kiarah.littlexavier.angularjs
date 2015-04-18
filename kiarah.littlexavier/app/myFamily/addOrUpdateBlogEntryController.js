(function () {
    'use strict';

    angular
        .module('app')
        .controller('addOrUpdateBlogEntryController', addOrUpdateBlogEntryController);

    addOrUpdateBlogEntryController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function addOrUpdateBlogEntryController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.blogEntries = [];
        vm.blogEntry = {};
        vm.addOrUpdate = addOrUpdate;

        activate();

        function activate() {
            getBlogEntry($routeParams.blogEntryId);

            return vm;
        }

        function getBlogEntry(blogEntryId) {
            if (!blogEntryId) {
                return;
            }
            return dataService.getEntity('blogEntries', blogEntryId).then(function (data) {
                vm.blogEntry = data;

                return vm.blogEntry;
            });
        }

        function addOrUpdate(blogEntry) {
            return dataService.addOrUpdateEntity('blogEntries', blogEntry)
                .then(function () {
                    $scope.$apply();

                    history.back();
                });
        }

    }

})();