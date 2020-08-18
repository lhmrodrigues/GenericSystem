using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.IoC
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseGenericSystemApiSetup(this IApplicationBuilder app)
        {
            //app.UseDomainSetup();

            return app;
        }
    }
}
