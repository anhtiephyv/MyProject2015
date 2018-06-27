define(['app'], function (app) {
    'use strict';
    var app = angular.module('MyApp', []);
  //  app.factory('tokenAuth', tokenAuth);
    app.factory('authData', [function () {
        var authDataFactory = {};
        // Khởi tạo thông tin authen
        var authentication = {
            IsAuthenticated: false,
            userName: ""
        };
        authDataFactory.authenticationData = authentication;

        return authDataFactory;
    }]);
   // tokenAuth.$inject = ['$http'];
    app.service('authenticationService', ['$http', '$q', '$window', 'localStorageService', 'authData',
function ($http, $q, $window, localStorageService, authData) {
    var tokenInfo;

    this.setTokenInfo = function (data) {
        tokenInfo = data;
        localStorageService.set("TokenInfo", JSON.stringify(tokenInfo));
    }

    this.getTokenInfo = function () {
        return tokenInfo;
    }

    this.removeToken = function () {
        tokenInfo = null;
        localStorageService.set("TokenInfo", null);
    }

    this.init = function () {
        var tokenInfo = localStorageService.get("TokenInfo");
        if (tokenInfo) {
            tokenInfo = JSON.parse(tokenInfo);
            authData.authenticationData.IsAuthenticated = true;
            authData.authenticationData.userName = tokenInfo.userName;
            authData.authenticationData.accessToken = tokenInfo.accessToken;

        }
    }

    this.setHeader = function () {
        delete $http.defaults.headers.common['X-Requested-With'];
        if ((authData.authenticationData != undefined) && (authData.authenticationData.accessToken != undefined) && (authData.authenticationData.accessToken != null) && (authData.authenticationData.accessToken != "")) {
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.authenticationData.accessToken;
            $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
        }
    }

    this.validateRequest = function () {
        var url = 'api/home/TestMethod';
        var deferred = $q.defer();
        $http.get(url).then(function () {
            deferred.resolve(null);
        }, function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    }

    this.init();
}
    ]);

})


