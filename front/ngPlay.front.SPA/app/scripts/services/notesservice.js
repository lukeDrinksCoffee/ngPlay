'use strict';

angular.module('ngPlay')
  .service('NotesService', function($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

    var serviceInstance = {
      getNotes : function() {
        var deferred = $q.defer();

        $http.get(AppSettings.webApiUrl + '/Notes').
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
