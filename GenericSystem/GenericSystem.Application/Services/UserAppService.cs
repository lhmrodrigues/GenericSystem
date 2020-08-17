using AutoMapper;
using GenericSystem.Application.Interfaces;
using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Services
{
    internal class UserAppService : CrudAppService<User, UserViewModel>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IMapper mapper, IUserService userService)
            : base(mapper, userService)
        {
            _userService = userService;
        }

        public UserViewModel Authenticate(string userame, string password)
        {
            return _mapper.Map<UserViewModel>(_userService.Authenticate(userame, password));

        }

        public bool VerifyUsername(string username)
        {
            return _mapper.Map<bool>(_userService.VerifyUsername(username));
        }
    }
}
