using AutoMapper;
using BaseASP.API.Common;
using BaseASP.API.Dto.AuthDto;
using BaseASP.Model.Entities;
using BaseASP.Service.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;

        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Signup(SignUpDto signupDto)
        {
            try
            {
                var user = _mapper.Map<User>(signupDto);
                await _authService.SignUp(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(false, StatusCodes.Status400BadRequest, ex.Message, null));
            }
            return Ok(new APIResponse<object>(true, StatusCodes.Status201Created));

        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Signin(SignInDto singinDto)
        {
            try
            {
                var user = _mapper.Map<User>(singinDto);
                string token = await _authService.SignIn(user);
                return Ok(new APIResponse<object>(true, StatusCodes.Status201Created, "Login Successfully", token));
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(false, StatusCodes.Status400BadRequest, ex.Message, null));
            }
            
        }
    }
}
