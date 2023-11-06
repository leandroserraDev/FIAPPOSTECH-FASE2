using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class TestAuthController : ClassFixture
    {


        public TestAuthController(WebApplicationFactory<Program> factory)
            :base(factory)
        {
        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_BAD_REQUEST_FOR_LOGGIN_NOT_ACCEPTED()
        {
            
            var client = _factory.CreateClient();

            var response =  await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=1234567");

            Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);

        }

        [Fact]
        public async Task RETURN_A_STATUS_CODE_OK_FOR_LOGIN_ACCEPCTED()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/Auth?email=administrador%40gmail.com&password=12345678");

            Assert.Equal((int)HttpStatusCode.OK, (int)response.StatusCode);

        }
    }


}