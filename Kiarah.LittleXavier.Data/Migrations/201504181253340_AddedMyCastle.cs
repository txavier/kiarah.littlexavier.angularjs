namespace Kiarah.LittleXavier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMyCastle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.myCastles",
                c => new
                    {
                        myCastleId = c.Int(nullable: false, identity: true),
                        messageTitle = c.String(maxLength: 256),
                        messageBody = c.String(nullable: false),
                        userName = c.String(nullable: false, maxLength: 256, fixedLength: true),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.myCastleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.myCastles");
        }
    }
}
