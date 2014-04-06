'use strict';

angular.module('ngPlay')
  .controller('EchoController', function ($scope, EchoService) {
    $scope.echoVm = {
      request: 'the request',
      showResponse: false,
      responseInError: false,
      response: ''
    };

    $scope.requestEchoFromServer = function() {
      EchoService.pingServer($scope.echoVm.request).
        then(function(responseData) {
          $scope.echoVm.response = responseData;
          $scope.echoVm.showResponse = true;
          $scope.echoVm.responseInError = false;
        }, function() { // Error
          $scope.echoVm.response = 'ERROR!';
          $scope.echoVm.showResponse = true;
          $scope.echoVm.responseInError = true;
        });
    };

  });
