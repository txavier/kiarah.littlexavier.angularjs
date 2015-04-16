namespace Kiarah.LittleXavier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitToStatistic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.statistic", "statisticUnit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.statistic", "statisticUnit");
        }
    }
}
