'use strict';

angular.module('ngPlay')
  .service('NotesService', function($http, $q, AppSettings) {
    // AngularJS will instantiate a singleton by calling "new" on this function

    var noteUrl = AppSettings.webApiUrl + '/Notes';

    var noteAddedCallBacks = [];

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

      createNote : function(note) {
        var deferred = $q.defer();

        $http.post(noteUrl, note).
          success(function(createdNote) {
            deferred.resolve(createdNote);

            noteAddedCallBacks.forEach(function(callback) {
              callback(createdNote);
            })
          }).
          error(function() {
            deferred.reject();
          });

        return deferred.promise;
      },

      updateNote : function(note) {
        var deferred = $q.defer();

        $http.put(noteUrl, JSON.stringify(note)).
          success(function() {
            deferred.resolve();
          }).
          error(function() {
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
      },

      subscribeNoteAdded : function(callback) {
        noteAddedCallBacks.push(callback);
      }

    };

    return serviceInstance;
  });
