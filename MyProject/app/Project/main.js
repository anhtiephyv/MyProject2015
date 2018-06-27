require.config({
    baseUrl: "",
    paths: {
      'angular': 'angular',
      'angular-route': 'angular-route',
      'angular-ui-router': 'angular-ui-router',
      'angularAMD': 'angularAMD',
      'ngload': 'ngload',
      'restangular': 'restangular',
      'underscore': 'underscore'
    },
    shim: {
        'angularAMD': ['angular'],
        'ngload': ['angularAMD'],
        'angular-route': ['angular'],
        'angular-ui-router': ['angular'],
        'restangular': ['angular', 'underscore']
    },
    deps: ['app']
});