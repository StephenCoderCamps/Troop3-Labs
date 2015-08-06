namespace Day23.Migrations
{
    using Day23.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Day23.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Day23.Models.ApplicationDbContext context)
        {
            var books = new Book[] {
                new Book {Title="Aragon", Author="Christopher Pallini"},
                new Book {Title="The Firm", Author="John Grisham"},
                new Book {Title="Juarassic Park", Author="Crichton"}
           };

            context.Books.AddOrUpdate(b => b.Title, books);
        }


    }
}
