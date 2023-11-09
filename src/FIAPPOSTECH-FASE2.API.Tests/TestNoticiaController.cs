using FIAPPOSTECH_FASE2.DTO.Dtos.Noticia;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    [Collection("Sequential")]

    public class TestNoticiaController : IClassFixture<GenericApiFactory>
    {
      private readonly GenericApiFactory _genericApiFactory;
        private readonly HttpClient _httpClient;
        public TestNoticiaController(GenericApiFactory genericApiFactory)
        {
            _genericApiFactory = genericApiFactory;
            _httpClient = genericApiFactory.CreateClient(); ;
        }




        [Fact]
        public async Task RETURN_A_STATUS_CODE_UNAUTHORIZED()
        {


            var response = await _httpClient.GetAsync("/api/Noticia");

            Assert.Equal((int)HttpStatusCode.Unauthorized, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_GET_ALL_NEWS()
        {
            var client = _httpClient;


            var response = await client.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);
            response = await client.GetAsync("/api/Noticia"); 

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode); 

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_GET_NEWS()
        {
            var client = _httpClient;


            var response = await client.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);
            response = await client.GetAsync("/api/Noticia");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_GET_NEWS_BY_AUTHOR()
        {
            var client = _httpClient;



            var response = await client.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);

            response = await client.GetAsync("/api/Noticia/Autor/1");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }


        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_CREATE_NEWS()
        {
            var client = _httpClient;

            //Criando o objeto de noticia
            var noticiaPost = new NoticiaCadastroDTO("Noticia teste", "Testando o cadastro da notícia teste");

            // obter dados de acesso bearer token

            var response = await client.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");
            var bearer = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Authorization = new("Bearer", bearer);

            var content = new StringContent(JsonSerializer.Serialize(noticiaPost), Encoding.UTF8, "application/json");

            response = await client.PostAsync("/api/Noticia", content);

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }

        
    }
}
