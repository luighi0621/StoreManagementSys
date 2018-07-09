app.controller('userController', ['$scope', 'UserService', 'ngDialog', function ($scope, UserService, ngDialog) {
    $scope.user = {
        ID: 0,
        FirstName: '',
        LastName: '',
        Login: '',
        Email: '',
        Phone: '',
        AvatarImage: null
    };
    $scope.users = [];

    UserService.query(function (usrs) {
        $scope.users = usrs;
    }, function (error) {
        console.log(error);
    });

    $scope.AddUser = function () {
        ngDialog.open({
            template: 'clientApp/views/users/user_edit.html',
            data: { user: $scope.user, edited: false}
        }).closePromise.then(function (data) {
            if (data.value !== 'undefined' && data.value.value === true) {
                CreateUser(data.value.user);
            }
        });
    };

    $scope.GetUser = function (us) {
        ngDialog.open({
            template: 'clientApp/views/users/user_detail.html',
            data: { user: us, delete: false }
        });
    };

    $scope.DeleteUser = function (us) {
        ngDialog.open({
            template: 'clientApp/views/users/user_detail.html',
            data: { user: us, delete: true }
        }).closePromise.then(function (data) {
            if (data.value === true) {
                DeleteConfirmed(us);
            }
        });
    };

    $scope.EditUser = function (use) {
        var oldUse = angular.copy(use);
        console.log(oldUse);
        ngDialog.open({
            template: 'clientApp/views/users/user_edit.html',
            data: { user: oldUse, edited: true}
        }).closePromise.then(function (data) {
            if (data.value !== 'undefined' && data.value.value === true) {
                UpdateUser(use, data.value.user);
            }
        });
    };
    function CreateUser(use) {
        UserService.save(use, function (success) {
            $scope.users.push(success);
        }, function (error) {
            console.log("error: " + error.message);
        });
    }

    function DeleteConfirmed(us) {
        UserService.delete({ id: us.ID }, function (success) {
            var _index = $scope.users.indexOf(us);
            $scope.users.splice(_index, 1);
        }, function (error) {
            console.log("error: " + error.message);
        });
    }

    function UpdateUser(oldCus, cus) {
        UserService.update({ id: cus.ID }, cus, function (success) {
            UpdateTable(cus);
        }, function (error) {
            UpdateTable(oldCus);
            console.log("error: " + error.message);
        });
    }

    function UpdateTable(cus) {
        $.grep($scope.users, function (e) {
            if (e.ID === cus.ID) {
                e.Firstname = cus.Firstname;
                e.Lastname = cus.Lastname;
                e.Login = cus.Login;
                e.Email = cus.Email;
                e.Phone = cus.Phone;
                e.AvatarImage = cus.AvatarImage;
            }
        });
    }
}]);