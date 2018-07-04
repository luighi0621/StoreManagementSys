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

    $scope.EditUser = function (cus) {
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