namespace SemNal1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ekipas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EkipaIme = c.String(),
                        EkipaSponsor = c.String(),
                        TurnirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turnirs", t => t.TurnirId, cascadeDelete: true)
                .Index(t => t.TurnirId);
            
            CreateTable(
                "dbo.Turnirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurnirIme = c.String(),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Igralecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgralecIme = c.String(),
                        IgralecPriimek = c.String(),
                        EkipaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ekipas", t => t.EkipaId, cascadeDelete: true)
                .Index(t => t.EkipaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Igralecs", "EkipaId", "dbo.Ekipas");
            DropForeignKey("dbo.Ekipas", "TurnirId", "dbo.Turnirs");
            DropIndex("dbo.Igralecs", new[] { "EkipaId" });
            DropIndex("dbo.Ekipas", new[] { "TurnirId" });
            DropTable("dbo.Igralecs");
            DropTable("dbo.Turnirs");
            DropTable("dbo.Ekipas");
        }
    }
}
