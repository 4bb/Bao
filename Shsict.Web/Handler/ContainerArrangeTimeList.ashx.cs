using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Shsict.Web
{
    /// <summary>
    /// ContainerArrangeTimeList 的摘要说明
    /// </summary>
    public class ContainerArrangeTimeList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string responseText = string.Empty;

            try
            {
                string _Custom = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Custom"]))
                    _Custom = context.Request.QueryString["Custom"];

                string _ArrangeTime = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["ArrangeTime"]))
                    _ArrangeTime = context.Request.QueryString["ArrangeTime"];

                string _NoType = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["NoType"]))
                    _NoType = context.Request.QueryString["NoType"];

                #region Bind ContainerAcceptance

                List<TVDangerPlan> list = TVDangerPlan.Cache.LoadByUsername(_Custom).FindAll(delegate(TVDangerPlan t)
                {
                    Boolean returnValue = true;

                    if (!string.IsNullOrEmpty(_Custom))
                    {
                        returnValue = returnValue && (t.CUSTOM.Equals(_Custom));

                    }

                    if (_NoType.Equals("A", StringComparison.OrdinalIgnoreCase))
                    {
                       
                        if (!string.IsNullOrEmpty(_ArrangeTime))
                        {
                            if (!string.IsNullOrEmpty(_ArrangeTime))
                                returnValue = returnValue && (t.ID.Contains(_ArrangeTime));
                        }
                    }
                    else if (_NoType.Equals("P", StringComparison.OrdinalIgnoreCase))
                    {
                       
                        if (!string.IsNullOrEmpty(_ArrangeTime))
                        {
                            if (!string.IsNullOrEmpty(_ArrangeTime))
                                returnValue = returnValue && (t.PLANNO.Contains(_ArrangeTime));
                        }
                    }
                    else
                    {
                        returnValue = false;
                    }

                    return returnValue;
                });

                if (list != null)
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




