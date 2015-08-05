using ProductReview.Models;
// Allows you to use the .include() to allow you to load associated
// entities of the Product entity
using System.Data.Entity; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductReview.API
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();


        // GET: api/Products
        public IEnumerable<Product> GetProducts()
        {
            // You must include associated entities when retrieving products from
            // the database. To do that, you have to use .Include
            return _db.Products.Include(m=>m.Comments).ToList();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
