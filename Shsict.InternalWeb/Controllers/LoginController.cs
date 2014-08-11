using Shsict.InternalWeb.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shsict.InternalWeb.Controllers
{
    public class LoginController : Controller
    {
        public static string ToUrl;

        public ActionResult Index(string returnUrl)
        {
            if (returnUrl == null)
            {
                returnUrl = ToUrl;
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
            }

            if (returnUrl.IndexOf("Pad") > 0)
            {
                return RedirectToAction("Pad");
            }
            else
            {
                return RedirectToAction("Phone");
            }
        }

        public ActionResult Phone(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        public ActionResult Pad(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public void LogOn(FormCollection collection, LoginModel model)
        {
            if (model.SUR_USERACCOUNT != null && model.SUR_PASSWORD != null)
            {
                List<LoginModel> user = LoginModel.GetLoginModelByUserName(model.SUR_USERACCOUNT);

                bool isTrue;
                Response.ContentType = "text/html";

                if (user.Count > 0)
                {
                    isTrue = user.Exists(t => t.SUR_PASSWORD.Equals(model.SUR_PASSWORD));
                    if (isTrue)
                    {
                        List<UserResource> _userResource = UserResource.GetUserResourceByUserName(model.SUR_USERACCOUNT);

                        string permissions = "";

                        if (_userResource.Count != 0)
                        {

                            foreach (UserResource items in _userResource)
                            {
                                switch (items.SUR_RESOURCECODE)
                                {
                                    case "1":
                                        permissions += "ZY,";
                                        break;
                                    case "2":
                                        permissions += "SC,";
                                        break;
                                    case "3":
                                        permissions += "ZYL,";
                                        break;
                                    case "4":
                                        permissions += "JX,";
                                        break;
                                    case "5":
                                        permissions += "CQ,";
                                        break;
                                }
                            }
                            if (permissions.IndexOf(',') > 0)
                            {
                                permissions = permissions.Substring(0, permissions.Length - 1);
                            }
                        }
                        Response.SetCookie(new HttpCookie("uid", collection[0]));
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                              1,
                              collection[0],
                              DateTime.Now,
                              DateTime.Now.AddMinutes(30),
                              false,
                              permissions
                              );
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                        Response.Write("success");

                    }
                    else
                    {
                        Response.Write("提示：用户名与密码不匹配");
                    }
                }
                else
                {
                    Response.Write("提示：用户名不存在，请检查");
                }
            }
            else
            {
                Response.Write("error");
            }
        }

      
        public void LogOff()
        {
            Response.Cookies.Remove("uid");
            ToUrl = "phone";
            FormsAuthentication.SignOut();
            Response.Write("success");
        }
    
        public void PadLogOff()
        {
            Response.Cookies.Remove("uid");
            ToUrl = "Pad";
            FormsAuthentication.SignOut();
            Response.Write("success");
        }
    }
}
