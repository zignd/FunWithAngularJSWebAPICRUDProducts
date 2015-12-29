(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProductEditController', ProductEditController);

    ProductEditController.$inject = ['$location', '$routeParams', 'products', 'categories'];

    function ProductEditController($location, $routeParams, products, categories) {
        var vm = this;

        vm.title = "Edit Product";
        vm.categories = [];

        categories.getAll(function (allCategories) {
            for (var category of allCategories) {
                vm.categories.push({ id: category.Id, name: category.Name });
            }
        });

        products.getById($routeParams.id,
            function (product) {
                vm.product = {
                    id: product.Id,
                    name: product.Name,
                    description: product.Description,
                    price: product.Price,
                    categoryId: product.CategoryId
                }
            }, function (errorMessage) {
                alert(errorMessage);
                $location.path('/');
                $location.replace();
            });

        vm.confirm = function () {
            products.put(vm.product,
                function (response) {
                    alert('Product successfully editted');
                    $location.path('/');
                }, function (errorMessage) {
                    alert(errorMessage);
                });
        };
    }
})();