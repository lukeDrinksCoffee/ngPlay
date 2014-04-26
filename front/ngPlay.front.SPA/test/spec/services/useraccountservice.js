'use strict';

describe('Service: UserAccountService', function () {

  // load the service's module
  beforeEach(module('ngPlay'));

  // instantiate service
  var acctSvc, $httpBackend, appSettings, webApiUrl, $http, baseUrl;
  beforeEach(inject(function($injector) {
    $httpBackend = $injector.get('$httpBackend');
    appSettings = $injector.get('AppSettings');
    acctSvc = $injector.get('UserAccountService');
    $http = $injector.get('$http');

    webApiUrl = appSettings.webApiUrl;
    baseUrl = appSettings.baseUrl;
  }));

  it('isLoggedIn() - should return true when accessToken set; false otherwise', function () {

    acctSvc.accessToken = 'something';
    expect(acctSvc.isLoggedIn()).toBe(true);

    acctSvc.accessToken = '';
    expect(acctSvc.isLoggedIn()).toBe(false);
  });

  it('registerUser() - should resolve the promise when successful HTTP POST', function () {

    var sampleData = JSON.stringify({userName: 'someUser', password: 'somePassword'});

    var fakeReturnData = { loggedIn: true };

    $httpBackend.expectPOST(webApiUrl + '/Account/Register').
      respond(200, fakeReturnData);

    var promiseResolved = false;
    var returnedData = {};
    acctSvc.registerUser(sampleData).
      then(function(data) {
        promiseResolved = true;
        returnedData = data;
      });

    $httpBackend.flush();

    expect(promiseResolved).toBe(true);
    expect(JSON.stringify(returnedData)).toBe(JSON.stringify(fakeReturnData));
  });

  it('registerUser() - should reject the promise when failed HTTP POST', function () {

    var sampleData = JSON.stringify({userName: 'someUser', password: 'somePassword'});

    $httpBackend.expectPOST(webApiUrl + '/Account/Register').
      respond(500, JSON.stringify( { } ));

    var promiseRejected = false;
    acctSvc.registerUser(sampleData).
      then(undefined, function() {
        promiseRejected = true;
      });

    $httpBackend.flush();

    expect(promiseRejected).toBe(true);
  });

  it('loginUser() - should resolve the promise when successful HTTP POST', function () {

    var sampleData = JSON.stringify({userName: 'someUser', password: 'somePassword'});

    var fakeReturnData = { access_token: '123' };
    delete($http.defaults.headers.common.Authorization);

    $httpBackend.expectPOST(baseUrl + '/Token').
      respond(200, fakeReturnData);

    acctSvc.accessToken = '';

    var promiseResolved = false;
    var returnedData = {};
    acctSvc.loginUser(sampleData).
      then(function(data) {
        promiseResolved = true;
        returnedData = data;
      });

    $httpBackend.flush();

    expect(promiseResolved).toBe(true);
    expect(acctSvc.accessToken).toBe('123');
    expect($http.defaults.headers.common.Authorization).toBeDefined();
    expect($http.defaults.headers.common.Authorization).toBe('Bearer 123');
    expect(JSON.stringify(returnedData)).toBe(JSON.stringify(fakeReturnData));
  });

  it('loginUser() - should reject the promise when failed HTTP POST', function () {

    var sampleData = JSON.stringify({userName: 'someUser', password: 'somePassword'});

    $httpBackend.expectPOST(baseUrl + '/Token').
      respond(500, JSON.stringify( { } ));

    var promiseRejected = false;
    acctSvc.loginUser(sampleData).
      then(undefined, function() {
        promiseRejected = true;
      });

    $httpBackend.flush();

    expect(promiseRejected).toBe(true);
  });

  it('logoutUser() - should clear token and header', function () {

    acctSvc.accessToken = 'someValue';
    $http.defaults.headers.common.Authorization = 'someValue';

    acctSvc.logoutUser();

    expect(acctSvc.accessToken).toBe('');
    expect($http.defaults.headers.common.Authorization).not.toBeDefined();
  });

});
