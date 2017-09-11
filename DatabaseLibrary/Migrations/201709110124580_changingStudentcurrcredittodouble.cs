namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingStudentcurrcredittodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CreditHours", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CreditHours", c => c.Int(nullable: false));
        }
    }
}
