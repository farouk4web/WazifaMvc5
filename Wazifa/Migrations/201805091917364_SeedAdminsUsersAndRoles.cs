namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminsUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'62145c8c-37d2-4bf9-9e53-af06c1c7432c', N'Farouk@wazifa.com', 0, N'ANGeDrjfq3beEbOrSTLgrut8YoGDQko1Qrs4opY6KJBPNBgnKC8HFK6heqx8bm2YYg==', N'4f672da2-e37b-49a9-8274-753da5064007', NULL, 0, 0, NULL, 1, 0, N'Farouk')");
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'31bb4ed6-e6a2-41cd-ad43-cf7db34c19a7', N'المدراء')");
            Sql("INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'62145c8c-37d2-4bf9-9e53-af06c1c7432c', N'31bb4ed6-e6a2-41cd-ad43-cf7db34c19a7')");
        }

    public override void Down()
        {
        }
    }
}
