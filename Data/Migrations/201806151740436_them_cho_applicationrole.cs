namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_cho_applicationrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationRoles", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.ApplicationRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationRoles", "Discriminator");
            DropColumn("dbo.ApplicationRoles", "Description");
        }
    }
}
