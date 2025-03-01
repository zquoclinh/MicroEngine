using MicroEngine.Framework.Services;
using MicroEngine.Framework.Services.Interface;

namespace MicroEngine.Framework.Configuration
{
    public static class BaseConfiguration
    {
        public static void ConfigureServicesBase(
            this WebApplicationBuilder builder,
            IConfiguration configuration
        )
        {
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
