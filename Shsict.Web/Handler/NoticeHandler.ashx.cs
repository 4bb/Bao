using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// Summary description for NoticeHandler
    /// </summary>
    public class NoticeHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(context.Request.QueryString["Method"]))
                {
                    Entity.Notice.Cache.RefreshCache();

                    responseText = "success";
                }
                else
                {
                    throw new Exception("传参错误，请重试");
                }
            }
            catch (Exception ex)
            {
                responseText = ex.Message;
            }

            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.Write(responseText);
            context.Response.End();
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