namespace LockStep2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentId", c => c.String());
            AddColumn("dbo.Payments", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Payments", "IdRequest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "IdRequest", c => c.String());
            DropColumn("dbo.Payments", "Sum");
            DropColumn("dbo.Payments", "PaymentId");
        }
    }
}
