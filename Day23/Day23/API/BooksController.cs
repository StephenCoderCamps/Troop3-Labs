using Day23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Day23.API
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();


        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return _db.Books.ToList();
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        // POST: api/Books
        public HttpResponseMessage Post(Book book)
        {
            if (ModelState.IsValid) {
                if (book.Id == 0) {
                    _db.Books.Add(book);
                    _db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created, book);
                }
                else {
                    var original = _db.Books.Find(book.Id);
                    original.Title = book.Title;
                    original.Author = book.Author;
                    _db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, book);
                }
               
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }
    }
}
