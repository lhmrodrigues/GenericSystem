using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Communication.Services;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Communication.Configuration
{
    public static class InfraCrossCuttingCommunicationConfig
    {
        public static void AddInfraCrossCuttingCommunicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ICrudApiService<UserViewModel>, UserApiService>();

            services
                .AddScoped<IUserApiService, UserApiService>();
        }
    }
}
