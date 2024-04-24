namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Jobs", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.Jobs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "UserId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Jobs", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Jobs", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
