using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.API.Tests
{
    public class ClassFixture : IClassFixture<WebApplicationFactory<Program>>
    {

        protected readonly WebApplicationFactory<Program> _factory;



        public ClassFixture(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        public WebApplicationFactory<Program> ReturnFactory()
        {
            return _factory;
        }

    }
}
