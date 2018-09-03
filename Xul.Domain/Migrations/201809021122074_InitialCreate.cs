namespace Xul.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdmissionNo = c.String(),
                        SchoolId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(),
                        ExamType = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherNo = c.String(),
                        SchoolId = c.Int(nullable: false),
                        EnlistedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Domitories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DomitoryName = c.String(),
                        DomitoryNo = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        RegNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployNumber = c.String(),
                        SchoolId = c.Int(nullable: false),
                        EnlistedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Domitories", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TimeTables", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Students", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Students");
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "SchoolId" });
            DropIndex("dbo.Domitories", new[] { "SchoolId" });
            DropIndex("dbo.TimeTables", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropIndex("dbo.Subjects", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ParentId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropTable("dbo.Streams");
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Leaves");
            DropTable("dbo.Employees");
            DropTable("dbo.Schools");
            DropTable("dbo.Domitories");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Teachers");
            DropTable("dbo.Exams");
            DropTable("dbo.Subjects");
            DropTable("dbo.Parents");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Attendences");
        }
    }
}
