'use strict';

angular.module('ngPlay')
  .controller('CreateNoteModalController', function ($scope, $modal) {

    $scope.open = function () {
      $modal.open({
        templateUrl: 'templates/createnote.html',
        controller: CreateNoteModalInstanceController
      });
    };

  });


var CreateNoteModalInstanceController = function ($scope, $modalInstance, NotesService) {
  $scope.note = {
    title: '',
    content: ''
  };

  $scope.working = false;
  $scope.createFailed = false;

  $scope.createNote = function () {
    $scope.createFailed = false;
    $scope.working = true;

    NotesService.createNote($scope.note).then(
      function() {
        $modalInstance.close();
      },
      function() {
        $scope.createFailed = true;
        $scope.working = false;
      }
    )
  };

  $scope.cancel = function () {
    $modalInstance.dismiss('cancel');
  };
};
