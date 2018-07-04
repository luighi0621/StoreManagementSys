app.controller('productController', ['$scope', 'ProductService', 'SupplierService', 'ngDialog',
    function ($scope, ProductService, SupplierService, ngDialog) {
        $scope.product = {
            Id: 0,
            Name: '',
            Description: '',
            Image: '',
            ProductCode: '',
            IdSupplier: 0,
            Supplier: {}
        };
        $scope.products = ProductService.query();
        $scope.suppliers = SupplierService.query();

        $scope.AddProduct = function () {
            ngDialog.open({
                template: 'clientApp/views/products/product_edit.html',
                data: { product: $scope.product, edited: false, suppliers: $scope.suppliers }
            }).closePromise.then(function (data) {
                if (data.value != 'undefined' && data.value.value === true) {
                    data.value.product.Supplier = angular.fromJson(data.value.supplier);
                    data.value.product.IdSupplier = data.value.product.Supplier.ID;
                    CreateProduct(data.value.product);
                }
            });
        };

        $scope.GetProduct = function (prod) {
            ngDialog.open({
                template: 'clientApp/views/products/product_detail.html',
                data: { product: prod, delete: false }
            });
        };

        $scope.DeleteProduct = function (prod) {
            ngDialog.open({
                template: 'clientApp/views/products/product_detail.html',
                data: { product: prod, delete: true }
            }).closePromise.then(function (data) {
                if (data.value === true) {
                    DeleteConfirmed(cus);
                }
            });
        };
        
        $scope.EditProduct = function (prod) {
            var oldProd = angular.copy(prod);
            ngDialog.open({
                template: 'clientApp/views/products/product_edit.html',
                data: { product: oldProd, edited: true, suppliers: $scope.suppliers }
            }).closePromise.then(function (data) {
                if (data.value != 'undefined' && data.value.value === true) {
                    data.value.product.Supplier = angular.fromJson(data.value.supplier);
                    data.value.product.IdSupplier = data.value.product.Supplier.ID;
                    UpdateProduct(prod, data.value.product)
                }
            });
        };
        function CreateProduct(product) {
            ProductService.save(product, function (success) {
                $scope.products.push(success)
            }, function (error) {
                console.log("error: " + error.message);
            });
        }

        function DeleteConfirmed(prod) {
            ProductService.delete({ id: prod.Id }, function (success) {
                var _index = $scope.products.indexOf(prod);
                $scope.products.splice(_index, 1);
            }, function (error) {
                console.log("error: " + error.message);
            });
        }

        function UpdateProduct(oldCus, cus) {
            ProductService.update({ id: cus.Id }, cus, function (success) {
                UpdateTable(cus);
            }, function (error) {
                UpdateTable(oldCus);
                console.log("error: " + error.message);
            });
        }

        function UpdateTable(cus) {
            $.grep($scope.products, function (e) {
                if (e.Id == cus.Id) {
                    e.Name = cus.Name;
                    e.Description = cus.Description;
                    e.IdSupplier = cus.IdSupplier;
                    e.Image = cus.Image;
                    e.ProductCode = cus.ProductCode;
                    e.Supplier = cus.Supplier;
                }
            });
        }
}]);