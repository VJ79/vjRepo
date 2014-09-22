namespace MVCEverything.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Tel11", c => c.String());
            DropColumn("dbo.Students", "Tel7");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Tel7", c => c.String());
            DropColumn("dbo.Students", "Tel11");
        }
    }
}
