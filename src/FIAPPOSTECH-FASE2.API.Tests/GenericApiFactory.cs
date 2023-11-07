using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class GenericApiFactory : WebApplicationFactory<Program>
    {
        
        private readonly IContainer _mySqlContainer = new ContainerBuilder()
            .WithImage("mysql:latest")
            .WithEnvironment("MSSQL_SA_PASSWORD", "1233321321")
            .WithPortBinding(5432, 5432)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
            .Build();


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
          

            builder.ConfigureServices(services =>
            {
            var dbContextOptionsDescriptor = services.SingleOrDefault(d =>
            d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ApplicationDbContext));

            services.Remove(dbContextDescriptor);
            services.Remove(dbContextOptionsDescriptor);
             
                
                var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));

                services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql("Server=localhost;Port=3306;Database=FIAPPOSTDATABASE;Uid=root;Pwd=FIAPPOS2023;", serverVersion)
                );

            var dbContext=  services.BuildServiceProvider().GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var usuario = new Usuario("Administrador", "Administrador Geral", "administrador@gmail.com", "12345678");

                usuario.GerarSenha();

                dbContext.Database.ExecuteSqlRaw(
               $"INSERT INTO Usuario(Id, Nome, Sobrenome, Email,Password, SaltHash) VALUES({0}, {1}, {2}, {3}, {4}, {5})",
               new object[]
                   {
                   1 ,
                   usuario.Nome.ToString(),
                   usuario.Sobrenome.ToString(), 
                   usuario.Email.ToString(), 
                   usuario.Password.ToString(), 
                   usuario.SaltHash.ToString()
                   });
            });

           

        }

        public async Task InitializeAsync()
        {
            await _mySqlContainer.StartAsync();
        }

    }
}
