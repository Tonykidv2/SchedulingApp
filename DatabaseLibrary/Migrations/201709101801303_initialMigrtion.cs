namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigrtion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreditHours = c.Int(nullable: false),
                        TimeSlotStart = c.String(),
                        TimeSlotEnd = c.String(),
                        MaxStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FullTime = c.Boolean(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false, identity: true),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessorID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.Registars",
                c => new
                    {
                        RegistarID = c.Int(nullable: false, identity: true),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.RegistarID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.TestCodeFirsts",
                c => new
                    {
                        TestCodeFirstId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestCodeFirstId);
            
            CreateTable(
                "dbo.PersonCourses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PersonID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Registars", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Professors", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.PersonCourses", "PersonID", "dbo.People");
            DropForeignKey("dbo.PersonCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.PersonCourses", new[] { "PersonID" });
            DropIndex("dbo.PersonCourses", new[] { "CourseID" });
            DropIndex("dbo.Students", new[] { "Person_PersonID" });
            DropIndex("dbo.Registars", new[] { "Person_PersonID" });
            DropIndex("dbo.Professors", new[] { "Person_PersonID" });
            DropTable("dbo.PersonCourses");
            DropTable("dbo.TestCodeFirsts");
            DropTable("dbo.Students");
            DropTable("dbo.Registars");
            DropTable("dbo.Professors");
            DropTable("dbo.People");
            DropTable("dbo.Courses");
        }
    }
}
