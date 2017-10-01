namespace LogInEx1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
