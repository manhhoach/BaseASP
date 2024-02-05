using BaseASP.Service.JwtService;
using BaseASP.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BaseASP.API.Common
{
    public class AuthMiddleware : IActionFilter 
    {

        private IJwtService _jwtService;
        private IUserService _userService;
        public AuthMiddleware(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = GetTokenFromHeader(context.HttpContext);
            ClaimsPrincipal principal = _jwtService.DecodeToken(token);
            int id;
            int.TryParse(principal?.FindFirstValue("Id"), out id);
            var user = _userService.GetById(id);
            if (user != null)
            {
                context.HttpContext.Items["user"] = user;
            }

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
