using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorAgency.Data.Repository
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
}
