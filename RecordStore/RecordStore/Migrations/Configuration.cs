namespace RecordStore.Migrations
{
    using RecordStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecordStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecordStore.Models.ApplicationDbContext context)
        {
            var albums = new Album[] {
                new Album {
                    Genre = "Rock",
                    Artist = "Aerosmith",
                    Title = "Toys in the Attic"
                },
                new Album {
                    Genre = "Poetry",
                    Artist = "Nikki Giavanni",
                    Title = "Spoken Word Poetry"
                },
                new Album {
                    Genre = "Classic Rock",
                    Artist = "Beatles",
                    Title = "Abbey Road"
                } ,
                new Album {
                    Genre = "Rap",
                    Artist = "Foreign Exchange",
                    Title = "Lookin' For a Friend"
                } 
            };
            context.Albums.AddOrUpdate(a => a.Title, albums);
        }
    }
}
