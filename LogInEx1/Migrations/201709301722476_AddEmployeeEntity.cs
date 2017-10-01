namespace LogInEx1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        HireDate = c.String(),
                        Wage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Positionid = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.Positionid, cascadeDelete: true)
                .Index(t => t.Positionid)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Positionid", "dbo.Positions");
            DropForeignKey("dbo.Employees", "LocationId", "dbo.Locations");
            DropIndex("dbo.Employees", new[] { "LocationId" });
            DropIndex("dbo.Employees", new[] { "Positionid" });
            DropTable("dbo.Employees");
        }
    }
}
