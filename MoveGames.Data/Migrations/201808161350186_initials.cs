namespace MoveGames.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Producer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "Producer");
        }
    }
}
