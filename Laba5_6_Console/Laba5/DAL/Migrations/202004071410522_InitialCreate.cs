namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Time = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Heroes", t => t.HeroId, cascadeDelete: true)
                .Index(t => t.HeroId);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.HeroId);
            
            CreateTable(
                "dbo.OrderPrices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ZoneAtractions",
                c => new
                    {
                        Zone_Id = c.Int(nullable: false),
                        Atraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zone_Id, t.Atraction_Id })
                .ForeignKey("dbo.Zones", t => t.Zone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Atractions", t => t.Atraction_Id, cascadeDelete: true)
                .Index(t => t.Zone_Id)
                .Index(t => t.Atraction_Id);
            
            CreateTable(
                "dbo.OrderZones",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Zone_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Zone_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.Zone_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Zone_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderZones", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.OrderZones", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderPrices", "Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "HeroId", "dbo.Heroes");
            DropForeignKey("dbo.ZoneAtractions", "Atraction_Id", "dbo.Atractions");
            DropForeignKey("dbo.ZoneAtractions", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.OrderZones", new[] { "Zone_Id" });
            DropIndex("dbo.OrderZones", new[] { "Order_Id" });
            DropIndex("dbo.ZoneAtractions", new[] { "Atraction_Id" });
            DropIndex("dbo.ZoneAtractions", new[] { "Zone_Id" });
            DropIndex("dbo.OrderPrices", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "HeroId" });
            DropTable("dbo.OrderZones");
            DropTable("dbo.ZoneAtractions");
            DropTable("dbo.OrderPrices");
            DropTable("dbo.Heroes");
            DropTable("dbo.Orders");
            DropTable("dbo.Zones");
            DropTable("dbo.Atractions");
        }
    }
}
