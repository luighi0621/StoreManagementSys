app.controller('supplierController', ['$scope', 'SupplierService', 'ngDialog',
    function ($scope, SupplierService, ngDialog) {

        $scope.suppliers = SupplierService.query();

        $scope.AddSupplier = function () {
            ngDialog.open({
                template: 'clientApp/views/suppliers/supplier_edit.html',
                data: { supplier: $scope.supplier, edited: false }
            }).closePromise.then(function (data) {
                if (data.value.value === true) {
                    CreateSupplier(data.value.supplier);
                }
            });
        };

        $scope.GetSupplier = function (sup) {
            ngDialog.open({
                template: 'clientApp/views/suppliers/supplier_detail.html',
                data: { supplier: sup, delete: false }
            });
        };

        $scope.DeleteSupplier = function (sup) {
            ngDialog.open({
                template: 'clientApp/views/suppliers/supplier_detail.html',
                data: { supplier: sup, delete: true }
            }).closePromise.then(function (data) {
                if (data.value === true) {
                    DeleteConfirmed(sup);
                }
            });

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
    };

        function CreateSupplier(supplier) {
            CustomerService.save(supplier, function (success) {
                $scope.suppliers.push(success)
            }, function (error) {
                console.log("error: " + error.message);
            });
        }

        function DeleteConfirmed(sup) {
            SupplierService.delete({ id: sup.ID }, function (success) {
                var _index = $scope.suppliers.indexOf(sup);
                $scope.suppliers.splice(_index, 1);
            }, function (error) {
                console.log("error: " + error.message);
            });
        }
}]);