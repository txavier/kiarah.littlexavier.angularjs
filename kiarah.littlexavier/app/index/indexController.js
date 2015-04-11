(function () {
    angular
        .module('app')
        .controller('indexController', indexController);

    indexController.$inject = ['$scope', 'dataService'];

    function indexController($scope, dataService) {
        var vm = this;

        vm.counts = [];

        activate();

        function activate() {

            return vm;
        }

        //function getCounts() {
        //    return dataService.getCounts().then(function (data) {
        //        vm.counts = data;

        //        return vm.counts;
        //    });
        //}
    }
})();