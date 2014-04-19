'use strict';

angular.module('ngPlay')
  .directive('apMatchDirective', function () {
    return {
      require: 'ngModel',
      restrict: 'A',
      scope: {
        matchTo: '=matchTo'
      },
      link: function postLink(scope, element, attrs, ngModel) {
        scope.$watch(function() {
          return (ngModel.$pristine && angular.isUndefined(ngModel.$modelValue))
                     || scope.matchTo === ngModel.$modelValue;
        }, function(currentValue) {
          ngModel.$setValidity('match', currentValue);
        });
      }
    };
  });
