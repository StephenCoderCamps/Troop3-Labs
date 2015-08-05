namespace ProductReview.Migrations
{
    using ProductReview.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductReview.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductReview.Models.ApplicationDbContext context)
        {
            var products = new Product[]
            {
                new Product{Name="Light-Saber", Rating= Rating.Great,
 
                Comments = new Comment[]
                    {
                        new Comment { CommentText = "This is stupendous! I love the green swooshiness!"},
                        new Comment { CommentText = "I got the Mace Windu purple-light saber!"},
                        new Comment { CommentText = "This light-saber is not waterproof!"}
                    }
                },
                new Product{Name="Lexus Hover-Board", Rating= Rating.Stupendous,
 
                Comments = new Comment[]
                    {
                        new Comment { CommentText = "It only floats two inches off the ground! I weigh 237...It sucks to use!"},
                        new Comment { CommentText = "Amazine!!!!"},
                        new Comment { CommentText = "I feel like Neo! Anything is possible...there is no ground..."}
                    }
                }
            };
            context.Products.AddOrUpdate(m => m.Name, products);
        }


    }
}

