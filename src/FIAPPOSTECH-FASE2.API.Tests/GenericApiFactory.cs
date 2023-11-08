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
        .WithExposedPort(3307)
            .WithPortBinding(3307, 3307)
            .WithEnvironment("MYSQL_PASSWORD", "MarcaDagua1234")
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "MarcaDagua1234")
            .WithEnvironment("MYSQL_DATABASE", "fiappos")
            .WithEnvironment("MYSQL_USER", "sa")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(3307))
            .Build();

        public Task InitializeAsync() =>
          _mySqlContainer.StartAsync();

       
        public Task  StopAsync()
        {
           return _mySqlContainer.StopAsync();
        }

        public Task DisposeAsync()
        {
            return StopAsync();
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

            options.UseMySql($"Server={_mySqlContainer.Hostname};Port=3307;Database=fiappos;Uid=sa;Pwd=MarcaDagua1234;", serverVersion)
                );

            var dbContext=  services.BuildServiceProvider().GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var usuario = new Usuario("Administrador", "Administrador Geral", "administrador@gmail.com", "12345678");

                usuario.GerarSenha();
                var sd = new object[]
                   {
                   1 ,
                   usuario.Nome.ToString(),
                   usuario.Sobrenome.ToString(),
                   usuario.Email.ToString(),
                   usuario.Password.ToString(),
                   usuario.SaltHash.ToString()
                   };
            dbContext.Add(usuario);
            dbContext.SaveChanges();
             //   dbContext.Database.ExecuteSqlRaw(
             // $@"INSERT INTO Usuario(Id, Nome, Sobrenome, Email,Password, SaltHash) VALUES({0}, {1}, {2}, {3}, {4}, {5})",
             //1,
             //usuario.Nome,
             //usuario.Sobrenome,
             //usuario.Email,
             //usuario.Password,
             //usuario.SaltHash
             //  );
            });


        }

      
    }
}
