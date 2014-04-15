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

    $scope.registerVm.isRegistered = false;

    $scope.registerVm.errorOccurred = false;
    $scope.registerVm.errorInfo = '';

    $scope.registerVm.registerUser = function() {
      UserAccountService.registerUser($scope.registerVm.userData).then(
        function(data) {
          $scope.registerVm.isRegistered = true;
          $scope.registerVm.errorOccurred = false;

      }, function(data) {
          $scope.registerVm.errorOccurred = true;
          $scope.registerVm.errorInfo = data;

      });

    };

  });
