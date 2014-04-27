'use strict';

angular.module('ngPlay')
  .directive('apNoteDirective', function () {
    return {
      templateUrl: 'templates/directives/note.html',
      restrict: 'A',
      replace: true,
      scope: {
        note: '='
      }
    };
  });
