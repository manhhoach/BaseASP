using BaseASP.API.Common;
using BaseASP.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IUserService userService) : base(userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("me")]
        [ServiceFilter(typeof(AuthMiddleware))]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = CurrentUser;
            return Ok(user);
        }
    }
}
