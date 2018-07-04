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