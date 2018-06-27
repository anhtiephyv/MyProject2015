define(['angularAMD', 'angular-ui-router'], function (angularAMD) {
  var app = angular.module('App', ['ui.router']);
  app.config
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
        );
      }
    ]
  );
  app.controller
  (
    'AppController',
    [
      '$scope', '$rootScope', '$location',
      function controller($scope, $rootScope, $location) {
      }
    ]
  );
  // Bootstap the application.
  angularAMD.bootstrap(app);
  // Return the application.
  return app;
});