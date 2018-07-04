(function (app) {
    'use strict';
   
    app.controller('countryCreateController', ['$scope', 'apiService', 'notificationService', '$filter',
    function countryCreateController($scope, apiService, notificationService, $filter) {
        $scope.country = {
            CountryName:"",
            CountryCronyms: "",
            CountryFlag: null,
            CountryStatus: "1",
            FileUpLoad: null,
            FileUploadName: null,
            FileType:null,
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.AddCountry = 
        function AddCountry() {
            debugger;
            //$scope.product.MoreImages = JSON.stringify($scope.moreImages)
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })

            }
            finder.popup();
        }
        loadProductCategory();
    }]);
})(angular.module('MyApp'));
