namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoriesID = c.Int(nullable: false, identity: true),
                        CategorySeri = c.String(maxLength: 50),
                        CategoryName = c.String(),
                        CategoryInfo = c.String(),
                    })
                .PrimaryKey(t => t.CategoriesID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductSeri = c.String(maxLength: 50),
                        ProductName = c.String(),
                        ProductQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(),
                        Category_CategoriesID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.Category_CategoriesID)
                .Index(t => t.Category_CategoriesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_CategoriesID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_CategoriesID" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.Admin");
        }
    }
}
