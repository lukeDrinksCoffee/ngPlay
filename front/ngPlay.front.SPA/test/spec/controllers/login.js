'use strict';

describe('Controller: LoginController', function () {

  // load the controller's module
  beforeEach(module('ngPlay'));

  var succeedPromise, registerCtrl, scope, acctSvc;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope, $q, UserAccountService) {
    scope = $rootScope.$new();
    acctSvc = UserAccountService;

    spyOn(acctSvc, "loginUser").
      andCallFake(function (userData) {
        if (succeedPromise) {
          return $q.when( { userName: 'fakeUser' } );
        }
        else {
          return $q.reject('fakeErrorInfo');
        }
      })

    registerCtrl = $controller('LoginController', {
      $scope: scope,
      UserAccountService: acctSvc
    });
  }));

  it('properties and functions should be defined in the scope', function () {
    expect(scope.userData).toBeDefined();
    expect(scope.userData.userName).toBeDefined();
    expect(scope.userData.password).toBeDefined();

    expect(scope.working).toBeDefined();
    expect(scope.loginFailed).toBeDefined();
    expect(scope.isLoggedIn).toBeDefined();
    expect(scope.loginUser).toBeDefined();
  });

  it('should set the view model appropriately on error', function() {
    succeedPromise = false;

    scope.loginUser({});
    scope.$digest();

    expect(acctSvc.loginUser).toHaveBeenCalled();
    expect(scope.isLoggedIn).toBe(false);
    expect(scope.loginFailed).toBe(true);
    expect(scope.working).toBe(false);
  });

  it('should set the view model appropriately on success', function() {
    succeedPromise = true;

    scope.loginUser({});
    scope.$digest();

    expect(acctSvc.loginUser).toHaveBeenCalled();
    expect(scope.isLoggedIn).toBe(true);
    expect(scope.loginFailed).toBe(false);
    expect(scope.userName).toBe('fakeUser');
    expect(scope.working).toBe(false);
  });

});
