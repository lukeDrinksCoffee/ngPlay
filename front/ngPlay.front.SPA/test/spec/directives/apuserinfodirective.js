'use strict';

describe('Directive: apUserInfoDirective', function () {

  // load the directive's module
  beforeEach(module('ngPlay'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<ap-user-info-directive></ap-user-info-directive>');
    element = $compile(element)(scope);
    // expect(element.text()).toBe('this is the apUserInfoDirective directive');

    // TODO LEO implement
  }));
});
