define(['app', 'restangular'], function (app) {
    var app = angular.module('MyApp', ['restangular']);
    app.controller('loginController', ['$scope', '$injector', '$location', 'authService',
    function ($scope, $injector, $localtion, authService) {
        debugger;
        $scope.loginData = {
            userName: "",
            password: "",
            message: ""
        };

        $scope.loginSubmit = function () {
            authService.userAuthentication($scope.loginData.userName, $scope.loginData.password).then(
function success(response) {
    // do successful stuff here  
    debugger;
    localStorage.setItem('userToken', response.data.access_token);
    localStorage.setItem('isAuth', true);
    var stateService = $injector.get('$state');
    stateService.go('home');
},
function err(response) {
    debugger;
    // response.data - find error message here
    // response.status - find error code here 
    // treat error here
    $scope.loginData.message = "Sai thông tin đăng nhập hoặc mật khẩu";

});
        }
    }]);
});
