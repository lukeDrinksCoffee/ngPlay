'use strict';

angular.module('ngPlay')
  .service('NotesService', function($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

    var noteUrl = AppSettings.webApiUrl + '/Notes'

    var serviceInstance = {
      getNotes : function() {
        var deferred = $q.defer();

        $http.get(noteUrl).
          success(function(data /*, status, headers, config */ ) {
            deferred.resolve(data);
          }).
          error(function( data, status, headers, config ) {
            console.log(data);
            deferred.reject();
          });

        return deferred.promise;
      },

      deleteNote : function(noteId) {
        var deferred = $q.defer();

        $http.delete(noteUrl + '/' + noteId).
          success(function() {
            deferred.resolve();
          }).
          error(function() {
          deferred.reject();
        });

        return deferred.promise;
      }
    };

    return serviceInstance;
  });
