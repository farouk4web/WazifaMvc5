namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'b2ac1d1b-405f-4e2b-9380-76b8c69dfbeb', N'الباحثين')");
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'76e61bfc-e336-4c31-a196-1ba560d5fdcb', N'الناشرين')");
        }

        public override void Down()
        {
        }
    }
}
