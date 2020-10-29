using System.Data.Entity.Migrations;

namespace ItAcademy.Project.Music.Data.Migrations
{
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Image = c.String(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .Index(t => t.ArtistId);

            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Url = c.String(),
                        Image = c.String(),
                        AlbumId = c.Int(),
                        ArtistId = c.Int(),
                        Genre_Id = c.Int(),
                        Playlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id)
                .Index(t => t.AlbumId)
                .Index(t => t.ArtistId)
                .Index(t => t.Genre_Id)
                .Index(t => t.Playlist_Id);

            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Image = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

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

            CreateTable(
                "dbo.ArtistGenre",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.GenreId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.ArtistGenre", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.ArtistGenre", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropIndex("dbo.ArtistGenre", new[] { "GenreId" });
            DropIndex("dbo.ArtistGenre", new[] { "ArtistId" });
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            DropIndex("dbo.Tracks", new[] { "Genre_Id" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.ArtistGenre");
            DropTable("dbo.Users");
            DropTable("dbo.Playlists");
            DropTable("dbo.Tracks");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
