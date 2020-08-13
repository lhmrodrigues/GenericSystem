using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Repository
{
    internal class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(GenericSystemsContext context)
           : base(context)
        {

        }
    }
}
