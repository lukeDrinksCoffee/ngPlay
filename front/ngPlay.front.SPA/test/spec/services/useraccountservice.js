'use strict';

describe('Service: Useraccountservice', function () {

  // load the service's module
  beforeEach(module('ngPlayfrontspaApp'));

  // instantiate service
  var Useraccountservice;
  beforeEach(inject(function (_Useraccountservice_) {
    Useraccountservice = _Useraccountservice_;
  }));

  it('should do something', function () {
    expect(!!Useraccountservice).toBe(true);
  });

});
