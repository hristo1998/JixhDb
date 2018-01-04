namespace JixhDb.Web.Attributes
{
    using System.Web.Mvc;
    using System.Linq;
    using JixhDb.Data;
    
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            

            if (filterContext.HttpContext.Request.IsAuthenticated &&  
                !this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                }; 
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}