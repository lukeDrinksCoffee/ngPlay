'use strict';

angular.module('ngPlay')
  .directive('apNoteDirective', function (NotesService) {
    return {
      templateUrl: 'templates/directives/note.html',
      restrict: 'A',
      replace: true,
      scope: {
        note: '='
      },
      link : function(scope) {
        var theScope = scope;

        scope.working = false;
        scope.deleted = false;

        scope.deleteNote = function() {
          theScope.working = true;

          NotesService.deleteNote(theScope.note.id).then(
            function() {
              theScope.working = false;
              theScope.deleted = true;
            },
            function() {
              theScope.working = false;
            }
          )
        }
      }
    };
  });
