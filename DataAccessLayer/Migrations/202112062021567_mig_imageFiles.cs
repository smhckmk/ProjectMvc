namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imageFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        imageId = c.Int(nullable: false, identity: true),
                        imageName = c.String(maxLength: 100),
                        imagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.imageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
