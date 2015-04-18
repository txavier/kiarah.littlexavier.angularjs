namespace Kiarah.LittleXavier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyJourney : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.myJourneys",
                c => new
                    {
                        myJourneyId = c.Int(nullable: false, identity: true),
                        messageTitle = c.String(maxLength: 256),
                        messageBody = c.String(nullable: false),
                        userName = c.String(nullable: false, maxLength: 256, fixedLength: true),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.myJourneyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.myJourneys");
        }
    }
}
