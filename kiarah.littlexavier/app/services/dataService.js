(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', dataService);

    dataService.$inject = ['$http', '$log'];

    function dataService($http, $log) {
        var apiUrl = 'api/';

        var service = {
            getEntity: getEntity,
            searchEntity: searchEntity,
            searchEntityCount: searchEntityCount,
            addOrUpdateEntity: addOrUpdateEntity,
            deleteEntity: deleteEntity,
        };

        return service;

        function getEntity(entityDataStore, id) {
            return $http.get(apiUrl + entityDataStore + (id ? '/' + id : ''))
                        .then(getComplete)
                        .catch(getFailed);

            function getComplete(response) {
                return response.data;
            }

            function getFailed(error) {
                $log.error('XHR failed for get ' + entityDataStore + '.' + error.data.message + ': '
                    + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }

        function searchEntity(entityDataStore, searchCriteria) {
            return $http.post(apiUrl + entityDataStore + '/search', searchCriteria)
                        .then(searchComplete)
                        .catch(searchFailed);

            function searchComplete(response) {
                return response.data;
            }

            function searchFailed(error) {
                $log.error('XHR failed for search ' + entityDataStore + '.' + error.data.message + ': '
                    + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }

        function searchEntityCount(entityDataStore, searchCriteria) {
            return $http.post(apiUrl + entityDataStore + '/search/count', searchCriteria)
                            .then(searchCountComplete)
                            .catch(searchCountFailed);

            function searchCountComplete(response) {
                return response.data;
            }

            function searchCountFailed(error) {
                $log.error('XHR failed for searchCount ' + entityDataStore + '.' + error.data.message + ': '
                    + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }

        function addOrUpdateEntity(entityDataStore, entity) {
            return $http.post(apiUrl + entityDataStore, entity)
                            .then(addOrUpdateComplete)
                            .catch(addOrUpdateFailed);

            function addOrUpdateComplete(response) {
                return response.data;
            }

            function addOrUpdateFailed(error) {
                $log.error('XHR failed for addOrUpdate ' + entityDataStore + '.' + error.data.message + ': '
                    + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }

        function deleteEntity(entityDataStore, id) {
            return $http.delete(apiUrl + '/' + id)
                        .then(deleteComplete)
                        .catch(deleteFailed);

            function deleteComplete(response) {
                return response.data;
            }

            function deleteFailed(error) {
                $log.error('XHR failed for delete ' + entityDataStore + '.' + error.data.message + ': '
                    + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }
    }
})();