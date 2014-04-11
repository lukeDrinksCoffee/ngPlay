'use strict';

angular.
  module('ngPlay', [
    'ngCookies',
    'ngResource',
    'ngSanitize',
    'ngRoute'
  ]).
  constant('AppSettings', {
    webApiUrl: 'http://localhost:51995/api'
  }).
  config(function ($routeProvider) {
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
