'use strict';

angular
  .module('ngPlay', [
    'ngCookies',
    'ngResource',
    'ngSanitize',
    'ngRoute'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/echo', {
        templateUrl: 'views/echo.html',
        controller: 'EchoController'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
