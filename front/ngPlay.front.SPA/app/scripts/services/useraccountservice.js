'use strict';

angular.module('ngPlay')
  .service('UserAccountService', function UserAccountService($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

    var serviceInstance = {
      registerUser : function(userData) {

        var registrationUrl = AppSettings.webApiUrl + '/Account/Register';

        var deferred = $q.defer();

        $http.post(registrationUrl, userData).
          success(function(data /*, status, headers, config */ ) {
            deferred.resolve(data);
          }).
          error(function(data, status, headers, config) {
            console.log(data);

            deferred.reject(data);
          });

        return deferred.promise;
      }
    };

    return serviceInstance;

  });
