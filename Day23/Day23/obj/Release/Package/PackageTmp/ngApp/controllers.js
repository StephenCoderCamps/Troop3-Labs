(function () {


    angular.module('BookApp').controller('BooksController', function ($modal, $resource, booksControllerUrl, taxService) {
        var self = this;

        self.taxes = taxService(3.44);


        var Book = $resource(booksControllerUrl);


        self.books = Book.query();


        self.remove = function (book) {
            book.$remove({ id: book.id }, function () {
                self.books = self.books.filter(function (item) {
                    return item.id != book.id;
                });
            });
        };

       
        self.createBook = function () {
            var book = new Book(self.book);
            book.$save(function (newBook) {
                self.books.push(newBook);
                self.book = null;
            });
        };


        self.showEditModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/editModal.html',
                controller: 'ModalController',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function() {
                self.books = Book.query();
            });
        };

    });



    angular.module('BookApp').controller('ModalController', function (id, $resource, $modalInstance, booksControllerUrl) {
        var self = this;
        var Book = $resource(booksControllerUrl);
        self.book = Book.get({ id: id });

        self.editBook = function () {
            self.book.$save(function () {
                $modalInstance.close();
            });
        };

    });


})();