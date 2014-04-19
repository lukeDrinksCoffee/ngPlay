'use strict';

angular.module('ngPlay')
  .directive('apPasswordStrengthDirective', function () {
    return {
      restrict: 'A',
      require: 'ngModel',
      link: function(scope, element, attrs, ngModel) {
        ngModel.$parsers.unshift(function(viewValue) {
          var pwdSpecialChar, pwdUpper, pwdLower, pwdValidLength, pwdHasNumber;

          pwdSpecialChar = (viewValue && /^[a-zA-Z0-9!@#\$%\^\&*\)\(+=._-]+$/.test(viewValue)) ? true : false;
          pwdUpper = (viewValue && /[A-Z]/.test(viewValue)) ? true : false;
          pwdLower = (viewValue && /[a-z]/.test(viewValue)) ? true : false;
          pwdValidLength = (viewValue && viewValue.length >= 6) ? true : false;
          pwdHasNumber = (viewValue && /\d/.test(viewValue)) ? true : false;

          ngModel.$setValidity('pwd', pwdSpecialChar && pwdUpper && pwdValidLength && pwdHasNumber && pwdLower);

          return viewValue;
        });
      }
    };
  });
