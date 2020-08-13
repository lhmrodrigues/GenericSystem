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
    }
}
