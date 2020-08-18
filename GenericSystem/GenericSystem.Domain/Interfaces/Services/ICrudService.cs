using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Services
{
    public interface ICrudService<TEntity>
    {
        TEntity Post(TEntity obj, bool getDependencies = false);

        TEntity Get(Guid id, bool getDependencies = true);

        IEnumerable<TEntity> List(bool getDependencies = false);

        bool Put(TEntity obj);

        bool Delete(Guid id);

        Guid GetGuid();
    }
}
