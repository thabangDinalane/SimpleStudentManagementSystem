namespace ASP.NetFrameworkFA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address1", c => c.String(nullable: false));
            DropColumn("dbo.Students", "FistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Students", "Address1", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
