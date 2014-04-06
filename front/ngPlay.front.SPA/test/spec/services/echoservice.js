'use strict';

describe('Service: EchoService', function () {

  // load the service's module
  beforeEach(module('ngPlay'));

  // instantiate service
  var echoService;
  beforeEach(inject(function (_echoService_) {
    echoService = _echoService_;
  }));

  //it('should do something', function () {
  //  expect(!!echoService).toBe(true);
  //});

});
