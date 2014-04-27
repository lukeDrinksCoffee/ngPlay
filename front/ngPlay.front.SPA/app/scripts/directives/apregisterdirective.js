'use strict';

angular.module('ngPlay')
  .directive('apRegisterDirective', function () {
    return {
      templateUrl: 'templates/directives/register.html',
      restrict: 'A',
      replace: true,
      scope: { },
      controller: 'RegisterController'
    };
  });
