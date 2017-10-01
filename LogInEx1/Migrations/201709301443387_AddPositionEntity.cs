namespace LogInEx1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Positions");
        }
    }
}
