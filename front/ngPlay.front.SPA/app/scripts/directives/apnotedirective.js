'use strict';

angular.module('ngPlay')
  .directive('apNoteDirective', function () {
    return {
      templateUrl: 'templates/directives/note.html',
      restrict: 'A',
      replace: true,
      scope: {
        note: '=',
        controllerDeleteNote: "&"
      },
      link : function(scope) {
        scope.working = false;
        scope.deleted = false;

        scope.deleteNote = function() {
          scope.working = true;

          scope.controllerDeleteNote(scope.note);
        }
      }
    };
  });
