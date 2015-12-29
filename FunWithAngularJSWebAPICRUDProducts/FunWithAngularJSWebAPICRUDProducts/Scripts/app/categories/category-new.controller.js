(function () {
    'use strict';

    angular
        .module('app')
        .controller('CategoriesNewController', CategoriesNewController);

    CategoriesNewController.$inject = ['$location', 'categories'];

    function CategoriesNewController($location, categories) {
        var vm = this;

        function newCategory() {
            return {
                name: "",
                description: ""
            };
        }

        vm.title = "New Category";
        vm.category = newCategory();

        vm.confirm = function () {
            categories.post(vm.category, function (response) {
                alert('Category successfully added');
                vm.category = newCategory();
            }, function (errorMessage) {
                alert(errorMessage);
            });
        };
    }
})();