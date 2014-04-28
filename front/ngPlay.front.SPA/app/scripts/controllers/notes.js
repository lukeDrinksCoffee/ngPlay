'use strict';

angular.module('ngPlay')
  .controller('NotesController', function ($scope, NotesService) {
    $scope.notes = [
      // { title: 'Note 1', content: 'some content'},
      // { title: 'Note 2', content: 'some more content'},
      // { title: 'Note 3', content: 'some other content'},
    ];

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
      )
    };

    $scope.deleteNote = function(noteId) {
      return NotesService.deleteNote(noteId);
    }

    $scope.init();

  });
