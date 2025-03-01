using System.Text;
using MicroEngine.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MicroEngine.Startup
{
    public static class Authentication
    {
        public static IServiceCollection AddAuthenticationService(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var secretKey = services
                .BuildServiceProvider()
                .GetRequiredService<WebApiSetting>()
                .SecretKey;
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        //ValidAudience = configuration["Jwt:Audience"],
                        //ValidIssuer = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretKey)
                        ),
                    };
                });
            return services;
        }
    }
}
