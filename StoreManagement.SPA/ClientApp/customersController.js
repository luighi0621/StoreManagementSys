var cusController = angular.module('customersController', []);
cusController.controller('customersList', ['$scoper', '$http',
    function ($scope, $http) {
        $http.get('/api/customers/').success(function (data) {
            $scope.customers = data;
        });
    }]);

cusController.controller('customersDelete', ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/customers/' + $routeParams.id).success(function (data) {
            $scope.firstName = data.firstName;
            $scope.lastName = data.lastName;
            $scope.address = data.address;
            $scope.email = data.email;
            $scope.phone = data.phone;
            $scope.customerCode = data.customerCode;
        });

        $scope.delete = function () {
            $http.delete('/api/customers/' + $scope.id).success(function (data) {
                $location.path('/customers/');
            }).error(function (data) {
                $scope.erro = "An error has ocurred while deleting customer " + data;
            });
        };
    }]);