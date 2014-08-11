using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shsict.Web
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {

            string responseText = string.Empty;

            string _Method = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.QueryString["Method"]))
                _Method = context.Request.QueryString["Method"];

            string _UID = string.Empty;
            if (context.Request.Cookies["uid"] != null)
                _UID = context.Request.Cookies["uid"].Value.ToString();

            if (!string.IsNullOrEmpty(context.Request.QueryString["Method"]))
            {

                if (_Method.Equals("Login"))
                {
                    string _UserName = string.Empty;
                    if (!string.IsNullOrEmpty(context.Request.QueryString["UserName"]))
                        _UserName = context.Request.QueryString["UserName"];

                    string _PassWord = string.Empty;
                    if (!string.IsNullOrEmpty(context.Request.QueryString["PassWord"]))
                        _PassWord = context.Request.QueryString["PassWord"];

                    if (!string.IsNullOrEmpty(_UserName) && !string.IsNullOrEmpty(_PassWord))
                    {
                        ContainerPlanUser user = new ContainerPlanUser();

                        user.Username = _UserName.ToUpper();
                        user.Userpasswd = _PassWord.ToUpper();

                        user.Select();

                        if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Usercd) && !string.IsNullOrEmpty(user.Userpasswd))
                        {
                            context.Response.SetCookie(new HttpCookie("uid", user.Username));
                            context.Response.SetCookie(new HttpCookie("custom", user.Usercd));

                            if (_UID != null)
                            {
                                responseText = "succeed";
                            }
                        }
                        else
                        {
                            responseText = "failed";
                        }
                    }
                    else
                    {
                        responseText = "failed";

                    }
                }
                else if (_Method.Equals("Logout"))
                {
                    try
                    {
                        if (_UID != null)
                        {
                            if (context.Request.Cookies["uid"] != null)
                            {
                                HttpCookie mycookie;
                                mycookie = context.Request.Cookies["uid"];
                                TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                                mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                                context.Response.Cookies.Remove("uid");//清除 
                                context.Response.Cookies.Add(mycookie);//写入立即过期的*/
                                context.Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                            }
                            if (context.Request.Cookies["custom"] != null)
                            {
                                HttpCookie mycookie;
                                mycookie = context.Request.Cookies["custom"];
                                TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                                mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                                context.Response.Cookies.Remove("custom");//清除 
                                context.Response.Cookies.Add(mycookie);//写入立即过期的*/
                                context.Response.Cookies["custom"].Expires = DateTime.Now.AddDays(-1);
                            }
                            if (context.Request.Cookies["NextURL"] != null)
                            {
                                HttpCookie mycookie;
                                mycookie = context.Request.Cookies["NextURL"];
                                TimeSpan ts = new TimeSpan(0, 0, 0, 0);//时间跨度 
                                mycookie.Expires = DateTime.Now.Add(ts);//立即过期 
                                context.Response.Cookies.Remove("NextURL");//清除 
                                context.Response.Cookies.Add(mycookie);//写入立即过期的*/
                                context.Response.Cookies["NextURL"].Expires = DateTime.Now.AddDays(-1);
                            }

                        }
                        responseText = "succeed";
                    }
                    catch
                    {
                        responseText = "succeed";
                    }

                }

                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write(responseText);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}

