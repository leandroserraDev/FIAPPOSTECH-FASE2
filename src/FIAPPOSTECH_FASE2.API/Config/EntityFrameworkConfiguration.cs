
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FIAPPOSTECH_FASE2.API.Config
{
    public static class EntityFrameworkConfiguration
    {
        public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(ct =>
            {

                var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));

                ct.UseMySql(builder.Configuration.GetConnectionString("Connection"), serverVersion);
            });

            return services;
        }


     
    }

}
