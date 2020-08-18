using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Services
{
    internal class OrderApiService : BaseApiService<OrderViewModel>, IOrderApiService
    {
        private const string actionRoute = "order";

        public OrderApiService(ISystemConfiguration systemConfiguration) : base(systemConfiguration)
        {
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await DeleteAsync(actionRoute, id);
        }

        public async Task<OrderViewModel> GetAsync(Guid id, bool getDependencies = true)
        {
            return await GetAsync(actionRoute, id, getDependencies);
        }

        public async Task<IEnumerable<OrderViewModel>> ListAsync(bool getDependencies = false)
        {
            return await ListAsync(getDependencies);
        }

        public async Task<bool> PostAsync(OrderViewModel obj)
        {
            return await PostAsync(actionRoute, obj);
        }

        public async Task<bool> PutAsync(OrderViewModel obj)
        {
            return await PutAsync(actionRoute, obj.Id, obj);
        }
    }
}
