(function () {
    'use strict';

    angular
        .module('app')
        .controller('CategoriesListController', CategoriesListController);

    CategoriesListController.$inject = ['$scope', 'categories', 'user'];

    function CategoriesListController($scope, categories, user) {
        var vm = this;

        vm.isLoadingCategories = true;
        vm.categories = [];

        $scope.$watch(function () {
            return user.userData.isAuthenticated;
        }, function (data) {
            vm.isAuthenticated = data;
        }, false);

        categories.getAll(function (data) {
            vm.isLoadingCategories = false;
            vm.categories = data;
        }, function (errorMessage) {
            alert(errorMessage);
        });

        vm.deleteCategory = function (id) {
            if (!confirm("Would you like to delete this category?")) {
                return;
            }   

            categories.delete(id, function (response) {
                var categoryIndex = vm.categories.findIndex(function (value, index, traversedObject) {
                    return value.Id === id;
                });

                if (categoryIndex > -1) {
                    vm.categories.splice(categoryIndex, 1);
                }

                alert('Category successfully deleted');
            }, function (errorMessage) {
                alert(errorMessage);
            });
        };
    }
})();

