'use strict';

angular.module('ngPlay')
  .directive('apUserInfoDirective', function (UserAccountService) {
    return {
      templateUrl: 'templates/directives/userinfo.html',
      restrict: 'A',
      replace: true,
      scope: {
        isLoggedIn: '='
      },
      link: function postLink(scope, element, attrs) {
        scope.userInfo = {
          userName: '',
          email: ''
        };

        scope.$watch('isLoggedIn', function(newValue, oldValue) {
          if (newValue) {

            UserAccountService.getUserInfo()
              .then(function(data) {
                scope.userInfo.userName = data.UserName;
                scope.userInfo.email = data.Email;

              }, function() {

              });
          }
        });
      }
    };
  });
