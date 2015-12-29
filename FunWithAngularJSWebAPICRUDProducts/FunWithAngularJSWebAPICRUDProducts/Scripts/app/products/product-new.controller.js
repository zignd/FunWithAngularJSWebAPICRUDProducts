(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProductNewController', ProductNewController);

    ProductNewController.$inject = ['$location', 'products', 'categories'];

    function ProductNewController($location, products, categories) {
        var vm = this;

        function newProduct() {
            return {
                name: "",
                description: "",
                price: 0.01,
                categoryId: null
            };
        }

        vm.title = "New Product";
        vm.product = newProduct();
        vm.categories = [];

        categories.getAll(function (allCategories) {
            for (var category of allCategories) {
                vm.categories.push({ id: category.Id, name: category.Name });
            }
        });

        vm.confirm = function () {
            products.post(vm.product, function (response) {
                alert('Product successfully added');
                vm.product = newProduct();
            }, function (errorMessage) {
                alert(errorMessage);
            });
        };
    }
})();