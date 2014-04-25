'use strict';

angular.module('ngPlay')
  .controller('NavBarController', function ($scope, $location, UserAccountService) {
    $scope.isActive = function(viewLocation) {
      return viewLocation === $location.path();
    };

    $scope.isLoggedIn = function() {
      return UserAccountService.isLoggedIn();
    }

  });
