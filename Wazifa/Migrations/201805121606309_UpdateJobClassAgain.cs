namespace Wazifa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobClassAgain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name, Description) VALUES('test', 'this is just test')");
        }
        
        public override void Down()
        {
        }
    }
}
