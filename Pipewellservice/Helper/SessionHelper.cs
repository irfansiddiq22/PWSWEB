

using PipewellserviceModels.Common;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pipewellservice.Helper
{
    public class SessionHelper
    {
        public void SetUserSession(User user)
        {
            user.Password = "";

            HttpContext.Current.Session["User"] = user;
        }
        public User UserSession()
        {
            return (User)HttpContext.Current.Session["User"];
        }
        public PagePermisson PageSession(Pages Page)
        {
            User user = UserSession();

            var p = user.Permissions.Find(x => x.PageID == (int)Page);
            if (p == null) return new PagePermisson() { PageID = (int)Page, CanDelete = false, CanView = false, CanWrite = false };
            return p;
        }
    }
}