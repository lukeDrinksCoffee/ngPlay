'use strict';

describe('Controller: EchoController', function () {

  // load the controller's module
  beforeEach(module('ngPlay'));

  var succeedPromise, echoCtrl, scope, echoSvc;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope, $q, EchoService) {
    scope = $rootScope.$new();

    echoSvc = EchoService;

    spyOn(echoSvc, "pingServer").
      andCallFake(function(value) {
        if (succeedPromise) {
          return $q.when(
            {
              echo: '' + value + ' : -the time-'
            });
        }
        else {
          return $q.reject();
        }
      });

    echoCtrl = $controller('EchoController', {
      $scope: scope,
      EchoService: echoSvc
    });
  }));

  it('should define a view model with 4 properties', function () {
    expect(scope.echoVm);
    expect(scope.echoVm.request);
    expect(scope.echoVm.response);
    expect(scope.echoVm.responseInError);
    expect(scope.echoVm.showResponse);
  });

  it('should set the view model appropriately on error', function() {
    succeedPromise = false;

    scope.requestEchoFromServer('Hello World');
    scope.$digest();

    expect(echoSvc.pingServer).toHaveBeenCalled();
    expect(scope.echoVm.response).not.toBe(null);
    expect(scope.echoVm.response).not.toBe('');
    expect(scope.echoVm.responseInError).toBe(true);
    expect(scope.echoVm.showResponse).toBe(true);
  });

  it('should set the view model appropriately on success', function() {
    succeedPromise = true;

    scope.requestEchoFromServer('Hello World');
    scope.$digest();

    expect(echoSvc.pingServer).toHaveBeenCalled();
    expect(scope.echoVm.response).not.toBe(null);
    expect(scope.echoVm.response).not.toBe('');
    expect(scope.echoVm.responseInError).toBe(false);
    expect(scope.echoVm.showResponse).toBe(true);
  });

});
