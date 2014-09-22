namespace MVCEverything.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yu31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Tel7", c => c.String());
            DropColumn("dbo.Students", "Tel8");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Tel8", c => c.String());
            DropColumn("dbo.Students", "Tel7");
        }
    }
}
