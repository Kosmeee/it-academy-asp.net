using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace ItAcademy.Project.Music.Data.Context
{
   public interface IMusDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
