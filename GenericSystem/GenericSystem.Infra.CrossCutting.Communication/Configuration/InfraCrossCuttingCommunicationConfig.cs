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
                .AddScoped<ICrudApiService<UserViewModel>, UserApiService>()
                .AddScoped<ICrudApiService<CategoryViewModel>, CategoryApiService>()
                .AddScoped<ICrudApiService<OrderViewModel>, OrderApiService>()
                .AddScoped<ICrudApiService<ProductViewModel>, ProductApiService>()
                .AddScoped<ICrudApiService<RequestViewModel>, RequestApiService>();

            services
                .AddScoped<IUserApiService, UserApiService>()
                .AddScoped<ICategoryApiService, CategoryApiService>()
                .AddScoped<IOrderApiService, OrderApiService>()
                .AddScoped<IProductApiService, ProductApiService>()
                .AddScoped<IRequestApiService, RequestApiService>();

        }
    }
}
