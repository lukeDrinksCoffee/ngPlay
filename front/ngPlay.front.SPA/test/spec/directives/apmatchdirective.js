'use strict';

describe('Directive: apMatchDirective', function () {

  // load the directive's module
  beforeEach(module('ngPlay'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<ap-match-directive></ap-match-directive>');
    element = $compile(element)(scope);
    //expect(element.text()).toBe('this is the apMatchDirective directive');

    // TODO LEO implement
  }));
});
