using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeeperMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "hello world";
        }
    }
}
