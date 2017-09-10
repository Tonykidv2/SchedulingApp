namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingcurrcredithourstostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CurrCredits", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "CurrCredits");
        }
    }
}
