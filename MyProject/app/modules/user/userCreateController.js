(function (app) {
    'use strict';

    app.controller('userCreateController', ['$scope', 'apiService', 'notificationService', '$filter', '$injector', '$rootScope',
    function countryCreateController($scope, apiService, notificationService, $filter, $injector, $rootScope) {
        $scope.User = {
            UserName: null,
            FirstName: null,
            LastName: null,
            Email: null,
            Phone: null,
            Address: null,
        }
        $scope.codeExist = false;
        $scope.dataErorr = false;
        $scope.AddUser =
        function AddUser() {
            if (!$scope.dataErorr) {

                //$scope.product.MoreImages = JSON.stringify($scope.moreImages)
                apiService.post('api/users/create', $scope.User,
                    function (result) {
                        notificationService.displaySuccess(result.data.UserName + ' đã được thêm mới.');

                        debugger;
                        $rootScope.clearSearch();
                        $rootScope.modalClose();
                        //  $state.go('country_list');
                    }, function (error) {
                        notificationService.displayError('Thêm mới không thành công.');
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
        $scope.checkcodeExist = function (element) {
            apiService.get('api/Country/checkcodeExist?CountryCode='+element.value,null,
            function (result) {
                debugger;
                if (result.data) {
                    //      element.focus();
                    $scope.codeExist = result.data;
                    $scope.dataErorr = true;
                }
                else
                {
                    $scope.codeExist = result.data;
                    $scope.dataErorr = false;
                }
            }, function (error) {
                notificationService.displayError(error);
            });
            debugger;

        }

        $scope.Closemodal = function () {
            debugger;
            $rootScope.modalClose();
        }
        $scope.demoOptions = {
            title: 'Phân quyền các nước cho người dùng',
            filterPlaceHolder: 'Nhập vào đây để lọc các nước.',
            labelAll: 'Tất cả nước',
            labelSelected: 'Nước đã chọn',
            helpMessage: ' Chọn vào tên nước để chuyển đổi',
            /* angular will use this to filter your lists */
            orderProperty: 'name',
            /* this contains the initial list of all items (i.e. the left side) */
            items: $rootScope.listItem,
            /* this list should be initialized as empty or with any pre-selected items */
            selectedItems: []
        };
    

    }]);

})(angular.module('MyApp'));
