using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Services
{
    internal class UserApiService : BaseApiService<UserViewModel>, IUserApiService
    {
        private const string actionRoute = "user";
        public UserApiService(ISystemConfiguration systemConfiguration)
            : base(systemConfiguration)
        {
        }

        public async Task<bool> DeleteAsync(string token, Guid id)
        {
            return await DeleteAsync(token, actionRoute, id);
        }

        public async Task<UserViewModel> GetAsync(string token, Guid id, bool getDependencies = true)
        {
            return await GetAsync(token, actionRoute, id, getDependencies);
        }

        public async Task<IEnumerable<UserViewModel>> ListAsync(string token, bool getDependencies = false)
        {
            return await ListAsync(token, getDependencies);
        }

        public async Task<bool> PostAsync(string token, UserViewModel obj)
        {
            return await PostAsync(token, actionRoute, obj);
        }

        public async Task<bool> PutAsync(string token, UserViewModel obj)
        {
            return await PutAsync(token, actionRoute, obj.Id, obj);
        }
    }
}
