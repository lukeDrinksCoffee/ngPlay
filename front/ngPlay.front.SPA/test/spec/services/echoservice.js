'use strict';

describe('Service: EchoService', function () {

  // load the service's module
  beforeEach(module('ngPlay'));

  // instantiate service
  var echoSvc, $httpBackend, appSettings, webApiUrl;
  beforeEach(inject(function($injector) {
    $httpBackend = $injector.get('$httpBackend');
    appSettings = $injector.get('AppSettings');
    echoSvc = $injector.get('EchoService');

    webApiUrl = appSettings.webApiUrl;
  }));

  it('should resolve the promise when successful HTTP GET', function () {

    var sampleData = JSON.stringify({echo: 'echo response'});

    $httpBackend.expectGET(webApiUrl + '/echo?value=hello').
      respond(200, sampleData);

    var promiseResolved = false;
    var returnedData = '';
    echoSvc.pingServer('hello').
      then(function(data) {
        promiseResolved = true;
        returnedData = data;
      });

    $httpBackend.flush();

    expect(promiseResolved).toBe(true);
    expect(JSON.stringify(returnedData)).toBe(sampleData);
  });

  it('should reject the promise when failed HTTP GET', function () {

    $httpBackend.expectGET(webApiUrl + '/echo?value=hello').
      respond(500, JSON.stringify({echo: 'echo response'}));

    var promiseRejected = false;
    echoSvc.pingServer('hello').
      then(undefined, function() {
        promiseRejected = true;
      });

    $httpBackend.flush();

    expect(promiseRejected).toBe(true);
  });

});
