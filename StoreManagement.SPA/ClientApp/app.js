var app = angular.module('StoreManagement', ['ngRoute', 'ngResource', 'ngDialog']);
app.controller('customerController', ['$scope', 'CustomerService', 'ngDialog',
    function ($scope, CustomerService, ngDialog) {
    $scope.customer = {
        ID: 0,
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
            console.log(data)
            if (data.value.value === true) {
                console.log('create customer');
                CreateCustomer(data.value.customer);
            }
        });
        //var _cus = {
        //    Id: $scope.customers.length + 1,
        //    FirstName: $scope.customer.Firstname,
        //    LastName: $scope.customer.Lastname,
        //    Address: $scope.customer.Address,
        //    Email: $scope.customer.Email,
        //    Phone: $scope.customer.Phone,
        //    CustomerCode: $scope.customer.CustomerCode
        //};

        //$scope.customers.push(_cus);
        //ClearModel();
    };

    function CreateCustomer(customer) {
        CustomerService.save(customer, function (success) {
            $scope.customers.push(success)
        }, function (error) {
            console.log("error: " + error.message);
        });
    }

    $scope.EditCustomer = function (cus) {
        var oldCus = angular.copy(cus);
        ngDialog.open({
            template: 'clientApp/views/customers/customer_edit.html',
            data: { customer: oldCus, edited: true }
        }).closePromise.then(function (data) {
            console.log(data)
            if (data.value.value === true) {
                console.log('edit customer');
                UpdateCustomer(cus, data.value.customer)
            }
        });

        //console.log(cus.ID);
        //var customerGet = CustomerService.get({ id: cus.ID });
        //console.log(customerGet);
        //$scope.customer.Id = cus.Id;
        //$scope.customer.Firstname = cus.Firstname;
        //$scope.customer.Lastname = cus.Lastname;
        //$scope.customer.Address = cus.Address;
        //$scope.customer.Email = cus.Email;
        //$scope.customer.Phone = cus.Phone;
        //$scope.customer.CustomerCode = cus.CustomerCode;
    };

    $scope.GetCustomer = function (cus) {
        console.log(cus);
        ngDialog.open({
            template: 'clientApp/views/customers/customer_detail.html',
            data: { customer: cus, delete: false }
        });
    };

    function UpdateCustomer(oldCus, cus) {
        CustomerService.update({ id: cus.ID }, cus, function (success) {
            UpdateTable(cus);
        }, function (error) {
            UpdateTable(oldCus);
            console.log("error: " + error.message);
        });
    };

    function UpdateTable(cus){
        $.grep($scope.customers, function (cus) {
            if (cus.ID == $scope.customer.ID) {
                cus.Firstname = $scope.customer.Firstname;
                cus.Lastname = $scope.customer.Lastname;
                cus.Address = $scope.customer.Address;
                cus.Email = $scope.customer.Email;
                cus.Phone = $scope.customer.Phone;
                cus.CustomerCode = $scope.customer.CustomerCode;
            }
        });
}

    //$scope.UpdateCustomer = function () {
    //    $.grep($scope.customers, function (e) {
    //        if (e.Id == $scope.customer.Id) {
    //            e.Firstname = $scope.customer.Firstname;
    //            e.Lastname = $scope.customer.Lastname;
    //            e.Address = $scope.customer.Address;
    //            e.Email = $scope.customer.Email;
    //            e.Phone = $scope.customer.Phone;
    //            e.CustomerCode = $scope.customer.CustomerCode;
    //        }
    //    });
    //    ClearModel();
    //};

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

    $scope.CleanModel = function () {
        ClearModel();
    };

    function ClearModel() {
        $scope.customer.Id = 0;
        $scope.customer.Firstname = '';
        $scope.customer.Lastname = '';
        $scope.customer.Address = '';
        $scope.customer.Email = '';
        $scope.customer.Phone = '';
        $scope.customer.CustomerCode = '';
    }
    function DeleteConfirmed(cus) {
        CustomerService.delete({ id: cus.ID }, function (success) {
            var _index = $scope.customers.indexOf(cus);
            $scope.customers.splice(_index, 1);
        }, function (error) {
            console.log("error: " + error.message);
        });
    }
}]);

app.controller('userController', ['$scope', function ($scope) {
    $scope.user = {
        Id: 0,
        FirstName: '',
        LastName: '',
        Login: '',
        AvatarImage: ''
    };
    $scope.users = [];

    $scope.AddUser = function () {
        var _cus = {
            Id: $scope.users.length + 1,
            FirstName: $scope.user.FirstName,
            LastName: $scope.user.LastName,
            AvatarImage: $scope.user.AvatarImage,
            Login: $scope.user.Login
        };

        $scope.users.push(_cus);
        ClearModel();
    };

    $scope.EditUser= function (cus) {
        $scope.user.Id = cus.Id;
        $scope.user.FirstName = cus.FirstName;
        $scope.user.LastName = cus.LastName;
        $scope.user.Login = cus.Login;
        $scope.user.AvatarImage = cus.AvatarImage;
    };

    $scope.UpdateUser = function () {
        $.grep($scope.users, function (e) {
            if (e.Id == $scope.user.Id) {
                e.FirstName = $scope.user.FirstName;
                e.LastName = $scope.user.LastName;
                e.Login = $scope.user.Login;
                e.AvatarImage = $scope.user.AvatarImage;
            }
        });
        ClearModel();
    };

    $scope.DeleteUser = function (cus) {
        var _index = $scope.users.indexOf(cus);
        $scope.users.splice(_index, 1);
    };

    $scope.CleanModel = function () {
        ClearModel();
    };

    function ClearModel() {
        $scope.user.Id = 0;
        $scope.user.FirstName = '';
        $scope.user.LastName = '';
        $scope.user.Login = '';
        $scope.user.AvatarImage = '';
    }
}]);


app.controller('productController', ['$scope', function ($scope) {
    $scope.product = {
        Id: 0,
        Name: '',
        Description: '',
        Image: '',
        ProductCode: '',
        Supplier: ''
    };
    $scope.products = [];

    $scope.AddProduct = function () {
        var _cus = {
            Id: $scope.customers.length + 1,
            Name: $scope.customer.Name,
            Description: $scope.customer.Description,
            Image: $scope.customer.Image,
            ProductCode: $scope.customer.ProductCode,
            Supplier: $scope.customer.Supplier
        };

        $scope.products.push(_cus);
        ClearModel();
    };

    $scope.EditProduct = function (cus) {
        $scope.customer.Id = cus.Id;
        $scope.customer.Name = cus.Name;
        $scope.customer.Description = cus.Description;
        $scope.customer.Image = cus.Image;
        $scope.customer.ProductCode = cus.ProductCode;
        $scope.customer.Supplier = cus.Supplier;
    };

    $scope.UpdateProduct = function () {
        $.grep($scope.customers, function (e) {
            if (e.Id == $scope.customer.Id) {
                e.Name = $scope.customer.Name;
                e.Description = $scope.customer.Description;
                e.Image = $scope.customer.Image;
                e.ProductCode = $scope.customer.ProductCode;
                e.Supplier = $scope.customer.Supplier;
            }
        });
        ClearModel();
    };

    $scope.DeleteProduct = function (cus) {
        var _index = $scope.products.indexOf(cus);
        $scope.products.splice(_index, 1);
    };

    $scope.CleanModel = function () {
        ClearModel();
    };

    function ClearModel() {
        $scope.product.Id = 0;
        $scope.product.Name = '';
        $scope.product.Description = '';
        $scope.product.Image = '';
        $scope.product.ProductCode = '';
        $scope.product.Supplier = '';
    }
}]);

app.controller('supplierController', ['$scope', function ($scope) {
    $scope.supplier = {
        Id: 0,
        Name: '',
        Description: '',
        SupplierCode: ''
    };
    $scope.suppliers = [];

    $scope.AddProduct = function () {
        var _cus = {
            Id: $scope.suppliers.length + 1,
            Name: $scope.supplier.Name,
            Description: $scope.supplier.Description,
            SupplierCode: $scope.supplier.SupplierCode
        };

        $scope.suppliers.push(_cus);
        ClearModel();
    };

    $scope.EditProduct = function (cus) {
        $scope.supplier.Id = cus.Id;
        $scope.supplier.Name = cus.Name;
        $scope.supplier.Description = cus.Description;
        $scope.supplier.SupplierCode = cus.SupplierCode;
    };

    $scope.UpdateProduct = function () {
        $.grep($scope.customers, function (e) {
            if (e.Id == $scope.supplier.Id) {
                e.Name = $scope.supplier.Name;
                e.Description = $scope.supplier.Description;
                e.SupplierCode = $scope.supplier.SupplierCode;
            }
        });
        ClearModel();
    };

    $scope.DeleteProduct = function (cus) {
        var _index = $scope.suppliers.indexOf(cus);
        $scope.suppliers.splice(_index, 1);
    };

    $scope.CleanModel = function () {
        ClearModel();
    };

    function ClearModel() {
        $scope.supplier.Id = 0;
        $scope.supplier.Name = '';
        $scope.supplier.Description = '';
        $scope.supplier.SupplierCode = '';
    }
}]);
app.factory('CustomerService', function ($resource) {
    return $resource('http://localhost:57826/api/customers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    })
});
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/Customers', {
            controller: 'customerController',
            templateUrl: 'ClientApp/views/customers/index.html'
        })
        .when('/Products', {
            controller: 'productController',
            templateUrl: 'ClientApp/views/products/index.html'
        })
        .when('/Suppliers', {
            controller: 'supplierController',
            templateUrl: 'ClientApp/views/suppliers/index.html'
        })
        .when('/Users', {
            controller: 'userController',
            templateUrl: 'ClientApp/views/users/index.html'
        })
        .when('/', {
            //controller: 'testController',
            templateUrl: 'ClientApp/views/home.html'
        });
    $locationProvider.html5Mode(true);
});