namespace Kiarah.LittleXavier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToStatistic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.statistic", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.statistic", "date");
        }
    }
}
