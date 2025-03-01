using MicroEngine.Framework.Entity;
using MicroEngine.Framework.Services;
using MicroEngine.Framework.Services.Interface;
using MicroEngine.Services;

namespace MicroEngine.Framework.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
