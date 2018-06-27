
(function (app) {
    app.controller('homeController', ['$scope', '$injector', '$location',
        function ($scope, $injector, $location) {
            if (!localStorage.isAuth)
            {
                var stateService = $injector.get('$state');
                stateService.go('login');
            }
        }]);
})
	(angular.module('MyApp'));