using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductReview.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rating Rating { get; set; }
        public IList<Comment> Comments { get; set; }
        public Product()
        {
            this.Comments = new List<Comment>();


        }
    }
}