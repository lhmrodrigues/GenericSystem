using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Repositories
{
    public interface ICrudRepository<TEntity> : IDisposable
    {
        void Put(TEntity obj);

        TEntity Get(Guid id, bool getDependencies = true);

        IQueryable<TEntity> List(bool getDependencies = false);

        void Post(TEntity obj);
    }
}
