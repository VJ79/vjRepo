namespace MVCEverything.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yu3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Tel8", c => c.String());
            DropColumn("dbo.Students", "Tel9");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Tel9", c => c.String());
            DropColumn("dbo.Students", "Tel8");
        }
    }
}
