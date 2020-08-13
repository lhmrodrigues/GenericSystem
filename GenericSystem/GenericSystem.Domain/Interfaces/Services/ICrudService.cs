using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Services
{
    public interface ICrudService<TEntity>
    {
        TEntity Put(TEntity obj, bool getDependencies = false);

        TEntity Get(Guid id, bool getDependencies = true);

        IEnumerable<TEntity> List(bool getDependencies = false);

        bool Post(TEntity obj);

        bool Delete(Guid id);

        Guid GetGuid();
    }
}
