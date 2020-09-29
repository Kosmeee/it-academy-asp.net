﻿using ItAcademy.Hw.Users.Data.Context;
using ItAcademy.Hw.Users.Domain.UnitOfWork;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace ItAcademy.Hw.Users.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMyDbContext db;

        public UnitOfWork(IMyDbContext db)
        {
            this.db = db;
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return db.Entry<TEntity>(entity);
        }

        public int SaveChanges()
        {
            
                return db.SaveChanges();
            
            


        }
    }
}
