﻿(function (app) {
    'use strict';

    app.controller('changeProfileController', ['$scope', 'apiService', 'notificationService', '$modal', '$rootScope', '$http',
    function countryCreateController($scope, apiService, notificationService, $modal, $rootScope, $http) {
        $scope.ApplicationUser = {
            UserName: null,
            Password: null,
            ConfirmPassword: null,
            LastName: null,
            FirstName: null,
            Email: null,
        }
        $scope.dataErorr = false;
        $scope.UpdateUser =
        function UpdateUser() {
            if (!$scope.dataErorr) {

                //$scope.product.MoreImages = JSON.stringify($scope.moreImages)
                apiService.post('api/ApplicationUser/Update', $scope.ApplicationUser,
                    function (result) {
                        notificationService.displaySuccess(result.data.UserName + ' đã được cập nhật.');

                        debugger;
                        $rootScope.modalClose();
                        //  $state.go('country_list');
                    }, function (error) {
                        notificationService.displayError('Cập nhật không thành công.');
                    });
            }
        }
        $scope.setFiles =
function setFiles(element) {
    debugger;
    var files = event.target.files;
    debugger;

    if (event.target.files[0] != undefined && event.target.files[0] != null) {
        var reader = new FileReader();
        reader.onload = function (loadEvent) {
            $scope.country.FileUpLoad = loadEvent.target.result.split(",")[1];

        }
        $scope.country.FileUploadName = event.target.files[0].name;
        $scope.country.FileUploadType = event.target.files[0].type;
        reader.readAsDataURL(event.target.files[0]);
    }
    else {
        $scope.country.FileUpLoad = null;
        $scope.country.FileUploadName = null;
        $scope.country.FileUploadType = null;
    }

}
        function loadDetail() {
            apiService.get('/api/ApplicationUser/detail?userName=' + localStorage.getItem("userName"), null,
            function (result) {
                debugger;
                $scope.ApplicationUser = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }
        $scope.Closemodal = function () {
            debugger;
            $rootScope.modalClose();
        }
        loadDetail();
    }]);

})(angular.module('MyApp'));
