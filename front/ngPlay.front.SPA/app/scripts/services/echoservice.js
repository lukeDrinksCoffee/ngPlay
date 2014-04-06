'use strict';

angular.module('ngPlay')
  .service('EchoService', function($http, $q) {
    // AngularJS will instantiate a singleton by calling "new" on this function

      var serviceInstance = {
        pingServer : function(value) {
          var deferred = $q.defer();

          $http.get('http://localhost:51995/api/echo?value=' + value).
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
