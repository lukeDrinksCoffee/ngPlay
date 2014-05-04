'use strict';

angular.module('ngPlay')
  .directive('apNoteDirective', function () {
    return {
      templateUrl: 'templates/directives/note.html',
      restrict: 'A',
      replace: true,
      scope: {
        note: '=',
        controllerDeleteNote: "&",
        controllerUpdateNote: "&"
      },
      link : function(scope) {
        scope.working = false;
        scope.deleted = false;
        scope.editing = false;
        scope.disableCancel = true;
        scope.errorOccurred = false;

        scope.editNoteCopy = { };

        scope.edit = function() {
          scope.editNoteCopy.id = scope.note.id;
          scope.editNoteCopy.title = scope.note.title;
          scope.editNoteCopy.content = scope.note.content;

          scope.working = false;
          scope.editing = true;
        }

        scope.cancelEdit = function() {
          scope.working = false;
          scope.errorOccurred = false;
          scope.editing = false;
        }

        scope.updateNote = function() {
          scope.working = true;
          scope.errorOccurred = false;
          scope.disableCancel = true;
          scope.controllerUpdateNote({ noteToUpdate: scope.editNoteCopy }).then(
            function() {
              scope.working = false;
              scope.editing = false;
              scope.disableCancel = false;
            },
            function() {
              scope.errorOccurred = true;
              scope.working = false;
              scope.disableCancel = false;
            }
          )
        }

        scope.deleteNote = function() {
          scope.working = true;
          scope.controllerDeleteNote(scope.note);
        }

      }
    };
  });
