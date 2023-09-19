using Microsoft.Extensions.DependencyInjection;
using Some.Application.Services.Client;
using Some.Domain.Services;
using System;

namespace Some.Application.Configuration.Client
{
    public class ConfigurationBase
    {
        public virtual IServiceProvider GetConfiguration(ServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationService>();


            return services.BuildServiceProvider();
        }

    }
}
