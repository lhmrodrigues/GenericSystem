using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Interfaces
{
    public interface ICrudApiService<TViewModel>
    {
        Task<bool> PutAsync(TViewModel obj);

        Task<TViewModel> GetAsync(Guid id, bool getDependencies = true);

        Task<IEnumerable<TViewModel>> ListAsync(bool getDependencies = false);

        Task<bool> PostAsync(TViewModel obj);

        Task<bool> DeleteAsync(Guid id);
    }
}
