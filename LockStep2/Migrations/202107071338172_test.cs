namespace LockStep2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRequest = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRequest = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "Price");
            DropColumn("dbo.Books", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Price", c => c.Int(nullable: false));
            DropForeignKey("dbo.Prices", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Payments", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Checks", "Book_Id", "dbo.Books");
            DropIndex("dbo.Prices", new[] { "Book_Id" });
            DropIndex("dbo.Payments", new[] { "Book_Id" });
            DropIndex("dbo.Checks", new[] { "Book_Id" });
            DropTable("dbo.Prices");
            DropTable("dbo.Payments");
            DropTable("dbo.Checks");
        }
    }
}
