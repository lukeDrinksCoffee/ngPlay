'use strict';

angular.module('ngPlay')
  .controller('NotesController', function ($scope, $q, NotesService) {
    $scope.notes = [ ];

    $scope.error = false;
    $scope.notesLoaded = false;

    $scope.init = function() {
      NotesService.getNotes().then(
        function(data) {
          $scope.notes = data;
          $scope.notesLoaded = true;
        },
        function() {
          $scope.error = true;
        }
      );

      NotesService.subscribeNoteAdded(function (newNote) {
        $scope.notes.push(newNote);
      });
    };

    $scope.createNote = function(note) {
      NotesService.createNote(note).then(function(createdNote) {
        $scope.notes.push(createdNote)
      });
    };

    $scope.updateNote = function(note) {
      var deferred = $q.defer();

      NotesService.updateNote(note).then(
        function() {
          // Replace note old -> new
          var i;
          for(i=0; i< $scope.notes.length; i++) {
            if ($scope.notes[i].id === note.id) {
              $scope.notes[i].title = note.title;
              $scope.notes[i].content = note.content;
            }
          }

          deferred.resolve();
        },
        function() {
          deferred.reject();
        }
      )

      return deferred.promise;
    };

    $scope.deleteNote = function(note) {
      NotesService.deleteNote(note.id).then(function() {
        var i = $scope.notes.indexOf(note);
        $scope.notes.splice(i, 1);  //removes 1 element at position i
      });
    }

    $scope.init();

  });
