'use strict';

angular.module('ngPlay')
  .service('EchoService', function($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

      var serviceInstance = {
        pingServer : function(value) {
          var deferred = $q.defer();

          $http.get(AppSettings.webApiUrl + '/echo?value=' + value).
            success(function(data /*, status, headers, config */ ) {
              deferred.resolve(data);
            }).
            error(function( /* data, status, headers, config */ ) {
              deferred.reject();
            });

          return deferred.promise;
        }
      };

      return serviceInstance;
  });
