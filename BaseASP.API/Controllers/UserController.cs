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

        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(ModelState);
        }
    }
}
