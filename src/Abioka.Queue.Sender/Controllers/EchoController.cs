using Microsoft.AspNetCore.Mvc;

namespace Abioka.Queue.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get() => Ok("Ok");
    }
}
