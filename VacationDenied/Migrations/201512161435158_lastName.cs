namespace VacationDenied.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "VacationDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "VacationDays");
            DropColumn("dbo.AspNetUsers", "lastName");
        }
    }
}
