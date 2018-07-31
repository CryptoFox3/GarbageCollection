namespace GarbageCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpickupsmodelcontrollerandviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        PickupId = c.Int(nullable: false, identity: true),
                        PickupDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Zipcode = c.Int(nullable: false),
                        Repeat = c.Boolean(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        PickupCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PickupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pickups");
        }
    }
}
