using System.Data.Entity;
namespace ItAcademy.Project.Music.Data.Context
{
    class MusDbContext : DbContext, IMusDbContext
    {
        public MusDbContext()
            : base("name=MusDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

    }
}
