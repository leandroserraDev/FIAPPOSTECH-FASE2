using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Infra.Repositories;
using FIAPPOSTECH_FASE2.Services.Interface;
using FIAPPOSTECH_FASE2.Services.Services;

namespace FIAPPOSTECH_FASE2.API.Config
{
    public static class DepencyInjectionConfiguration
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            #region repositorio
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioNotifica, RepositorioNoticia>();
            #endregion

            #region services
            services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IServicoNoticia, ServicoNoticia>();
            #endregion
        }
    }
}
