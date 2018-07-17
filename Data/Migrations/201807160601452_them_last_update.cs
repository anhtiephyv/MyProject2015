namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_last_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "LastUpdate");
        }
    }
}
