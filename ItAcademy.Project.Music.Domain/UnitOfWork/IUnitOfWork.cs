using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ItAcademy.Project.Music.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
            DbSet<TEntity> Set<TEntity>()
                where TEntity : class;

            DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
               where TEntity : class;

            int SaveChanges();
    }
}
