using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Interfaces
{
    public interface ICrudAppService<TViewModel>
    {
        TViewModel Post(TViewModel obj, bool getDependencies = false);

        TViewModel Get(Guid id, bool getDependencies = true);

        IEnumerable<TViewModel> List(bool getDependencies = false);

        bool Put(TViewModel obj);

        bool Delete(Guid id);

    }
}
