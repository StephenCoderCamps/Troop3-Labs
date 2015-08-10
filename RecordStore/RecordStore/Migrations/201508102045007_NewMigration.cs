namespace RecordStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Artist", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Artist", c => c.String());
        }
    }
}
