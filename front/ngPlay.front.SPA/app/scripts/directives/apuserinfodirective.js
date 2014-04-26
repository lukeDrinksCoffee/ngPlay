'use strict';

angular.module('ngPlay')
  .directive('apUserInfoDirective', function () {
    return {
      templateUrl: 'templates/directives/userinfo.html',
      restrict: 'A',
      replace: true,
      scope: {
        isLoggedIn: '='
      },
      link: function postLink(scope, element, attrs, UserAccountService) {
        scope.userInfo = {
          userName: '',
          email: ''
        };

        scope.$watch('isLoggedIn', function(newValue, oldValue) {
          if (newValue) {

            // TODO LEO fetch user info from backend

            scope.userInfo.userName = 'temp user name';
            scope.userInfo.email = 'temp email';
          }
        }); // TODO LEO  will it work without true here
      }
    };
  });
