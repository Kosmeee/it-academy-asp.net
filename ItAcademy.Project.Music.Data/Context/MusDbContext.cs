using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.Project.Music.Data.Context
{
   public class MusDbContext : IdentityDbContext, IMusDbContext
    {
        public MusDbContext()
            : base("name=MusDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MusDbContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
