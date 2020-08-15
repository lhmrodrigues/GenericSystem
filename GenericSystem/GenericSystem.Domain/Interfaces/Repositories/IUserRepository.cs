using GenericSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
