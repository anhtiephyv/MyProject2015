define(['angularAMD', 'angular-ui-router'], function (angularAMD) {
  var app = angular.module('App', ['ui.router'])
  .config
  (
    [
      '$stateProvider', '$urlRouterProvider',
      function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/home");
        $stateProvider.state(
          'home',
          angularAMD.route({
            url: '/home',
            templateUrl: 'home.html',
            controller: 'HomeController',
            controllerUrl: 'ngload!home.js'
            }
          )
        ).state(
          'home2',
          angularAMD.route({
            url: '/home2',
            templateUrl: 'home2.html',
            controller: 'HomeController',
            controllerUrl: 'ngload!home.js'
            }
          )
        );
      }
    ]
  )
  .controller
  (
    'AppController',
    [
      '$scope', '$rootScope', '$location',
      function controller($scope, $rootScope, $location) {
        $scope.title = 'App';
      }
    ]
  );
  // Bootstap the application.
  angularAMD.bootstrap(app);
  // Return the application.
  return app;
});