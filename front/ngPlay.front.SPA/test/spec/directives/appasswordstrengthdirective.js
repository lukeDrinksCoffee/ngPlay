'use strict';

describe('Directive: apPasswordStrengthDirective', function () {

  // load the directive's module
  beforeEach(module('ngPlay'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<ap-password-strength-directive></ap-password-strength-directive>');
    element = $compile(element)(scope);
    // expect(element.text()).toBe('this is the apPasswordStrengthDirective directive');

    // TODO LEO implement
  }));
});
