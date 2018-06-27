//define(['angularAMD', 'angular-route'], function (angularAMD) {
//    debugger;
//   // var app = angular.module("MyApp", ["ngResource", "ui.router"]);

//    //app.config(config);

//   // config.$inject = ['$stateProvider', '$urlRouterProvider'];

//    //function config($stateProvider, $urlRouterProvider) {
//    //    debugger;
//    //    $stateProvider.state('base', {
//    //        url: '',
//    //        templateUrl: '/app/home/homeView.html',
//    //        abstract: true
//    //    })
//    //           .state('login', {
//    //               url: "/login",
//    //               templateUrl: "/app/login/loginView.html",
//    //               controller: "loginController"
//    //           })
//    //            .state('home', {
//    //                url: "/admin",
//    //                parent: 'base',
//    //                templateUrl: "/app/Admin/adminList.html",
//    //                controller: "homeController"
//    //            });
//    //    $urlRouterProvider.otherwise('/login');
//    //}
//    var app = angular.module('MyApp', ['ngRoute']);

//    app.config(['$routeProvider',function ($routeProvider) {
//        $routeProvider
//        .when('', angularAMD.route({
//            templateUrl: '/app/home/homeView.html',
//            controller: 'homeController',
//            controllerUrl: '/app/home/homeController.js',
//            abstract: true
//        }))
//        .when("/login", angularAMD.route({
//                           templateUrl: "/app/login/loginView.html",
//            controller: 'loginController',
//            controllerUrl: '/app/login/loginController.js'
//        }))
//                    .when("/home", angularAMD.route({
//                        templateUrl: "/app/home/homeView.html",
//                        controller: 'homeController',
//                        controllerUrl: '/app/home/homeController.js'
//                    }))
//        .otherwise({ redirectTo: "/login" });
//    }]);
////  //  app.config(config);
////  //  config.$inject = ['$stateProvider', '$urlRouterProvider'];
////    //app.config(configAuthentication);
////    //function configAuthentication($httpProvider) {
////    //    // Hàm kiểm tra tất cả các request trả về 
////    //    $httpProvider.interceptors.push(function ($q, $location) {
////    //        debugger;
////    //        return {
////    //            request: function (config) {

////    //                return config;
////    //            },
////    //            requestError: function (rejection) {

////    //                return $q.reject(rejection);
////    //            },
////    //            response: function (response) {
////    //                if (response.status == "401") {
////    //                    $location.path('/login');
////    //                }
////    //                //the same response/modified/or a new one need to be returned.
////    //                return response;
////    //            },
////    //            responseError: function (rejection) {

////    //                if (rejection.status == "401") {
////    //                    $location.path('/login');
////    //                }
////    //                return $q.reject(rejection);
////    //            }
////    //        };
////    //    })
////    //}
//    return angularAMD.bootstrap(app);
//});


//define([
//  'angular',
//  'angularAMD',
//  'angular-ui-router'
//], function (angular, angularAMD) {
//    'use strict';

//    var app = angular.module('MyApp', ['ui.router'])
//      .config(function ($stateProvider, $urlRouterProvider) {
//          $stateProvider
//            .state('base',
//            {
//                url: '',
//                views: {
//                    home:
//                angularAMD.route({
//                    url: '',
//                    templateUrl: '/app/home/homeView.html',
//                    controller: 'homeController',
//                    controllerUrl: '/app/home/homeController.js',
//                    abstract: true
//                })
//                }
//            }
//            )
//            .state('login',{
//                url: '/login',
//          views: {
//              login:
//                  angularAMD.route({

//                      templateUrl: '/app/login/loginView.html',
//                      controller: 'loginController',
//                      controllerUrl: '/app/login/loginController.js',

//                  })
//          }}
//            )
//               .state('home',{
//                   url: "/admin",
//                   view: {
//                       admin:
//                angularAMD.route({

//                    parent: 'base',
//                    templateUrl: "/app/Admin/adminList.html",
//                    controller: "homeController"
//                })
//                   }}
//            );

//          $urlRouterProvider.otherwise('/login');
//      });

//    angularAMD.bootstrap(app);
//    return app;
//});
define(['angularAMD', 'angular-ui-router'], function (angularAMD) {
    var app = angular.module('MyApp', ['ui.router'])
    .config
    (
      [
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {

            $stateProvider
                .state('base', angularAMD.route({
                    url: '',
                    templateUrl: '/app/home/homeView.html',
                    controller: 'homeController',
                    controllerUrl: '/app/home/homeController.js',
                    abstract: true
                }))
                .state('login', angularAMD.route({
                    url: '/login',
                    templateUrl: '/app/login/loginView.html',
                    controller: 'loginController',
                    controllerUrl: '/app/login/loginController.js',
                }))
                .state('home', angularAMD.route({
                    url: '/home',
                    parent: 'base',
                    templateUrl: '/app/home/DashBoard.html',
                    controller: 'homeController',
                    controllerUrl: '/app/home/homeController.js',
                }))
                // Khai báo đường dẫn users
                            .state('user_list', angularAMD.route({
                                url: '/user_list',
                                parent: 'base',
                                templateUrl: '/app/user/userList.html',
                                controller: 'userListController',
                                controllerUrl: '/app/user/userListController.js',
                            }))
                            .state('user_create', angularAMD.route({
                                url: '/user_create',
                                parent: 'base',
                                templateUrl: '/app/user/userCreate.html',
                                controller: 'userCreateController',
                                controllerUrl: '/app/user/userCreateController.js',
                            }))
                              .state('user_edit', angularAMD.route({
                                  url: '/user_edit/:id',
                                  parent: 'base',
                                  templateUrl: '/app/user/userEdit.html',
                                  controller: 'userEditController',
                                  controllerUrl: '/app/user/userEditController.js',
                              }))
            ;

            $urlRouterProvider.otherwise("/login");
        }
      ]
    )

    // Bootstap the application.
    angularAMD.bootstrap(app);
    // Return the application.
    return app;
});