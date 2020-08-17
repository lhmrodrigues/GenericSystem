using GenericSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Services
{
    public interface IUserService : ICrudService<User>
    {
        User Authenticate(string username, string password);
        bool VerifyUsername(string username);
    }
}
