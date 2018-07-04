app.controller('supplierController', ['$scope', 'SupplierService', 'ngDialog',
    function ($scope, SupplierService, ngDialog) {
        $scope.suppliers = SupplierService.query();

        $scope.supplier = {
            Id: 0,
            Name: '',
            Description: '',
            SupplierCode: ''
        };

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

        $scope.EditSupplier = function (sup) {
            var oldSup = angular.copy(sup);
            ngDialog.open({
                template: 'clientApp/views/suppliers/supplier_edit.html',
                data: { supplier: oldSup, edited: true }
            }).closePromise.then(function (data) {
                if (data.value.value === true) {
                    UpdateSupplier(sup, data.value.supplier)
                }
            });
        };

        function CreateSupplier(supplier) {
            SupplierService.save(supplier, function (success) {
                console.log(success);
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

        function UpdateSupplier(oldSup, sup) {
            SupplierService.update({ id: sup.ID }, sup, function (success) {
                UpdateTable(sup);
            }, function (error) {
                UpdateTable(oldSup);
                console.log("error: " + error.message);
            });
        }

        function UpdateTable(sup) {
            $.grep($scope.suppliers, function (e) {
                if (e.ID == sup.ID) {
                    e.Name = sup.Name;
                    e.Description = sup.Description;
                    e.SupplierCode = sup.SupplierCode;
                }
            });
        }
}]);