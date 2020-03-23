const module = angular.module("myFlightApp", [])
module.controller("LoginCustCtrl", function ($scope, $http) {
    $scope.USER_NAME = null;
    $scope.PASSWORD = null;
    $scope.email = null;

    $scope.postData = function (USER_NAME, PASSWORD) {
        var data = {
            USER_NAME: USER_NAME,
            PASSWORD: PASSWORD
        };

        $scope.onSubmit = function (valid) {

            $http.post("/api/AnonymousFacade/CheckCustLogin", JSON.stringify(data)).then(function (response) {
                if (response.data) {
                    swal.fire({
                        icon: 'success',
                        title: 'Successfully logged in!',
                        timer: 5000
                    });
                    setTimeout(function () {
                        window.location.replace("http://localhost:58981/Flight/homepage1");
                    }, 5000);

                }
                else {
                    swal.fire({
                        icon: 'Error',
                        title: 'Incorrect details!',
                        timer: 3000
                    });
                    setTimeout(() => {
                        location.reload();
                    }, 3000);
                }
            }, function (response) {
                console.log("IF CLAUSE DIDNT SUCCESS");
                    $scope.msg = "Service not exist";
                    $scope.statusval = response.status;
                    $scope.statustext = response.statusText;
                    $scope.headers = response.headers();
                });
            
        }

    };
});
