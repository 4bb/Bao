using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Shsict.Web
{
    /// <summary>
    /// ContainerAcceptanceList 的摘要说明
    /// </summary>
    public class ContainerAcceptanceList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                string _Custom = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Custom"]))
                    _Custom = context.Request.QueryString["Custom"];

                string _Acceptance = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Acceptance"]))
                    _Acceptance = context.Request.QueryString["Acceptance"];

                string _PlanAccept = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["PlanAccept"]))
                    _PlanAccept = context.Request.QueryString["PlanAccept"];

                #region Bind ContainerAcceptance

                List<ContainerPlan> list = ContainerPlan.Cache.LoadByUsername(_Custom).FindAll(delegate(ContainerPlan c)
                {
                    Boolean returnValue = true;

                    if (!string.IsNullOrEmpty(_Custom))
                    {
                        returnValue = returnValue && (c.custom.Equals(_Custom));

                    }

                    if (_PlanAccept.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        returnValue = returnValue && (c.PLANACCEPT.Equals(_PlanAccept, StringComparison.OrdinalIgnoreCase));
                        if (!string.IsNullOrEmpty(_Acceptance))
                        {
                            if (!string.IsNullOrEmpty(_Acceptance))
                                returnValue = returnValue && (c.ID.Contains(_Acceptance));
                        }
                    }
                    else if (_PlanAccept.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        returnValue = returnValue && (c.PLANACCEPT.Equals(_PlanAccept, StringComparison.OrdinalIgnoreCase));
                        if (!string.IsNullOrEmpty(_Acceptance))
                        {
                            if (!string.IsNullOrEmpty(_Acceptance))
                                returnValue = returnValue && (c.ID.Contains(_Acceptance));
                        }
                    }
                    else
                    {
                        if (_Acceptance != null)
                        {
                            if (!string.IsNullOrEmpty(_Acceptance))
                            {
                                returnValue = returnValue && (c.ID.Equals(_Acceptance, StringComparison.OrdinalIgnoreCase));
                            }
                            else
                            {
                                returnValue = false;
                            }
                        }
                        else
                        {
                            returnValue = false;
                        }
                    }

                    return returnValue;
                });

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