using AutoMapper;
using BaseASP.API.Dto.AuthDto;
using BaseASP.Model.Entities;
using BaseASP.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> Signup(SignUpDto signupDto)
        //{
        //    var user = _mapper.Map<User>(signupDto);
        //    await _userService.Add(user);
        //    return Ok();

        //}

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var signupDto = new SignUpDto() { Email = "test" };

            var user = _mapper.Map<User>(signupDto);
            await _userService.Add(user);
            return Ok();

        }

        // [HttpPost]
        //public async Task<IActionResult> Signin(SignInDto singinDto)
        //{
        //    return Ok();
        //}
    }
}
