using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FIAPPOSTECH_FASE2.API.Config
{
    public static class JWTConfiguration
    {
        public static IServiceCollection ConfigureJWT(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var appSettings = builder.Configuration.GetSection("AppSetting").Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Segredo);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(j =>
            {
                j.RequireHttpsMetadata = true;
                j.SaveToken = true;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });


            return services;
        }


    }
}
