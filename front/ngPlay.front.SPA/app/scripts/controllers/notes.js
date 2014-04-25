'use strict';

angular.module('ngPlay')
  .controller('NotesController', function ($scope, NotesService) {
    $scope.notes = {};

    $scope.getNotes = function() {
      NotesService.getNotes().then(
        function (data) {
          $scope.notes = data;
        },
        function () {

        }
      )
    }

  });
