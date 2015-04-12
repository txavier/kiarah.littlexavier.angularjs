namespace Kiarah.LittleXavier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredAttributeFromBlogEntryTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.blogEntry", "messageTitle", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.blogEntry", "messageTitle", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
