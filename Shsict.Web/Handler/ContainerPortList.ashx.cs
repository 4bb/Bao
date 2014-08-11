using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// ContainerPortList 的摘要说明
    /// </summary>
    public class ContainerPortList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _ContainerPort = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["ContainerPort"]))
                    _ContainerPort = context.Request.QueryString["ContainerPort"];

                string _Type = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Type"]))
                    _Type = context.Request.QueryString["Type"];


                List<ContainerEload> list ;
       
                        if (_Type.Equals("c", StringComparison.OrdinalIgnoreCase))
                        {
                            list = ContainerEload.Cache.LoadByContainerNo(_ContainerPort.ToUpper());
                        }
                        else if (_Type.Equals("b", StringComparison.OrdinalIgnoreCase))
                        {
                            list = ContainerEload.Cache.LoadByBillno(_ContainerPort.ToUpper());
                        }
                        else
                        {
                            throw new Exception("传参不正确");
                        }

                        if (list != null)
                        {
                            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                            responseText = jsonSerializer.Serialize(list);
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