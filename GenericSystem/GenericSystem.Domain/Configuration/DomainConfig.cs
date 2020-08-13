using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Configuration
{
    public static class DomainConfig
    {
        public static void AddDomainSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ICrudService<User>, CrudService<User>>();

            services
                .AddScoped<IUserService, UserService>();
        }
    }
}
