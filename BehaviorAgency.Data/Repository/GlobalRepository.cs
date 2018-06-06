using BehaviorAgency.Data.Entities;
using System;
using System.Linq;

namespace BehaviorAgency.Services.Impl
{
    public interface IGlobalRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();

        TEntity FindById(object id);

        TEntity Insert(TEntity entity, int userId = 0);

        void Update(TEntity entity, int userId = 0);

        void Delete(object id);
    }

    public class GlobalRepository<TEntity> : IGlobalRepository<TEntity> where TEntity : class 
    {
        protected readonly DataContext _dbContext;

        public GlobalRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>();
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

        public TEntity Insert(TEntity entity, int userId = 0)
        {
            if (entity is IAuditable)
            {
                var auditable = entity as IAuditable;
                auditable.CreatedBy = 0;
                auditable.CreatedOn = DateTime.Now;
            }

            _dbContext.Set<TEntity>().Add(entity);

            SaveChanges();

            return entity;
        }

        public void Update(TEntity entity, int userId = 0)
        {
            if (entity is IAuditable)
            {
                var auditable = entity as IAuditable;
                auditable.LastModifiedBy = 0;
                auditable.LastModifiedOn = DateTime.Now;
            }

            _dbContext.Update(entity);

            SaveChanges();
        }
        

        protected void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
