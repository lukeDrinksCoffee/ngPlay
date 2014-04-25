'use strict';

angular.module('ngPlay')
  .directive('apLoginDirective', function () {
    return {
      templateUrl: 'templates/directives/login.html',
      restrict: 'A',
      replace: true,
      scope: { },
      controller: 'LoginController'
    };
  });
