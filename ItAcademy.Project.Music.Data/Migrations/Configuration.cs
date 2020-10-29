using System.Data.Entity.Migrations;

namespace ItAcademy.Project.Music.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.MusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.MusDbContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method
            // to avoid creating duplicate seed data.
        }
    }
}
