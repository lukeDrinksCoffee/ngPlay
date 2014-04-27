'use strict';

angular.module('ngPlay')
  .controller('LoginController', function ($scope, UserAccountService) {

    $scope.userData = {
      userName: '',
      password: ''
    };

    $scope.working = false;
    $scope.loginFailed = false;
    $scope.isLoggedIn = UserAccountService.isLoggedIn();

    $scope.loginUser = function() {
      $scope.loginFailed = false;
      $scope.working = true;
      UserAccountService.loginUser($scope.userData).then(function (data) {
        $scope.isLoggedIn = true;
        $scope.loginFailed = false;
        $scope.userName = data.userName;
        $scope.working = false;

      }, function (error, status) {
        $scope.isLoggedIn = false;
        $scope.loginFailed = true;
        console.log(status);
        $scope.working = false;
      });
    }

  });
