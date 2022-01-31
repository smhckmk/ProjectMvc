namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageId = c.Int(nullable: false, identity: true),
                        senderMail = c.String(maxLength: 50),
                        receiverMail = c.String(maxLength: 50),
                        subject = c.String(maxLength: 100),
                        messageContent = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.messageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
