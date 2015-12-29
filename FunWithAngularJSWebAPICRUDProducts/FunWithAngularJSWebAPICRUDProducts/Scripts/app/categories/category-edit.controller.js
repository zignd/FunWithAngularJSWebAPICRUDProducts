(function () {
    'use strict';

    angular
        .module('app')
        .controller('CategoriesEditController', CategoriesEditController);

    CategoriesEditController.$inject = ['$location', '$routeParams', 'categories'];

    function CategoriesEditController($location, $routeParams, categories) {
        var vm = this;

        vm.title = "Edit Category";

        categories.getById($routeParams.id,
            function (category) {
                vm.category = {
                    id: category.Id,
                    name: category.Name,
                    description: category.Description
                }
            }, function (errorMessage) {
                alert(errorMessage);
                $location.path('/');
                $location.replace();
            });

        vm.confirm = function () {
            categories.put(vm.category,
                function (response) {
                    alert('Category successfully editted');
                    $location.path('/');
                }, function (errorMessage) {
                    alert(errorMessage);
                });
        };
    }
})();