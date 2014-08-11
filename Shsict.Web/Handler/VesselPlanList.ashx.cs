using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

using Shsict.Entity;

namespace Shsict.Web
{
    public class VesselPlanList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                string _strImportOrExportFlag = string.Empty;
                string _strVesselType = string.Empty;
                string _strStatus = string.Empty;

                if (!string.IsNullOrEmpty(context.Request.QueryString["ImportOrExportFlag"]))
                    _strImportOrExportFlag = context.Request.QueryString["ImportOrExportFlag"];

                if (!string.IsNullOrEmpty(context.Request.QueryString["VesselType"]))
                    _strVesselType = context.Request.QueryString["VesselType"];

                if (!string.IsNullOrEmpty(context.Request.QueryString["Status"]))
                    _strStatus = context.Request.QueryString["Status"];

                List<OVesselPlan> list = OVesselPlan.Cache.VesselPlanList.FindAll(delegate(OVesselPlan vp)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    DateTime dateTime = DateTime.Now.ToLocalTime();

                    string DepartureActualTime = vp.DepartureActualTime.ToString();
                    string ArrivePlanTime = vp.ArrivePlanTime.ToString();
                    string DeparturePlanTime = vp.DeparturePlanTime.ToString();

                    if (vp.Status == "O" && !string.IsNullOrEmpty(DepartureActualTime))
                    {
                        returnValue = returnValue && DateTime.Parse(DepartureActualTime).CompareTo(dateTime.AddDays(-2)) > 0;
                    }

                    if (vp.Status == "P" && !string.IsNullOrEmpty(ArrivePlanTime))
                    {
                        returnValue = returnValue && DateTime.Parse(ArrivePlanTime).CompareTo(dateTime) > 0 && DateTime.Parse(ArrivePlanTime).CompareTo(dateTime.AddDays(2)) < 0;
                    }

                    if (!string.IsNullOrEmpty(_strImportOrExportFlag))
                    {
                        returnValue = returnValue && vp.ImportOrExportFlag.Equals(_strImportOrExportFlag, StringComparison.OrdinalIgnoreCase);
                    }

                    if (!string.IsNullOrEmpty(_strVesselType))
                    {
                        returnValue = returnValue && vp.VesselType.Equals(_strVesselType);
                    }

                    if (!string.IsNullOrEmpty(_strStatus))
                    {
                        returnValue = returnValue && vp.Status.Equals(_strStatus, StringComparison.OrdinalIgnoreCase);
                    }

                    return returnValue;
                });

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