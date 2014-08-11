using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// VesselPlanContainerList 的摘要说明
    /// </summary>
    public class VesselPlanContainerList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _vn = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["VN"]))
                    _vn = context.Request.QueryString["VN"];

                #region Bind VesselContainer

                List<OVesselPlan> list = OVesselPlan.Cache.VesselPlanList.FindAll(delegate(OVesselPlan vp)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    DateTime dateTime = DateTime.Now.ToLocalTime();

                    string ContainerBeginTime = vp.ContainerBeginTime.ToString();

                    if (!string.IsNullOrEmpty(_vn))
                    {
                        returnValue = returnValue && vp.VesselName.Contains(_vn) || returnValue && vp.VesselEnglishName.Contains(_vn);
                    }
                    

                    //出口
                    if (!string.IsNullOrEmpty(vp.ImportOrExportFlag))
                    {
                        returnValue = returnValue && vp.ImportOrExportFlag.Equals("E");
                    }

                    //大船
                    if (!string.IsNullOrEmpty(vp.VesselType))
                    {
                        returnValue = returnValue && vp.VesselType.Equals("D");
                    }

                    //计划在港
                    if (vp.Status == "P" || vp.Status == "I")
                    {
                        returnValue = returnValue && true;
                    }

                    //进箱开始desc 船名 asc

                    if (!string.IsNullOrEmpty(ContainerBeginTime))
                    {
                        returnValue = returnValue && DateTime.Parse(ContainerBeginTime).CompareTo(dateTime.AddDays(-15)) > 0;
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