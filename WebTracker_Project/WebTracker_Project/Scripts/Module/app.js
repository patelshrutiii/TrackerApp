
var app = angular.module("Webapp", ['dx','angularUtils.directives.dirPagination'/*'ui.bootstrap'*/]);
angular.module("Webapp.Controller", []);
angular.module("Webapp").run([
    "$rootScope",
    function ($rootScope) {
        $rootScope.WebApiUrl = "/";
    }
]);

app.filter('truncate', function () {
    return function (value, wordwise, max, tail) {
        if (!value) return '';
        max = parseInt(max, 10);
        if (!max) return value;
        if (value.length <= max) return value;

        value = value.substr(0, max);
        if (wordwise) {
            var lastspace = value.lastIndexOf(' ');
            if (lastspace != -1) {
                value = value.substr(0, lastspace);
            }
        }
        return value + (tail || '.');
    };
});

app.filter('strLimit', ['$filter', function ($filter) {
    return function (input, limit) {
        if (!input) return;
        if (input.length <= limit) {
            return input;
        }

        return $filter('limitTo')(input, limit) + '...';
    };
}]);

app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

app.directive('dateInput', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            //Angular 1.3 insert a formater that force to set model to date object, otherwise throw exception.
            //Reset default angular formatters/parsers
            ngModelCtrl.$formatters.length = 0;
            ngModelCtrl.$parsers.length = 0;
        }
    };
});


