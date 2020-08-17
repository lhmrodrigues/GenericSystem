using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystem.Infra.CrossCutting.Communication.Interfaces
{
    public interface IUserApiService : ICrudApiService<UserViewModel>
    {
        Task<UserViewModel> Authenticate(string username, string senha);
        Task<bool> VerifyUsername(string username);

    }
}
