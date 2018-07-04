namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_truong_trong_country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "FileUpload", c => c.Binary());
            AddColumn("dbo.Country", "FileUploadName", c => c.String());
            AddColumn("dbo.Country", "FileUploadType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "FileUploadType");
            DropColumn("dbo.Country", "FileUploadName");
            DropColumn("dbo.Country", "FileUpload");
        }
    }
}
