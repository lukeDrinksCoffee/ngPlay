'use strict';

describe('Directive: apRegisterDirective', function () {

  // load the directive's module
  beforeEach(module('ngPlayfrontspaApp'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<ap-register-directive></ap-register-directive>');
    element = $compile(element)(scope);
    expect(element.text()).toBe('this is the apRegisterDirective directive');
  }));
});
