(function (app) {

	app.controller('loginController', ['$scope', '$injector', '$location','authService',
        function ($scope, $injector, $localtion,authService) {
        	debugger;
        	$scope.loginData = {
        		userName: "",
        		password: ""
        	};

        	$scope.loginSubmit = function () {
        		authService.userAuthentication($scope.loginData.userName, $scope.loginData.password).then(function (response) {
        			if (response != null && response.data.error != undefined) {
        			//	notificationService.displayError(response.data.error_description);
        			}
        			else {
        				debugger;
        				var stateService = $injector.get('$state');
        				stateService.go('home');
        			}
        		});
        	}
        }]);
})
(angular.module('MyApp'), []);