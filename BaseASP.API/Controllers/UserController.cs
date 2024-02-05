using BaseASP.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [AuthMiddlewareV2]
        [HttpGet("me")]
        // [ServiceFilter(typeof(AuthMiddleware))]
        public async Task<IActionResult> GetUserInfo()
        {
            // var user = HttpContext.Items["user"];
            var user = ControllerContext.
            return Ok(user);
        }
    }
}
