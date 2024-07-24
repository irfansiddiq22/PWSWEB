using PipewellserviceJson.Auth;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pipewellservice.Helper
{
    public class CookieHelper
    {
    //    public void AddCookie(UserAuth user)
    //    {

    //        EncryptionHelper enc = new EncryptionHelper();
    //        HttpCookie LoginCookie = new HttpCookie("PWSCookie");
    //        LoginCookie.Value = enc.Encrypt(user.UserName + "%" + user.Password);
    //        LoginCookie.Expires = DateTime.Now.AddDays(30);
    //       HttpContext.Current.Response.Cookies.Add(LoginCookie);
            
    //    }

    //    public void RemoveCookie()
    //    {

    //        if (HttpContext.Current.Response.Cookies["PWSCookie"] != null) {
    //            HttpContext.Current.Response.Cookies.Remove("PWSCookie");
    //        }
                
            

    //    }
        //public bool CheckCookie()
        //{
        //    try

        //    {

        //        if (HttpContext.Current.User != null)
        //        {
        //            HttpCookie LoginCookie = HttpContext.Current.Response.Cookies["PWSCookie"];
        //            if (LoginCookie.Value == null) return false;
        //            if (LoginCookie.Expires < DateTime.Now && LoginCookie.Value!=null)
        //            {
        //                EncryptionHelper enc = new EncryptionHelper();
        //                string Cookie  = enc.Decrypt(LoginCookie.Value);
        //                if (HttpContext.Current.Session["User"] is null)
        //                {
        //                    string Username = Cookie.Split('%')[0];
        //                    string Password = Cookie.Split('%')[1];
        //                    var result = (new AuthUserJson()).ProcessLoginASync(new UserAuth() { UserName = Username, Password = Password });
        //                    if (result.ID > 0)
        //                    {
        //                        new SessionHelper().SetUserSession(result);
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        return false;
        //                    }
        //                }

        //            }
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
        public bool CheckCookie()
        {
            try

            {

                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                {
                    string UserName = HttpContext.Current.User.Identity.Name;
                    if (UserName == null || UserName == "") return false;

                    if (HttpContext.Current.Session["User"] is null)
                    {
                        EncryptionHelper enc = new EncryptionHelper();
                        string Cookie = enc.Decrypt(UserName);

                        string Username = Cookie.Split('`')[0];
                        string Password = Cookie.Split('`')[1];
                        var result = (new AuthUserJson()).ProcessLoginASync(new UserAuth() { UserName = Username, Password = Password });
                        if (result.ID > 0)
                        {
                            new SessionHelper().SetUserSession(result);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }

                 
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}