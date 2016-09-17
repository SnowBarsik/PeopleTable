namespace PeopleTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Guid = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        About = c.String(),
                        Registered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PersonId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "PersonId", "dbo.People");
            DropIndex("dbo.Tags", new[] { "PersonId" });
            DropTable("dbo.Tags");
            DropTable("dbo.People");
        }
    }
}
