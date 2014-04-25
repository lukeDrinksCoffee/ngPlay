'use strict';

angular.module('ngPlay')
  .service('UserAccountService', function UserAccountService($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

    var serviceInstance = {

      accessToken : '',

      isLoggedIn : function() {
        return serviceInstance.accessToken != '';
      },

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
      },

      loginUser : function(userData) {
        var loginUrl = AppSettings.baseUrl + '/Token';

        if (!userData.grant_type) {
          userData.grant_type = "password";
        }

        var deferred = $q.defer();
        $http({
          method: 'POST',
          url: loginUrl,
          data: userData
        }).success(function (data, status, headers, cfg) {
          serviceInstance.accessToken = data.access_token;
          $http.defaults.headers.common.Authorization = 'Bearer ' + serviceInstance.accessToken;
          console.log(data);
          deferred.resolve(data);

        }).error(function (err, status) {
          console.log(err);
          deferred.reject(status);
        });

        return deferred.promise;
      },

      logoutUser : function() {
        serviceInstance.accessToken = '';
        delete $http.defaults.headers.common.Authorization;
      }

    };

    return serviceInstance;

  });
