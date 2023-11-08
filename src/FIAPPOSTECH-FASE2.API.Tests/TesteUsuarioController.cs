using FIAPPOSTECH_FASE2.DTO.Dtos.Noticia;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class TesteUsuarioController : IClassFixture<GenericApiFactory>
    {
        private readonly GenericApiFactory _genericApiFactory;

        public TesteUsuarioController(GenericApiFactory genericApiFactory)
        {
            _genericApiFactory = genericApiFactory;
        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_UNAUTHORIZED()
        {

            var client = _genericApiFactory.CreateClient();

            var response = await client.GetAsync("/api/Usuario");

            Assert.Equal((int)HttpStatusCode.Unauthorized, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_GET_ALL()
        {
            var client = _genericApiFactory.CreateClient();


            var response = await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);
            response = await client.GetAsync("/api/Usuario");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_GET()
        {
            var client = _genericApiFactory.CreateClient();


            var response = await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);
            response = await client.GetAsync("/api/Usuario/");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }



        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_CREATE()
        {
            var client = _genericApiFactory.CreateClient();

            //Criando o objeto de usuario
            var usuario = new UsuarioCadastroDTO("Usuario teste", "Teste", $"teste{Guid.NewGuid().ToString().Substring(1, 5)}@gmail.com","12345678");

            // obter dados de acesso bearer token

            var response = await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);

            var content = new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");

            response = await client.PostAsync("/api/Usuario", content);

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }
    }
}
