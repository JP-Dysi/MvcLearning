namespace MvcLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "Rating");
        }
    }
}
