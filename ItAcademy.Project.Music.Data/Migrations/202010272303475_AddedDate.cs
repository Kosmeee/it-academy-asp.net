namespace ItAcademy.Project.Music.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tracks", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Playlists", "AddedDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Playlists", "AddedDate");
            DropColumn("dbo.Tracks", "AddedDate");
            DropColumn("dbo.Albums", "AddedDate");
        }
    }
}
