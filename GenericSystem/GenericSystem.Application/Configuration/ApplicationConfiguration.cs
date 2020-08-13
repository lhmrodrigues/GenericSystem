using AutoMapper;
using GenericSystem.Application.Interfaces;
using GenericSystem.Application.Services;
using GenericSystem.Domain.Entities;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ICrudAppService<UserViewModel>, CrudAppService<User, UserViewModel>>();

            services
               .AddScoped<IUserAppService, UserAppService>();

            services.AddAutoMapper();
        }
    }
}
