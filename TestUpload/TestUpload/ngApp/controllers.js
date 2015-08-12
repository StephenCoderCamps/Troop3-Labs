(function() {

    angular.module('MyApp').controller('DropZoneController', function ($scope) {
        var self = this;
        self.uploadFile = function () {

            $scope.processDropzone();
        };

        self.reset = function () {
            $scope.resetDropzone();
        };
    });


})();