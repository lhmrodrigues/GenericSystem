using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Domain.Services;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using Microsoft.AspNetCore.Builder;
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
                .AddScoped<ICrudService<User>, CrudService<User>>()
                .AddScoped<ICrudService<Category>, CrudService<Category>>()
                .AddScoped<ICrudService<Order>, CrudService<Order>>()
                .AddScoped<ICrudService<Product>, CrudService<Product>>()
                .AddScoped<ICrudService<Request>, CrudService<Request>>();


            services
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IRequestService, RequestService>()
                .AddScoped<IProductService, ProductService>();

        }
        public static void UseDomainSetup(this IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                ISystemConfiguration systemConfiguration = scope.ServiceProvider.GetService<ISystemConfiguration>();
            }
        }
    }
}
