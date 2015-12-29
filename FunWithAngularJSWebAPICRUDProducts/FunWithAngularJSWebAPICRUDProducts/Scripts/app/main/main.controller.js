(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController);

    MainController.$inject = ['$scope', 'products', 'user'];

    function MainController($scope, products, user) {
        var vm = this;

        vm.isLoadingProducts = true;
        vm.products = [];

        $scope.$watch(function () {
            return user.userData.isAuthenticated;
        }, function (data) {
            vm.isAuthenticated = data;
        }, false);

        products.getAll(function (data) {
            vm.isLoadingProducts = false;
            vm.products = data;
        }, function (errorMessage) {
            alert(errorMessage);
        });

        vm.deleteProduct = function (id) {
            if (!confirm("Would you like to delete this product?")) {
                return;
            }   

            products.delete(id, function (response) {
                var productIndex = vm.products.findIndex(function (value, index, traversedObject) {
                    return value.Id === id;
                });

                if (productIndex > -1) {
                    vm.products.splice(productIndex, 1);
                }

                alert('Product successfully deleted');
            }, function (errorMessage) {
                alert(errorMessage);
            });
        };
    }
})();

