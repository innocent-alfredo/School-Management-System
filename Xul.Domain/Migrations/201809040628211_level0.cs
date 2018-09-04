namespace Xul.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class level0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AddColumn("dbo.Students", "MiddleName", c => c.String());
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "MaritalStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "CreatedBy", c => c.String());
            AddColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "EditedBy", c => c.String());
            AddColumn("dbo.Students", "EditedDate", c => c.DateTime());
            AddColumn("dbo.Parents", "FirstName", c => c.String());
            AddColumn("dbo.Parents", "MiddleName", c => c.String());
            AddColumn("dbo.Parents", "LastName", c => c.String());
            AddColumn("dbo.Parents", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parents", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Parents", "MaritalStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Parents", "CreatedBy", c => c.String());
            AddColumn("dbo.Parents", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parents", "EditedBy", c => c.String());
            AddColumn("dbo.Parents", "EditedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "EditedDate");
            DropColumn("dbo.Parents", "EditedBy");
            DropColumn("dbo.Parents", "CreatedDate");
            DropColumn("dbo.Parents", "CreatedBy");
            DropColumn("dbo.Parents", "MaritalStatus");
            DropColumn("dbo.Parents", "Gender");
            DropColumn("dbo.Parents", "DateOfBirth");
            DropColumn("dbo.Parents", "LastName");
            DropColumn("dbo.Parents", "MiddleName");
            DropColumn("dbo.Parents", "FirstName");
            DropColumn("dbo.Students", "EditedDate");
            DropColumn("dbo.Students", "EditedBy");
            DropColumn("dbo.Students", "CreatedDate");
            DropColumn("dbo.Students", "CreatedBy");
            DropColumn("dbo.Students", "MaritalStatus");
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "DateOfBirth");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "MiddleName");
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
