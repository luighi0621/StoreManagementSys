app.controller('customerController', ['$scope', 'CustomerService', 'ngDialog',
    function ($scope, CustomerService, ngDialog) {

        $scope.customer = {
            Id: 0,
            Firstname: '',
            Lastname: '',
            Address: '',
            Email: '',
            Phone: '',
            CustomerCode: ''
        };

        $scope.customers = CustomerService.query();;

        $scope.AddCustomer = function () {
            ngDialog.open({
                template: 'clientApp/views/customers/customer_edit.html',
                data: { customer: $scope.customer, edited: false }
            }).closePromise.then(function (data) {
                if (data.value.value === true) {
                    CreateCustomer(data.value.customer);
                }
            });
        };

        $scope.EditCustomer = function (cus) {
            var oldCus = angular.copy(cus);
            ngDialog.open({
                template: 'clientApp/views/customers/customer_edit.html',
                data: { customer: oldCus, edited: true }
            }).closePromise.then(function (data) {
                console.log(data)
                if (data.value.value === true) {
                    UpdateCustomer(cus, data.value.customer)
                }
            });
        };

        $scope.GetCustomer = function (cus) {
            ngDialog.open({
                template: 'clientApp/views/customers/customer_detail.html',
                data: { customer: cus, delete: false }
            });
        };

        $scope.DeleteCustomer = function (cus) {
            ngDialog.open({
                template: 'clientApp/views/customers/customer_detail.html',
                data: { customer: cus, delete: true }
            }).closePromise.then(function (data) {
                if (data.value === true) {
                    DeleteConfirmed(cus);
                }
            });

        };

        function CreateCustomer(customer) {
            CustomerService.save(customer, function (success) {
                $scope.customers.push(success)
            }, function (error) {
                console.log("error: " + error.message);
            });
        }

        function DeleteConfirmed(cus) {
            CustomerService.delete({ id: cus.ID }, function (success) {
                var _index = $scope.customers.indexOf(cus);
                $scope.customers.splice(_index, 1);
            }, function (error) {
                console.log("error: " + error.message);
            });
        }

        function UpdateCustomer(oldCus, cus) {
            CustomerService.update({ id: cus.ID }, cus, function (success) {
                UpdateTable(cus);
            }, function (error) {
                UpdateTable(oldCus);
                console.log("error: " + error.message);
            });
        }

        function UpdateTable(cus) {
            $.grep($scope.customers, function (e) {
                if (e.ID == cus.ID) {
                    e.Firstname = cus.Firstname;
                    e.Lastname = cus.Lastname;
                    e.Address = cus.Address;
                    e.Email = cus.Email;
                    e.Phone = cus.Phone;
                    e.CustomerCode = cus.CustomerCode;
                }
            });
        }
    }]);