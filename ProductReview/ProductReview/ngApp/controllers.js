(function () {
    var app = angular.module('myApp');
    // $http allows us to use the Ajax call
    // we are using dependency injection...
    // $modal gives you a reference to your modal so you can call .open() 
    app.controller('ProductsController', function ($http,$modal) {
        var self = this;
        self.getProduct = function () {
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
        self.getProduct();

        self.showModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/reviewModal.html',
                controller: 'ModalController',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function () {
                self.getProduct();
            });
        }
    });
        
        app.controller('ModalController', function (id, $modalInstance, $http) {
            // new controller =  new variable to store 'this'
            var self = this;
            
            self.postReview = function () {
                // Whenever you create a resource you use the .post() method 
                $http.post('/api/products/' + id, { commentText: self.commentText })
                .success(function () {
                    $modalInstance.close();
                })
                .error(function (results) {
                    console.error(results);
                });

            }

        });
        
})();