namespace Xul.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forst : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Classes", "SchoolId");
            AddForeignKey("dbo.Classes", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
            DropColumn("dbo.Teachers", "SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "SchoolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Classes", new[] { "SchoolId" });
        }
    }
}
