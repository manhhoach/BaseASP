using Amazon.Auth.AccessControlPolicy;
using BaseASP.Model.Entities;
using BaseASP.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace BaseASP.API.Common
{
    public class BaseController: Controller
    {
        private IUserService _userService;

        protected User? CurrentUser;

        public BaseController(IUserService userService) {
            _userService = userService;
        

        }
        private User GetCurrentUser(HttpContext httpContext)
        {
            int id;
            var principal = httpContext.User;
            int.TryParse(principal?.FindFirstValue("Id"), out id);
            return _userService.GetById(id);
        }
    }
}
