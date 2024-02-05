using BaseASP.Model.Entities;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BaseASP.API.Common
{
    public class AuthMiddlewareV2Attribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext context)
        {
            //var token = GetTokenFromHeader(context.HttpContext);
            //ClaimsPrincipal principal = _jwtService.DecodeToken(token);
            //int id;
            //int.TryParse(principal?.FindFirstValue("Id"), out id);
            //var user = _userService.GetById(id);
            var user = new User();
            if (user != null)
            {
                context.ActionArguments["user"] = user;
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
