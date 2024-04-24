namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAccountTypeFromRegister : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "AccountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AccountType", c => c.String());
        }
    }
}
