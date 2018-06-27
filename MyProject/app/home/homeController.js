
(function (app) {
    app.controller('homeController', ['$scope', '$injector', '$location',
        function ($scope, $injector, $location) {
            if(1==1)
            {
                var stateService = $injector.get('$state');
                stateService.go('login');
            }
        }]);
})
	(angular.module('MyApp'), []);