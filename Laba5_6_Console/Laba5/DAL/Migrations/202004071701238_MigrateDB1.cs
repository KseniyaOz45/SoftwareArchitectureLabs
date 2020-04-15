namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "HeroId" });
            AlterColumn("dbo.Orders", "HeroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "HeroId");
            AddForeignKey("dbo.Orders", "HeroId", "dbo.Heroes", "HeroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "HeroId" });
            AlterColumn("dbo.Orders", "HeroId", c => c.Int());
            CreateIndex("dbo.Orders", "HeroId");
            AddForeignKey("dbo.Orders", "HeroId", "dbo.Heroes", "HeroId");
        }
    }
}
