namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAppUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "UserId", c => c.String());
        }
    }
}
