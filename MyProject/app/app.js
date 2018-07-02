//define(['angularAMD', 'angular-route'], function (angularAMD) {
//    debugger;
//   // var app = angular.module("MyApp", ["ngResource", "ui.router"]);

//    //app.config(config);

//   // config.$inject = ['$stateProvider', '$urlRouterProvider'];

//    //function config($stateProvider, $urlRouterProvider) {
//    //    debugger;
//    //    $stateProvider.state('base', {
//    //        url: '',
//    //        templateUrl: '/app/modules/home/homeView.html',
//    //        abstract: true
//    //    })
//    //           .state('login', {
//    //               url: "/login",
//    //               templateUrl: "/app/modules/login/loginView.html",
//    //               controller: "loginController"
//    //           })
//    //            .state('home', {
//    //                url: "/admin",
//    //                parent: 'base',
//    //                templateUrl: "/app/modules/Admin/adminList.html",
//    //                controller: "homeController"
//    //            });
//    //    $urlRouterProvider.otherwise('/login');
//    //}
//    var app = angular.module('MyApp', ['ngRoute']);

//    app.config(['$routeProvider',function ($routeProvider) {
//        $routeProvider
//        .when('', angularAMD.route({
//            templateUrl: '/app/modules/home/homeView.html',
//            controller: 'homeController',
//            controllerUrl: '/app/modules/home/homeController.js',
//            abstract: true
//        }))
//        .when("/login", angularAMD.route({
//                           templateUrl: "/app/modules/login/loginView.html",
//            controller: 'loginController',
//            controllerUrl: '/app/modules/login/loginController.js'
//        }))
//                    .when("/home", angularAMD.route({
//                        templateUrl: "/app/modules/home/homeView.html",
//                        controller: 'homeController',
//                        controllerUrl: '/app/modules/home/homeController.js'
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
//                    templateUrl: '/app/modules/home/homeView.html',
//                    controller: 'homeController',
//                    controllerUrl: '/app/modules/home/homeController.js',
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

//                      templateUrl: '/app/modules/login/loginView.html',
//                      controller: 'loginController',
//                      controllerUrl: '/app/modules/login/loginController.js',

//                  })
//          }}
//            )
//               .state('home',{
//                   url: "/admin",
//                   view: {
//                       admin:
//                angularAMD.route({

//                    parent: 'base',
//                    templateUrl: "/app/modules/Admin/adminList.html",
//                    controller: "homeController"
//                })
//                   }}
//            );

//          $urlRouterProvider.otherwise('/login');
//      });

//    angularAMD.bootstrap(app);
//    return app;
//});
define(['angularAMD', 'angular-ui-router', 'bootstrapUi'], function (angularAMD) {
    var app = angular.module('MyApp', ['ui.router', 'ui.bootstrap'])
    .config
    (
      [
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {

            $stateProvider
                .state('base', angularAMD.route({
                    url: '',
                    templateUrl: '/app/modules/home/homeView.html',
                    controller: 'homeController',
                    controllerUrl: '/app/modules/home/homeController.js',
                    abstract: true
                }))
                .state('login', angularAMD.route({
                    url: '/login',
                    templateUrl: '/app/modules/login/loginView.html',
                    controller: 'loginController',
                    controllerUrl: '/app/modules/login/loginController.js',
                }))
                .state('home', angularAMD.route({
                    url: '/home',
                    parent: 'base',
                    templateUrl: '/app/modules/home/DashBoard.html',
                    controller: 'homeController',
                    controllerUrl: '/app/modules/home/homeController.js',
                }))
                // Khai báo đường dẫn users
                            .state('user_list', angularAMD.route({
                                url: '/user_list',
                                parent: 'base',
                                templateUrl: '/app/modules/user/userList.html',
                                controller: 'userListController',
                                controllerUrl: '/app/modules/user/userListController.js',
                            }))
                            .state('user_create', angularAMD.route({
                                url: '/user_create',
                                parent: 'base',
                                templateUrl: '/app/modules/user/userCreate.html',
                                controller: 'userCreateController',
                                controllerUrl: '/app/modules/user/userCreateController.js',
                            }))
                              .state('user_edit', angularAMD.route({
                                  url: '/user_edit/:id',
                                  parent: 'base',
                                  templateUrl: '/app/modules/user/userEdit.html',
                                  controller: 'userEditController',
                                  controllerUrl: '/app/modules/user/userEditController.js',
                              }))
            // Khai báo đường dẫn countrys
                .state('country_list', angularAMD.route({
                    url: '/country_list',
                    parent: 'base',
                    templateUrl: '/app/modules/country/countryList.html',
                    controller: 'countryListController',
                    controllerUrl: '/app/modules/country/countryListController.js',
                }))
                            .state('country_create', angularAMD.route({
                                url: '/country_create',
                                parent: 'base',
                                templateUrl: '/app/modules/country/countryCreate.html',
                                controller: 'countryCreateController',
                                controllerUrl: '/app/modules/country/countryCreateController.js',
                            }))
                              .state('country_edit', angularAMD.route({
                                  url: '/country_edit/:id',
                                  parent: 'base',
                                  templateUrl: '/app/modules/country/countryEdit.html',
                                  controller: 'countryEditController',
                                  controllerUrl: '/app/modules/country/countryEditController.js',
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