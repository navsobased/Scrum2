namespace Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsEducation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogEntries", "IsEducation", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogEntries", "IsEducation");
        }
    }
}
