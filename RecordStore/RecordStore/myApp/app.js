(function () {

    angular.module('myApp', ['ngRoute', 'ui.bootstrap', 'ngResource']).config(function($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'AlbumsController',
                controllerAs: 'main',
                templateUrl: '/ngViews/home.html'
            });
        
    });

})();