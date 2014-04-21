'use strict';

angular.module('ngPlay')
  .controller('RegisterController', function ($scope, UserAccountService) {
    $scope.registerVm = { };

    $scope.registerVm.userData = {
      name : '',
      email : '',
      password : '',
      confirmPassword : ''
    };

    $scope.registerVm.working = false;

    $scope.registerVm.isRegistered = false;

    $scope.registerVm.errorOccurred = false;
    $scope.registerVm.errorInfo = '';

    $scope.registerVm.registerUser = function() {
      $scope.registerVm.working = true;

      UserAccountService.registerUser($scope.registerVm.userData).then(
        function (data) {
          $scope.registerVm.isRegistered = true;
          $scope.registerVm.errorOccurred = false;
          $scope.registerVm.working = false;

        }, function (data) {
          $scope.registerVm.errorOccurred = true;
          $scope.registerVm.errorInfo = data;
          $scope.registerVm.working = false;
        });
    };
  });
