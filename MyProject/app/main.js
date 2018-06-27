require.config({

    baseUrl: "Content/js",
    paths: {
       
        'angular': 'angular',
        'angular-route': 'angular-route',
        'angularAMD': 'angularAMD',
        'angular-ui-router': 'angular-ui-router',
        'ngload': 'ngload',
        'restangular': 'restangular',
        'underscore': 'underscore',
        'app': '../../app',
        'authService': '../../common/authService',
        'tokenAuth': '../../common/tokenAuth'

    },
    // Đoạn này viết các thằng con phải phụ thuộc vào các js khác để có thể chạy được, đoạn này load trước 
    shim: {
        angular: {
            exports: 'angular'
        },
        'angularAMD': ['angular'],
        'angular-route': ['angular'],
        'angular-ui-router': ['angular'],
        'ngload': ['angularAMD'],
        'restangular': ['angular', 'underscore'],

        "app": {
            deps: ['angular', 'angular-ui-router']
        },
        "authService": ['app'],
        "tokenAuth": ['app'],
    },
    //
    //deps: ['../../app']
});
require(['app', 'authService', 'tokenAuth'], function (app, authService) {
   // console.log('app.js, services.js and controllers.js files loaded');
//    app.init();
});

