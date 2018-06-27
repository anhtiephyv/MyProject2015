define(['app', 'restangular'], function (app) {
  var mod = angular.module
  (
    'Home',
    [
      'restangular'
    ]
  )
  .config
  (
    [
      'RestangularProvider',
      function(RestangularProvider) {
        RestangularProvider.setBaseUrl('/Api');
      }
    ]
  )
  .controller
  (
    'HomeController',
    [
      '$scope', 'Restangular',
      function controller($scope, Restangular) {
        $scope.title = 'Home ';
        var test = Restangular.one('test');
      }
    ]
  );
});
