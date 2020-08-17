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

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await DeleteAsync(actionRoute, id);
        }
        
        public async Task<UserViewModel> GetAsync(Guid id, bool getDependencies = true)
        {
            return await GetAsync(actionRoute, id, getDependencies);
        }

        public async Task<IEnumerable<UserViewModel>> ListAsync(bool getDependencies = false)
        {
            return await ListAsync(getDependencies);
        }

        public async Task<bool> PostAsync(UserViewModel obj)
        {
            return await PostAsync(actionRoute, obj);
        }

        public async Task<bool> PutAsync(UserViewModel obj)
        {
            return await PutAsync(actionRoute, obj.Id, obj);
        }

        public async Task<UserViewModel> Authenticate(string username, string password)
        {
            try
            {
                RestRequest request = new RestRequest($"api/v1/{actionRoute}/auth", Method.GET);
                request.AddQueryParameter("username", username);
                request.AddQueryParameter("password", password);

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

        public async Task<bool> VerifyUsername(string username)
        {
            try
            {
                RestRequest request = new RestRequest($"api/v1/{actionRoute}/VerifyUsername", Method.GET);
                request.AddQueryParameter("username", username);

                IRestResponse response = _client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (!string.IsNullOrWhiteSpace(response.Content))
                    {
                        throw new Exception(response.Content);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception("Falha ao se comunicar com a api de dados.");
                    }
                }

                return JsonConvert.DeserializeObject<bool>(response.Content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
