(function () {

    angular.module('BookApp', ['ngResource', 'ui.bootstrap']).constant('booksControllerUrl', '/api/books/:id');

    angular.module('BookApp').constant('booksControllerAPIUrl', '/api/books');


})();