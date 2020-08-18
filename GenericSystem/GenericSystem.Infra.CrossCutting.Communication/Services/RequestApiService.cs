using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Services
{
    internal class RequestApiService : BaseApiService<RequestViewModel>, IRequestApiService
    {
        private const string actionRoute = "request";

        public RequestApiService(ISystemConfiguration systemConfiguration) : base(systemConfiguration)
        {
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await DeleteAsync(actionRoute, id);
        }

        public async Task<RequestViewModel> GetAsync(Guid id, bool getDependencies = true)
        {
            return await GetAsync(actionRoute, id, getDependencies);
        }

        public async Task<IEnumerable<RequestViewModel>> ListAsync(bool getDependencies = false)
        {
            return await ListAsync(getDependencies);
        }

        public async Task<bool> PostAsync(RequestViewModel obj)
        {
            return await PostAsync(actionRoute, obj);
        }

        public async Task<bool> PutAsync(RequestViewModel obj)
        {
            return await PutAsync(actionRoute, obj.Id, obj);
        }
    }
}
