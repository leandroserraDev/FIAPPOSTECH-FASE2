using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Xunit;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class GenericApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {

        protected readonly IContainer _mySqlContainer = new ContainerBuilder()
            .WithImage("mysql:8.1.0")
            .WithExposedPort(3306)
            .WithPortBinding(3306, 3306)
            .WithEnvironment("MYSQL_PASSWORD", "MarcaDagua1234")
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "MarcaDagua1234")
            .WithEnvironment("MYSQL_DATABASE", "fiappos")
            .WithEnvironment("MYSQL_USER", "sa")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(3306))
            .Build();

        public Task InitializeAsync()
        {
            if (_mySqlContainer.State != TestcontainersStates.Running
                    &&
                    _mySqlContainer.State != TestcontainersStates.Created
                    &&
                    _mySqlContainer.State != TestcontainersStates.Paused


                    )
            {
                return _mySqlContainer.StartAsync();

            }

            return null;
        }
        public new async Task DisposeAsync()
        {

            await StopAsync();


        }

        public Task StopAsync()
        {
            return _mySqlContainer.DisposeAsync().AsTask();
        }


        protected override async void ConfigureWebHost(IWebHostBuilder builder)
        {


            builder.ConfigureServices(async services =>
            {
                var dbContextOptionsDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ApplicationDbContext));

                services.Remove(dbContextDescriptor);
                services.Remove(dbContextOptionsDescriptor);


                var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));

                services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql($"Server={_mySqlContainer.Hostname};Port=3306;Database=fiappos;Uid=sa;Pwd=MarcaDagua1234;", serverVersion)
                );

                var dbContext = services.BuildServiceProvider().GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var usuario = new Usuario("Administrador", "Administrador Geral", "administrador@gmail.com", "12345678");

                usuario.GerarSenha();
                dbContext.Add(usuario);
                dbContext.SaveChanges();
            });


        }


    }
}
