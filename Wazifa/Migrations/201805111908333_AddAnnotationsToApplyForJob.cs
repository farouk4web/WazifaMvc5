namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToApplyForJob : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            AlterColumn("dbo.ApplyForJobs", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ApplyForJobs", "UserId");
            AddForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ApplyForJobs", "Message", c => c.String());
            CreateIndex("dbo.ApplyForJobs", "UserId");
            AddForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
