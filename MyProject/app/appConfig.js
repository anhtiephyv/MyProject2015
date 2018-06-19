

//(function () {
//	angular.module('myProject',
//        ['shyApp.products',
//         'shyApp.application_groups',
//         'shyApp.product_categories',
//         'shyApp.application_roles',
//         'shyApp.application_users',
//           'shyApp.statistics',
//         'shyApp.common'])
//        .config(config)
//        .config(configAuthentication);

//	config.$inject = ['$stateProvider', '$urlRouterProvider'];
//	function configAuthentication($httpProvider) {
//		$httpProvider.interceptors.push(function ($q, $location) {
//			return {
//				request: function (config) {

//					return config;
//				},
//				requestError: function (rejection) {

//					return $q.reject(rejection);
//				},
//				response: function (response) {
//					if (response.status == "401") {
//						$location.path('/login');
//					}
//					//the same response/modified/or a new one need to be returned.
//					return response;
//				},
//				responseError: function (rejection) {

//					if (rejection.status == "401") {
//						$location.path('/login');
//					}
//					return $q.reject(rejection);
//				}
//			};
//		});
//	}
//})();
var app = angular.module("MyApp", ["ngResource", "ui.router"]);

app.config(config);
app.config(configAuthentication);
config.$inject = ['$stateProvider', '$urlRouterProvider'];

function config($stateProvider, $urlRouterProvider) {
	debugger;
	$stateProvider.state('base', {
		url: '',
		templateUrl: '/app/index.html',
		abstract: true
	})
           .state('login', {
            	url: "/login",
            	templateUrl: "/app/login/loginView.html",
            	controller: "loginController"
            })
            .state('home', {
            	url: "/admin",
            	parent: 'base',
            	templateUrl: "/app/home/homeView.html",
            	controller: "homeController"
            });
		$urlRouterProvider.otherwise('/login');
}
function configAuthentication($httpProvider) {
	$httpProvider.interceptors.push(function ($q, $location) {
		debugger;
        return {
            request: function (config) {

                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    })}
    
