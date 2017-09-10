namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Password", c => c.String());
            AlterColumn("dbo.People", "Username", c => c.String());
        }
    }
}
