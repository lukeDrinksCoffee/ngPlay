'use strict';

describe('Controller: RegisterController', function () {

  // load the controller's module
  beforeEach(module('ngPlay'));

  var succeedPromise, registerCtrl, scope, acctSvc;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope, $q, UserAccountService) {
    scope = $rootScope.$new();
    acctSvc = UserAccountService;

    spyOn(acctSvc, "registerUser").
      andCallFake(function (userData) {
        if (succeedPromise) {
          return $q.when( { userName: 'fakeUser' } );
        }
        else {
          return $q.reject('fakeErrorInfo');
        }
      })

    registerCtrl = $controller('RegisterController', {
      $scope: scope,
      UserAccountService: acctSvc
    });
  }));

  it('properties and functions should be defined in the scope', function () {
    expect(scope.registerVm).toBeDefined();

    expect(scope.registerVm.userData).toBeDefined();
    expect(scope.registerVm.userData.name).toBeDefined();
    expect(scope.registerVm.userData.email).toBeDefined();
    expect(scope.registerVm.userData.password).toBeDefined();
    expect(scope.registerVm.userData.confirmPassword).toBeDefined();

    expect(scope.registerVm.working).toBeDefined();
    expect(scope.registerVm.isRegistered).toBeDefined();
    expect(scope.registerVm.errorOccurred).toBeDefined();
    expect(scope.registerVm.errorInfo).toBeDefined();
    expect(scope.registerVm.registerUser).toBeDefined();
  });

  it('should set the view model appropriately on error', function() {
    succeedPromise = false;

    scope.registerVm.registerUser({});
    scope.$digest();

    expect(acctSvc.registerUser).toHaveBeenCalled();
    expect(scope.registerVm.errorOccurred).toBe(true);
    expect(scope.registerVm.errorInfo).toBe('fakeErrorInfo');
    expect(scope.registerVm.working).toBe(false);
  });

  it('should set the view model appropriately on success', function() {
    succeedPromise = true;

    scope.registerVm.registerUser({});
    scope.$digest();

    expect(acctSvc.registerUser).toHaveBeenCalled();
    expect(scope.registerVm.isRegistered).toBe(true);
    expect(scope.registerVm.errorOccurred).toBe(false);
    expect(scope.registerVm.working).toBe(false);
  });

});
