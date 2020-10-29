namespace ItAcademy.Project.Music.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            RenameColumn(table: "dbo.Tracks", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Tracks", name: "IX_Genre_Id", newName: "IX_GenreId");
            CreateTable(
                "dbo.PlaylistTrack",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlaylistId, t.TrackId })
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.PlaylistId)
                .Index(t => t.TrackId);

            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            DropColumn("dbo.Tracks", "Playlist_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Tracks", "Playlist_Id", c => c.Int());
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PlaylistTrack", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.PlaylistTrack", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistTrack", new[] { "TrackId" });
            DropIndex("dbo.PlaylistTrack", new[] { "PlaylistId" });
            DropTable("dbo.PlaylistTrack");
            RenameIndex(table: "dbo.Tracks", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Tracks", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Tracks", "Playlist_Id");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "Id");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "Id");
            AddForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists", "Id");
        }
    }
}
