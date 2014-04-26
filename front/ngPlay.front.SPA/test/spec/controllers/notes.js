'use strict';

describe('Controller: NotesCtrl', function () {

  // load the controller's module
  beforeEach(module('ngPlay'));

  var NotesCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    NotesCtrl = $controller('NotesController', {
      $scope: scope
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    // TODO LEO implement
  });
});
