using GenericSystem.Infra.CrossCutting.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Security.Configuration
{
    public static class InfraCrossCuttingSecutiryConfig
    {
        public static void AddInfraCrossCuttingSecutirySetup(this IServiceCollection services)
        {
            services.AddScoped<ICryptographyManager, CryptographyManager>();
        }
    }
}
