using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAPPOSTECH_FASE2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() {
            return Ok();
        }
        [HttpPost]
        public ActionResult Post()  
        {
            return Ok();
        } 
    }
}
