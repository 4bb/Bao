using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// VesselPlanPeriodName 的摘要说明
    /// </summary>
    public class VesselPlanPeriodName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _EnglishName = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["EnglishName"]))
                    _EnglishName = context.Request.QueryString["EnglishName"];

                #region Bind ddlVesselEnglishName

                List<OVesselPlan> vpList = OVesselPlan.Cache.VesselPlanList.FindAll(delegate(OVesselPlan vp)
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
                       returnValue = returnValue && vp.VesselEnglishName.ToLower().Contains(_EnglishName.ToLower());
                   }

                   return returnValue;
               });
                //List<OVesselPlan> vpList = OVesselPlan.Cache.VesselPlanList;
                var query = from vp in vpList
                            orderby vp.VesselEnglishName descending
                            group vp by new { vp.VesselEnglishName }  into vEngName
                            select new
                            {
                                EnglishName = vEngName.Key.VesselEnglishName
                            };

                if (query != null)
                {
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    responseText = jsonSerializer.Serialize(query);
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



