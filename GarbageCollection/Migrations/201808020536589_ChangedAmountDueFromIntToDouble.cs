namespace GarbageCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAmountDueFromIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "AmountDue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "AmountDue", c => c.Int(nullable: false));
        }
    }
}
