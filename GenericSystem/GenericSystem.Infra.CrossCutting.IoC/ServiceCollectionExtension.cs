using GenericSystem.Application.Configuration;
using GenericSystem.Domain.Configuration;
using GenericSystem.Infra.CrossCutting.Communication.Configuration;
using GenericSystem.Infra.CrossCutting.Util.Configuration;
using GenericSystem.Infra.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGenericApiSetup(this IServiceCollection services)
        {
            services.AddApplicationSetup();
            services.AddDomainSetup();
            services.AddInfraDataSetup();
            services.AddInfraCrossCuttingUtilSetup();

            return services;
        }

        public static IServiceCollection AddGenericSetup(this IServiceCollection services)
        {
            services.AddInfraCrossCuttingUtilSetup();
            services.AddInfraCrossCuttingCommunicationSetup();

            return services;
        }
    }
}
