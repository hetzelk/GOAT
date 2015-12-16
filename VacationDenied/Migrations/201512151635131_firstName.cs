namespace VacationDenied.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "firstName");
        }
    }
}
