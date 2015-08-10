(function () {

    app = angular.module('myApp');

    app.controller('AlbumsController', function (albumService, $modal) {
        var self = this;
        self.albums = [];

        self.getAlbums = function () {
            self.albums = albumService.listAll();
        };

        self.showCreateModal = function () {
            $modal.open({
                templateUrl: '/ngViews/createModal.html',
                controller: 'CreateAlbumModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.getAlbums();
            })

        };

        self.showEditModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/createModal.html',
                controller: 'EditAlbumModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function () {
                self.getAlbums();
            })

        };

        
        self.showRemoveModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/removeModal.html',
                controller: 'DeleteAlbumModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function () {
                self.getAlbums();
            })

        };


        self.getAlbums();
        

    });

    app.controller('CreateAlbumModal', function ($modalInstance, albumService) {
        var self = this;

        
        self.save = function () {
            // Calling the save method is asynchronous.
            // This says don't close the modal until the 
            // async call to the webAPI has succeeded.

            albumService.save(self.album).$promise.then(function () {
                $modalInstance.close();
            })
            
        };


    });

    app.controller('EditAlbumModal', function ($modalInstance, albumService, id) {
        var self = this;
        // Goes to the album service and gets the album that matches the id
        // the get method gets the album details so they are available to the form on the 
        // client -side
        self.album=albumService.get(id);
        
        self.save = function () {
            // Calling the save method is asynchronous.
            // This says don't close the modal until the 
            // async call to the webAPI has succeeded.
            albumService.save(self.album).$promise.then(function () {
                $modalInstance.close();
            })

        };


    });


    app.controller('DeleteAlbumModal', function ($modalInstance, albumService, id) {
        var self = this;

        self.remove = function () {
            
            albumService.remove(id).$promise.then(function () {
                $modalInstance.close();
            })

        };

        self.exit = function () {
            $modalInstance.dismiss();
        };
    });


})();