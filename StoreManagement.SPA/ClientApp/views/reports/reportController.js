app.controller('reportController', ['$scope', 'RepService', 'ngDialog',
    function ($scope, RepService, ngDialog) {
        $scope.reports = [];

        $scope.reportsQuery = [];

        $scope.LoadProductBySupplier = function () {
            var query = RepService.getProductsBySupplier();
            ngDialog.open({
                template: 'clientApp/views/reports/ProductsBySupplier.html',
                data: { reports: query}
            });
        };

        $scope.LoadUsersCustomers = function () {
            var query = RepService.getUsersCustomers();
            ngDialog.open({
                template: 'clientApp/views/reports/UsersCustomers.html',
                data: { reports: query }
            });
        };

        $scope.LoadCustomersByLastname = function () {
            var query = RepService.getCustomersByLastname();
            ngDialog.open({
                template: 'clientApp/views/reports/CustomersByLastname.html',
                data: { reports: query }
            });
        };

        $scope.LoadCustomersAddress = function () {
            $scope.reportsQuery = RepService.getCustomersAddress();
            ngDialog.open({
                template: 'clientApp/views/reports/CustomersAddress.html',
                scope: $scope
            });
        };

        $scope.LoadCustomersAddressWithAddress = function (addressCus) {
            $scope.reportsQuery = RepService.getCustomersAddressWithAddress({ address: addressCus });
        };

        $scope.LoadOperations = function () {
            var query = RepService.getOperations();
            ngDialog.open({
                template: 'clientApp/views/reports/Operations.html',
                className: 'ngdialog-theme-default custom-width-800',
                data: { reports: query }
            });
        };
    }]);