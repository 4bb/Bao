using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// VesselPlanPeriodList 的摘要说明
    /// </summary>
    public class VesselPlanPeriodList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _EnglishName = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["EnglishName"]))
                    _EnglishName = context.Request.QueryString["EnglishName"];

                #region Bind VesselEnglishName

                List<OVesselPlan> list = OVesselPlan.Cache.VesselPlanList.FindAll(delegate(OVesselPlan vp)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    DateTime dateTime = DateTime.Now.ToLocalTime();

                    string ArrivePlanTime = vp.ArrivePlanTime.ToString();

                    if (!string.IsNullOrEmpty(ArrivePlanTime))
                    {
                        returnValue = returnValue && DateTime.Parse(ArrivePlanTime).CompareTo(dateTime.AddDays(-2)) > 0;
                    }


                    if (!string.IsNullOrEmpty(_EnglishName))
                    {
                        returnValue = returnValue && vp.VesselEnglishName.Equals(_EnglishName, StringComparison.OrdinalIgnoreCase);
                    }

                    return returnValue;
                });

                if (list != null)
                {
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    responseText = jsonSerializer.Serialize(list);
                }

                //ddlVesselEnglishName.DataSource = query;
                //ddlVesselEnglishName.DataTextField = "EnglishName";
                //ddlVesselEnglishName.DataValueField = "EnglishName";
                //ddlVesselEnglishName.DataBind();

                //ddlVesselEnglishName.Items.Insert(0, new ListItem("全部", string.Empty));

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