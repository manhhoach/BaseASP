using BaseASP.Service.JwtService;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BaseASP.API.Common
{
    public class AuthMiddleware : IActionFilter
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IJwtService _jwtService;
        public AuthMiddleware(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        public async void OnActionExecuted(ActionExecutedContext context)
        {
            var token = GetTokenFromHeader(context.HttpContext);
            var user = await _jwtService.DecodeToken(token);
            if (user != null)
            {
                //
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        private string GetTokenFromHeader(HttpContext context)
        {
            string token = context.Request.Headers.Authorization.ToString();
            if (!string.IsNullOrEmpty(token))
            {
                if (token.StartsWith("Bearer"))
                {
                    token = token.Split(" ")[1];

                }
            }
            return token;
        }
    }
}
