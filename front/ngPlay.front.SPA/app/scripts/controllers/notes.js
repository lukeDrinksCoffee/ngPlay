'use strict';

angular.module('ngPlay')
  .controller('NotesController', function ($scope, NotesService) {
    $scope.notes = [
//      { id: 1, title: 'Note 1', content: 'some content'},
//      { id: 2, title: 'Note 2', content: 'some more content'},
//      { id: 3, title: 'Note 3', content: 'some other content'},
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

    $scope.deleteNote = function(note) {
      NotesService.deleteNote(note.id).then(function() {
        var i = $scope.notes.indexOf(note);
        $scope.notes.splice(i, 1);  //removes 1 element at position i
      });
    }

    $scope.init();

  });
