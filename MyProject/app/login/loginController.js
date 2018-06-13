(function (app) {
	debugger;
	app.controller('loginController', ['$scope', 
        function ($scope, loginService, $injector, notificationService) {
        	debugger;
        	$scope.loginData = {
        		userName: "",
        		password: ""
        	};

        	//$scope.loginSubmit = function () {
        	//	loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
        	//		if (response != null && response.data.error != undefined) {
        	//			notificationService.displayError(response.data.error_description);
        	//		}
        	//		else {
        	//			var stateService = $injector.get('$state');
        	//			stateService.go('home');
        	//		}
        	//	});
        	//}
        }]);
})
(angular.module('MyApp'), []);