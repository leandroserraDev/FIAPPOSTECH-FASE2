using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Renci.SshNet;
using System.Net;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    [Collection("Sequential")]

    public class TestAuthController : IClassFixture<GenericApiFactory>
    {
        private readonly GenericApiFactory _genericApiFactory;
        private readonly HttpClient _httpClient;

        public TestAuthController(GenericApiFactory genericApiFactory)
        {
            _genericApiFactory = genericApiFactory;
            _httpClient = _genericApiFactory.CreateClient();
        }

    
        [Fact]
        public async Task RETURN_A_STATUS_CODE_BAD_REQUEST_FOR_LOGGIN_NOT_ACCEPTED()
        {

            var client = _httpClient;

            var response =  await _httpClient.GetAsync("/api/Auth?email=administrador%40gmail.com&password=1234567");

            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_FOR_LOGIN_ACCEPCTED()
        {
           

            var response = await _httpClient.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }
    }


}