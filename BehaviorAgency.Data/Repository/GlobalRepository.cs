using BehaviorAgency.Data.Context;
using BehaviorAgency.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BehaviorAgency.Services.Impl
{
    public interface IGlobalRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> EntityQuery { get; }

        IEnumerable<TEntity> Find(Func<TEntity, bool> condition);

        TEntity FindById(object id);

        TEntity Insert(TEntity entity, int userId);

        void Update(TEntity entity, int userId);

        void Delete(object id);

        void SoftDelete(object id, int userId);
    }

    public class GlobalRepository<TEntity> : IGlobalRepository<TEntity> where TEntity : class 
    {
        protected readonly AppDataContext _dbContext;

        public GlobalRepository(AppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> EntityQuery
        {
            get {
                return _dbContext.Set<TEntity>();
            }
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> condition)
        { 
            return _dbContext.Set<TEntity>().Where(condition);
        }

        public TEntity FindById(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Delete(object id)
        {
            var entity = FindById(id);

            _dbContext.Set<TEntity>().Remove(entity);

            SaveChanges();
        }

        public void SoftDelete(object id, int userId)
        {
            var entity = FindById(id);
            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            entityEntry.Property("IsDeleted").CurrentValue = true;

            SaveChanges(userId);
        }

        public TEntity Insert(TEntity entity, int userId)
        {
            _dbContext.Set<TEntity>().Add(entity);

            SaveChanges(userId);

            return entity;
        }

        public void Update(TEntity entity, int userId)
        {
            var entityEntry = _dbContext.Update(entity);
            entityEntry.Property("LastModifiedBy").CurrentValue = userId;

            SaveChanges(userId);
        }
        

        protected void SaveChanges(int userId = 0)
        {
            TrackChanges(userId);

            _dbContext.SaveChanges();
        }

        private void TrackChanges(int userId) {

            var modifiedEntries = _dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added 
                                                                             || e.State == EntityState.Modified 
                                                                             || e.State == EntityState.Deleted);
            foreach (EntityEntry entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

                if (entry.State == EntityState.Added)
                {
                    entry.Property("IsDeleted").CurrentValue = false;
                    entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                    entry.Property("CreatedBy").CurrentValue = userId;
                }

                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;
                    entry.Property("LastModifiedBy").CurrentValue = userId;
                }

                else if (entry.State == EntityState.Deleted)
                {
                    var isDeleted = entry.Property("IsDeleted").CurrentValue;
                    if (Convert.ToBoolean(isDeleted)) {
                        entry.State = EntityState.Modified;
                        entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;
                        entry.Property("LastModifiedBy").CurrentValue = userId;
                    }
                }
            }
        }

        
    }
}
