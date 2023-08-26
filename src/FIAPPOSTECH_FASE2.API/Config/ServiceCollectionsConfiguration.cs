
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FIAPPOSTECH_FASE2.API.Config
{
    public static class ServiceCollectionsConfiguration
    {
        public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(ct =>
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
                var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));

                ct.UseMySql(config.GetConnectionString("Connection"), serverVersion);
            });

            return services;
        }

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


        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, WebApplicationBuilder builder)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIContagem", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement

                {

                    {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"

                }

            },
            Array.Empty<string>()

                    }

                });
            });

            return services;


        }
    }

}
