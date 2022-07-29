using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Altice.Domain.Interfaces.Services;
using Altice.Infrastructure.Services;

namespace Altice.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddScoped<IHelloWorldService, HelloWorldService>();
            services.AddScoped<IFormService, FormService>();

            //Repositories


            return services;
        }
    }
}