(function () {

    angular.module('BookApp').factory('taxService', function (booksControllerUrl, $resource) {

        return function (price) {
            return price * 0.08;
        };

    });



    angular.module('BookApp').factory('busyService', function (booksControllerUrl, $resource) {

        var _calculateTax = function (price) {
            return price * 0.08;
        };

        var _showCurrentTime = function () {
            return new Date();
        };

        return {
            calculateTax: _calculateTax,
            showCurrentTime: _showCurrentTime
        };
    });


})();