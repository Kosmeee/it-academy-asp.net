using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
