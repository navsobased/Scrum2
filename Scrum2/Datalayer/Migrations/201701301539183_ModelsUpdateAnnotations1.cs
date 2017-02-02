namespace Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdateAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogEntries", "IsFormal", c => c.Boolean(nullable: false));
            AddColumn("dbo.Files", "FileName", c => c.String());
            AddColumn("dbo.Files", "FileContent", c => c.Binary());
            AddColumn("dbo.BlogEntryComments", "CommentText", c => c.String(nullable: false));
            AddColumn("dbo.BlogEntryComments", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.BlogEntries", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BlogEntries", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogEntries", "Text", c => c.String());
            AlterColumn("dbo.BlogEntries", "Title", c => c.String());
            DropColumn("dbo.BlogEntryComments", "Author");
            DropColumn("dbo.BlogEntryComments", "CommentText");
            DropColumn("dbo.Files", "FileContent");
            DropColumn("dbo.Files", "FileName");
            DropColumn("dbo.BlogEntries", "IsFormal");
        }
    }
}
