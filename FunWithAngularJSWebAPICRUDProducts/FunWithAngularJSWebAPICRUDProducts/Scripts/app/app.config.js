(function () {
    'use strict';

    angular
        .module('app')
        .config(function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'scripts/app/main/main.html',
                    controller: 'MainController',
                    controllerAs: 'vm'
                })
                .when('/products/new', {
                    templateUrl: 'scripts/app/products/product.html',
                    controller: 'ProductNewController',
                    controllerAs: 'vm',
                    resolve: {
                        authentication: authentication
                    }
                })
                .when('/products/edit/:id', {
                    templateUrl: 'scripts/app/products/product.html',
                    controller: 'ProductEditController',
                    controllerAs: 'vm',
                    resolve: {
                        authentication: authentication
                    }
                })
                .when('/categories', {
                    templateUrl: 'scripts/app/categories/list.html',
                    controller: 'CategoriesListController',
                    controllerAs: 'vm'
                })
                .when('/categories/new', {
                    templateUrl: 'scripts/app/categories/category.html',
                    controller: 'CategoriesNewController',
                    controllerAs: 'vm',
                    resolve: {
                        authentication: authentication
                    }
                })
                .when('/categories/edit/:id', {
                    templateUrl: 'scripts/app/categories/category.html',
                    controller: 'CategoriesEditController',
                    controllerAs: 'vm',
                    resolve: {
                        authentication: authentication
                    }
                })
                .when('/signin', {
                    templateUrl: 'scripts/app/account/signin.html',
                    controller: 'SignInController',
                    controllerAs: 'vm'
                })
                .when('/signup', {
                    templateUrl: 'scripts/app/account/signup.html',
                    controller: 'SignUpController',
                    controllerAs: 'vm'
                })
                .otherwise({
                    redirectTo: '/'
                });
        });

    authentication.$inject = ['$q', '$location', 'user'];

    function authentication($q, $location, user) {
        if (!user.isAuthenticated()) {
            var returnUrl = $location.path();
            $location.path('/signin');
            $location.search('returnUrl', returnUrl);
            $location.replace();
        }
    }
})();