using AutoMapper;
using BaseASP.API.Common;
using BaseASP.API.Dto.AuthDto;
using BaseASP.Model.Entities;
using BaseASP.Service.AuthService;
using BaseASP.Service.RedisService;
using Microsoft.AspNetCore.Mvc;

namespace BaseASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IRedisService _redisService;
        public AuthController(IAuthService authService, IMapper mapper, IRedisService redisService)
        {
            _authService = authService;
            _mapper = mapper;
            _redisService = redisService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Signup(SignUpDto signupDto)
        {
            try
            {
                _redisService.Set("test", "test 1x23");
                var user = _mapper.Map<User>(signupDto);
                await _authService.SignUp(user);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(new APIResponse<object>(true, StatusCodes.Status201Created));

        }

        [HttpPost]
        public async Task<IActionResult> Signin(SignInDto singinDto)
        {
            return Ok();
        }
    }
}
