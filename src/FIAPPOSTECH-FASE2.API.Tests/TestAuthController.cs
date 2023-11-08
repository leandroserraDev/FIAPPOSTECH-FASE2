using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class TestAuthController : IClassFixture<GenericApiFactory>
    {
        private readonly GenericApiFactory _genericApiFactory;

        public TestAuthController(GenericApiFactory genericApiFactory)
        {
            _genericApiFactory = genericApiFactory;
        }


        [Fact]
        public async Task RETURN_A_STATUS_CODE_BAD_REQUEST_FOR_LOGGIN_NOT_ACCEPTED()
        {

            var client = _genericApiFactory.CreateClient();

            var response =  await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=1234567");

            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_FOR_LOGIN_ACCEPCTED()
        {
            var client = _genericApiFactory.CreateClient();

            var response = await client.GetAsync("/api/Auth?email=administrador@gmail.com&password=12345678");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }
    }


}