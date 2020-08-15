using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class UserService : CrudService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository,
            IUnitOfWork unitOfWork)
            : base(userRepository, unitOfWork)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            User user = _userRepository.Authenticate(username, password);

            return user;
        }
    }
}
