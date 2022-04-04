namespace ASP.NetFrameworkFA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacilitatorTableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacilitatorTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FacilitatorTables", new[] { "UserName" });
            DropTable("dbo.FacilitatorTables");
        }
    }
}
