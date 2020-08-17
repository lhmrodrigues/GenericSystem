using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSystem.Infra.Data.Repository
{
    internal class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(GenericSystemsContext context)
           : base(context)
        {

        }
        public User Authenticate(string username, string password)
        {
            IQueryable<User> obj = _dbSet.AsNoTracking();

            return obj
                .FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public bool VerifyUsername(string username)
        {
            IQueryable<User> obj = _dbSet.AsNoTracking();

            var response = obj.FirstOrDefault(x => x.Username == username);

            return response == null ? false : true;
        }
    }
}
