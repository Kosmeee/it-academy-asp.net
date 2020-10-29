namespace ItAcademy.Project.Music.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.Users");
            DropIndex("dbo.Playlists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Playlist_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Playlist_Id");
            AddForeignKey("dbo.AspNetUsers", "Playlist_Id", "dbo.Playlists", "Id");
            DropColumn("dbo.Playlists", "Image");
            DropColumn("dbo.Playlists", "AddedDate");
            DropColumn("dbo.Playlists", "ApplicationUser_Id");
            DropColumn("dbo.Playlists", "User_Id");
            DropTable("dbo.Users");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Playlists", "User_Id", c => c.Int());
            AddColumn("dbo.Playlists", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Playlists", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Playlists", "Image", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.AspNetUsers", new[] { "Playlist_Id" });
            DropColumn("dbo.AspNetUsers", "Playlist_Id");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            CreateIndex("dbo.Playlists", "User_Id");
            CreateIndex("dbo.Playlists", "ApplicationUser_Id");
            AddForeignKey("dbo.Playlists", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Playlists", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
