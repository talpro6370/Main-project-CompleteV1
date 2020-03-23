const module = angular.module("myFlightApp", [])
module.controller("MainCtrl", function ($scope, $http) {
    $scope.FIRST_NAME = null;
    $scope.LAST_NAME = null;
    $scope.USER_NAME = null;
    $scope.PASSWORD = null;
    $scope.email = null;
    $scope.ADDRESS = null;
    $scope.PHONE_NO = null;
    $scope.CREDIT_CARD_NUMBER = null;
    $scope.city.cityName = null;
    $scope.city.street = null;
    $scope.city.houseNumber = 0;

    $scope.postData = function (FIRST_NAME, LAST_NAME, USER_NAME, PASSWORD, email, ADDRESS, PHONE_NO, CREDIT_CARD_NUMBER,city,street,houseNumber) {
        var data = {
            FIRST_NAME: FIRST_NAME,
            LAST_NAME: LAST_NAME,
            USER_NAME: USER_NAME,
            PASSWORD: PASSWORD,
            email: email,
            ADDRESS: ADDRESS,
            PHONE_NO: PHONE_NO,
            CREDIT_CARD_NUMBER: CREDIT_CARD_NUMBER,
            cityName: cityName,
            street: street,
            houseNumber:houseNumber
        };

        $scope.onSubmit = function (valid) { 
                                           
            if (valid) {
                $http.post("/api/AnonymousFacade/CreateNewCustomer", JSON.stringify(data)).then(function (response) {
                    if (response.data) {
                        swal.fire({
                            icon: 'success',
                            title: 'Account successfully created! Please verify email',
                            timer:5000
                        });
                        //setTimeout(() => {
                        //    window.location.replace("http://localhost:58981/CustomerRegistration/LoginPageCustomer");
                        //}, 5000);
                    }
                }, function (response) {
                    $scope.msg = "Service not exist";
                    $scope.statusval = response.status;
                    $scope.statustext = response.statusText;
                    $scope.headers = response.headers();
                });
            }
        }

    };
});
