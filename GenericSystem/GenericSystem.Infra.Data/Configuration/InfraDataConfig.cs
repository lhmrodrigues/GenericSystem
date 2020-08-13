using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Infra.Data.Context;
using GenericSystem.Infra.Data.Repository;
using GenericSystem.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Configuration
{
    public static class InfraDataConfig
    {
        public static void AddInfraDataSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ICrudRepository<User>, CrudRepository<User>>();


            services
                .AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<GenericSystemsContext>();
        }
    }
}
