using BaseASP.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [ServiceFilter(typeof(AuthMiddleware))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("me")]

        [Permission(Code = "Ảo thật")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = HttpContext.Items["user"];
            return Ok(user);
        }
    }
}
