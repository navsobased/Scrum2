namespace Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogEntries",
                c => new
                    {
                        BlogEntryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Attachment_FileId = c.Int(),
                        Author_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogEntryId)
                .ForeignKey("dbo.Files", t => t.Attachment_FileId)
                .ForeignKey("dbo.Users", t => t.Author_UserId)
                .Index(t => t.Attachment_FileId)
                .Index(t => t.Author_UserId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Signature = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.BlogEntryComments",
                c => new
                    {
                        BlogEntryCommentId = c.Int(nullable: false, identity: true),
                        BlogEntry_BlogEntryId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogEntryCommentId)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_BlogEntryId)
                .Index(t => t.BlogEntry_BlogEntryId);
            
            CreateTable(
                "dbo.Invites",
                c => new
                    {
                        InviteId = c.Int(nullable: false, identity: true),
                        Accepted = c.Boolean(nullable: false),
                        AcceptedTime = c.DateTime(nullable: false),
                        InvitedUser_UserId = c.Int(),
                        Meeting_MeetingId = c.Int(),
                    })
                .PrimaryKey(t => t.InviteId)
                .ForeignKey("dbo.Users", t => t.InvitedUser_UserId)
                .ForeignKey("dbo.Meetings", t => t.Meeting_MeetingId)
                .Index(t => t.InvitedUser_UserId)
                .Index(t => t.Meeting_MeetingId);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Organizer_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MeetingId)
                .ForeignKey("dbo.Users", t => t.Organizer_UserId)
                .Index(t => t.Organizer_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "Organizer_UserId", "dbo.Users");
            DropForeignKey("dbo.Invites", "Meeting_MeetingId", "dbo.Meetings");
            DropForeignKey("dbo.Invites", "InvitedUser_UserId", "dbo.Users");
            DropForeignKey("dbo.BlogEntryComments", "BlogEntry_BlogEntryId", "dbo.BlogEntries");
            DropForeignKey("dbo.BlogEntries", "Author_UserId", "dbo.Users");
            DropForeignKey("dbo.BlogEntries", "Attachment_FileId", "dbo.Files");
            DropIndex("dbo.Meetings", new[] { "Organizer_UserId" });
            DropIndex("dbo.Invites", new[] { "Meeting_MeetingId" });
            DropIndex("dbo.Invites", new[] { "InvitedUser_UserId" });
            DropIndex("dbo.BlogEntryComments", new[] { "BlogEntry_BlogEntryId" });
            DropIndex("dbo.BlogEntries", new[] { "Author_UserId" });
            DropIndex("dbo.BlogEntries", new[] { "Attachment_FileId" });
            DropTable("dbo.Meetings");
            DropTable("dbo.Invites");
            DropTable("dbo.BlogEntryComments");
            DropTable("dbo.Users");
            DropTable("dbo.Files");
            DropTable("dbo.BlogEntries");
        }
    }
}
