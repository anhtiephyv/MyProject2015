namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "NumberLine", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "NumberLine");
        }
    }
}
