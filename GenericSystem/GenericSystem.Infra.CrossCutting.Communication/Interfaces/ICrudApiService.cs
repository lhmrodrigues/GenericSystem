using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Interfaces
{
    public interface ICrudApiService<TViewModel>
    {
        Task<bool> PutAsync(string token, TViewModel obj);

        Task<TViewModel> GetAsync(string token, Guid id, bool getDependencies = true);

        Task<IEnumerable<TViewModel>> ListAsync(string token, bool getDependencies = false);

        Task<bool> PostAsync(string token, TViewModel obj);

        Task<bool> DeleteAsync(string token, Guid id);
    }
}
