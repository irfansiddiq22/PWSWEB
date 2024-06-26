﻿

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
        public void LogOut()
        {
            HttpContext.Current.Session.RemoveAll();
        }
        public void SetUserSession(User user)
        {
            user.Password = "";
            HttpContext.Current.Session["User"] = user;
        }
        public User UserSession()
        {
            return (User)HttpContext.Current.Session["User"];
        }
        public int UserGroup()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                return ((User)HttpContext.Current.Session["User"]).GroupID;
            }
            else
            {
                return 0;
            }
        }

        public int EmployeeID()
        {
            return ((User)HttpContext.Current.Session["User"]).EmployeeID;
        }
        public int UserID()
        {
            return ((User)HttpContext.Current.Session["User"]).ID;
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