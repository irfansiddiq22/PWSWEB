using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pipewellservice.Helper
{
    public class Authorization : AuthorizeAttribute
    {
        private Pages Page;
        private bool? Write;
        private bool? Delete;
        public Authorization() : base()
        {
            Page = Pages.None;
        }
        public Authorization(Pages Page) : base()
        {
            this.Page = Page;
        }
        public Authorization(Pages Page, int Write, int Delete) : base()
        {
            this.Page = Page;
            this.Write = null;
            this.Delete = null;

            if (Write < 2)
                this.Write = Write == 1;
            if (Delete < 2)
                this.Delete = Delete == 1;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            if (HttpContext.Current.Session["User"] != null)
            {
                authorize = true;


                if (Page != Pages.None)
                {
                    SessionHelper helper = new SessionHelper();
                    var permission = helper.PageSession(Page);
                    if (permission.CanDelete || permission.CanWrite || permission.CanView)
                    {
                        authorize = true;
                    }
                    else
                    {
                        authorize = false;
                    }
                    if (Write != null && !permission.CanWrite)
                        authorize = false;
                    if (Delete != null && !permission.CanDelete)
                        authorize = false;

                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new HttpUnauthorizedResult();

            if (HttpContext.Current.Session["User"] != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "home", action = "AccessDenied" }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "auth", action = "Index" }));
            }

        }
    }


}