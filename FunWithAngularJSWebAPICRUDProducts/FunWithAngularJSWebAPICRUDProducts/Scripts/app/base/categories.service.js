(function () {
    'use strict';

    angular
        .module('app')
        .service('categories', categories);

    categories.$inject = ['$http', 'user', 'API_URL'];

    function categories($http, user, API_URL) {
        var sv = this;
        var endpoint = API_URL + '/categories';

        sv.getAll = function (onSuccess, onFail) {
            var config = {
                method: 'GET',
                url: endpoint
            };
            $http(config)
                .then(function (response) {
                    onSuccess(response.data);
                }, function (response) {
                    onFail(response.statusText);
                });
        };

        sv.getById = function (id, onSuccess, onFail) {
            var config = {
                method: 'GET',
                url: endpoint,
                params: { id: id }
            };
            $http(config)
                .then(function (response) {
                    onSuccess(response.data);
                }, function (response) {
                    onFail(response.statusText);
                });
        };

        sv.post = function (newProduct, onSuccess, onFail) {
            var config = {
                method: 'POST',
                url: endpoint,
                data: newProduct
            };
            $http(config)
                .then(function (response) {
                    onSuccess(response.data);
                }, function (response) {
                    onFail(response.statusText);
                });
        };

        sv.put = function (updatedProduct, onSuccess, onFail) {
            var config = {
                method: 'PUT',
                url: endpoint,
                params: { id: updatedProduct.id },
                data: updatedProduct
            };
            $http(config)
                .then(function (response) {
                    onSuccess(response.data);
                }, function (response) {
                    onFail(response.statusText);
                });
        };

        sv.delete = function (id, onSuccess, onFail) {
            var config = {
                method: 'DELETE',
                url: endpoint,
                params: { id: id }
            }
            $http(config)
                .then(function (response) {
                    onSuccess(response.data);
                }, function (response) {
                    onFail(response.statusText);
                });
        };
    }
})();