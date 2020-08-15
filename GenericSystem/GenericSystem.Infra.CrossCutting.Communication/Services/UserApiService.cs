using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<UserViewModel> Authenticate(string login, string senha)
        {
            try
            {
                RestRequest request = new RestRequest($"api/v1/{actionRoute}/auth", Method.GET);
                request.AddQueryParameter("login", login);
                request.AddQueryParameter("senha", senha);

                IRestResponse response = _client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (!string.IsNullOrWhiteSpace(response.Content))
                    {
                        throw new Exception(response.Content);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        throw new Exception("Falha ao se comunicar com a api de dados.");
                    }
                }

                return JsonConvert.DeserializeObject<UserViewModel>(response.Content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
