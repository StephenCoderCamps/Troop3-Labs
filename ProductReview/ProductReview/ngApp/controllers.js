(function () {
    var app = angular.module('myApp');
    // $http allows us to use the Ajax call
    // we are using dependency injection...
    app.controller('ProductsController', function ($http) {
        var self = this;
        this.getProduct = function () {
            // Using the http service to make Ajax call to service to invoke web API
            // Products controller
            $http.get('/api/products')
                // If successful taks the results and assign it to the products 
                // property of the view model.
                .success(function (results) {
                    self.products = results;
                })
                .error(function (results) {
                    console.error(results);
                });
        }
        this.getProduct();
    });

    
})();