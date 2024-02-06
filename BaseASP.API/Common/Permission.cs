using BaseASP.Model.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BaseASP.API.Common
{
    public class Permission : ActionFilterAttribute
    {
        public string Code { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Items["user"] as User;
            if (string.IsNullOrEmpty(Code))
            {
                return;
            }

            List<string> lstAction = Code.Split('|').ToList();
            lstAction = lstAction.Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (!lstAction.Any())
            {
                return;
            }

            var isAccess = true;
        }


    }
}
