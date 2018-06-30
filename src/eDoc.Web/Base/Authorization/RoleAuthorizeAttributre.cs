using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eDoc.Model.Common.Enums;
using eDoc.Model.UnitOfWork;
using Microsoft.AspNet.Identity;

namespace eDoc.Web.Base.Authorization
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAccessPoint ApplicationRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            var uow = DependencyResolver.Current.GetService<DbUnitOfWork>();
            string curUserId = httpContext.User.Identity.GetUserId();
            var dbRole = uow.Users.GetWithRole(curUserId).Role;

            if (dbRole == null)
                return false;

            return ApplicationRoles.HasFlag((RoleAccessPoint)dbRole.Role);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}