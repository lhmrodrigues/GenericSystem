using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Communication.Interfaces
{
    public interface IUserApiService : ICrudApiService<UserViewModel>
    {
    }
}
