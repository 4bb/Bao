using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// ContainerPlanList 的摘要说明
    /// </summary>
    public class ContainerPlanList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _ContainerNoOrbill = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["ContainerNoOrbill"]))
                    _ContainerNoOrbill = context.Request.QueryString["ContainerNoOrbill"];

                string _Type = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Type"]))
                    _Type = context.Request.QueryString["Type"];

                #region Bind VesselContainer

                List<ContainerMain> list;

                    if (_Type.Equals("c", StringComparison.OrdinalIgnoreCase))
                    {
                        list = ContainerMain.Cache.LoadByContainerNo(_ContainerNoOrbill.ToUpper());
                    }
                    else if (_Type.Equals("b", StringComparison.OrdinalIgnoreCase))
                    {
                        list = ContainerMain.Cache.LoadByBillno(_ContainerNoOrbill.ToUpper());
                    }
                    else
                    {
                        throw new Exception("传参不正确");
                    }
                
                    if (list != null )
                    {
                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        responseText = jsonSerializer.Serialize(list);
                    }

                #endregion
                
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