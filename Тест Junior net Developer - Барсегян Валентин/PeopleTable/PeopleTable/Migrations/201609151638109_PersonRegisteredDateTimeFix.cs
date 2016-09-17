namespace PeopleTable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonRegisteredDateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Registered", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Registered", c => c.DateTime(nullable: false));
        }
    }
}
