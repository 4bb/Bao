using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Shsict.Web
{
    /// <summary>
    /// ContainerPlanDetail 的摘要说明
    /// </summary>
    public class ContainerPlanDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            string _containerID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.QueryString["ContainerID"]))

                _containerID = context.Request.QueryString["ContainerID"];

            try
            {
                ContainerDetail con = ContainerDetail.Cache.Load(_containerID); ;

                if (con != null)
                {
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    responseText = jsonSerializer.Serialize(con);
                }
            }
            catch (Exception ex)
            {
                responseText = string.Format("{{  \"result\": \"error\", \"error_msg\": \"{0}\" }}", ex.Message);
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