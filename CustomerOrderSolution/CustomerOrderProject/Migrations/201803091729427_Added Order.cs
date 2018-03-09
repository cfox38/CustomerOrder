namespace CustomerOrderProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fulfilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
