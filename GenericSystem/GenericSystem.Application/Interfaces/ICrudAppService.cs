using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Interfaces
{
    public interface ICrudAppService<TViewModel>
    {
        TViewModel Put(TViewModel obj, bool getDependencies = false);

        TViewModel Get(Guid id, bool getDependencies = true);

        IEnumerable<TViewModel> List(bool getDependencies = false);

        bool Post(TViewModel obj);

        bool Delete(Guid id);

    }
}
