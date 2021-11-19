namespace naRatunek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class naRatunekStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Name = c.String(),
                        Specialisation = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        PharmacyId = c.Int(nullable: false, identity: true),
                        PharmacyName = c.String(),
                        PharmacyType = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        FlatNumber = c.String(),
                    })
                .PrimaryKey(t => t.PharmacyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
            DropTable("dbo.Hospitals");
        }
    }
}
