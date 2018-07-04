﻿
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/Customers', {
            controller: 'customerController',
            templateUrl: 'ClientApp/views/customers/customers.html'
        })
        .when('/Products', {
            controller: 'productController',
            templateUrl: 'ClientApp/views/products/index.html'
        })
        .when('/Suppliers', {
            controller: 'supplierController',
            templateUrl: 'ClientApp/views/suppliers/suppliers.html'
        })
        .when('/Users', {
            controller: 'userController',
            templateUrl: 'ClientApp/views/users/index.html'
        })
        .when('/', {
            templateUrl: 'ClientApp/views/home.html'
        });
    $locationProvider.html5Mode(true);
});