(function (){


    angular.module('myApp').factory('albumService', function ($resource) {
        var Album = $resource('/api/albums/:id');
        



        var _listAll = function () {
            return Album.query();
        };

       
        var _save = function (album) {

            // The save method belongs to the $resource and it is going to 
            // call the POST method on the API Controller.
            return Album.save(album);
        };

        // Get method gets the details of an album
        // so that we can prepopulate the form on our client-side
        var _get = function (id) {

            // Goes to the web API and gets the album that matches the id
            return Album.get({ id: id });
        }

        var _remove = function (id) {

            return Album.remove({ id: id });
        }

        // exports
        return {
            listAll: _listAll,
            save: _save,
            get: _get,
            remove: _remove
        };

    });

})();