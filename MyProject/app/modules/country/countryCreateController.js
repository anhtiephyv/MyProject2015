(function (app) {
    'use strict';
   
    app.controller('countryCreateController', ['$scope', 'apiService', 'notificationService', '$filter', '$injector', '$rootScope', 
    function countryCreateController($scope, apiService, notificationService, $filter, $injector, $rootScope) {
        $scope.country = {
            CountryName:"",
            CountryCronyms: "",
            CountryFlag: null,
            CountryStatus: "1",
            FileUpLoad: null,
            FileUploadName: null,
            FileType:null,
        }
        $scope.AddCountry = 
        function AddCountry() {
            debugger;
            //$scope.product.MoreImages = JSON.stringify($scope.moreImages)
            apiService.post('api/country/create', $scope.country,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');

                    debugger;
                    $rootScope.clearSearch();
                    $rootScope.modalClose();
                  //  $state.go('country_list');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        $scope.closeModal =
function closeModal() {

}
    }]);
})(angular.module('MyApp'));
