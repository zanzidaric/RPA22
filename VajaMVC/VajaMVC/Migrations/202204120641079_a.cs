namespace VajaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PredmetIme = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Predmets");
        }
    }
}
