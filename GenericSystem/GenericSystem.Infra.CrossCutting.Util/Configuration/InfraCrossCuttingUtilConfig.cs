using GenericSystem.Infra.CrossCutting.Util.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GenericSystem.Infra.CrossCutting.Util.Configuration
{
    public static class InfraCrossCuttingUtilConfig
    {
        public static void AddInfraCrossCuttingUtilSetup(this IServiceCollection services)
        {
            services.AddScoped<ISystemConfiguration, SystemConfiguration>();
        }
    }
}
