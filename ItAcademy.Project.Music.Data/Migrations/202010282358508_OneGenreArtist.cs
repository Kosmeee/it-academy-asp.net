namespace ItAcademy.Project.Music.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class OneGenreArtist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtistGenre", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.ArtistGenre", "GenreId", "dbo.Genres");
            DropIndex("dbo.ArtistGenre", new[] { "ArtistId" });
            DropIndex("dbo.ArtistGenre", new[] { "GenreId" });
            AddColumn("dbo.Artists", "GenreId", c => c.Int());
            CreateIndex("dbo.Artists", "GenreId");
            AddForeignKey("dbo.Artists", "GenreId", "dbo.Genres", "Id");
            DropTable("dbo.ArtistGenre");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ArtistGenre",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.GenreId });
            DropForeignKey("dbo.Artists", "GenreId", "dbo.Genres");
            DropIndex("dbo.Artists", new[] { "GenreId" });
            DropColumn("dbo.Artists", "GenreId");
            CreateIndex("dbo.ArtistGenre", "GenreId");
            CreateIndex("dbo.ArtistGenre", "ArtistId");
            AddForeignKey("dbo.ArtistGenre", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtistGenre", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
    }
}
