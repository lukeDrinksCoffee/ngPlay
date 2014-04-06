'use strict';

angular.module('ngPlay')
    .controller('NavBarController', function ($scope, $location) {
        $scope.isActive = function(viewLocation) {
            return viewLocation === $location.path();
        };
    });
