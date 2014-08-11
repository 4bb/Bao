using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

using Shsict.Entity;
using System.Collections.Specialized;
using System.Text;

namespace Shsict.Web
{
    /// <summary>
    /// TruckImportExportList 的摘要说明
    /// </summary>
    public class TruckImportExportList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;
            try
            {
                string _Truck = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Truck"]))
                {     //_Truck = context.Request.QueryString["Truck"];
                    NameValueCollection gb2312Requests = HttpUtility.ParseQueryString(context.Request.Url.Query, Encoding.GetEncoding("utf-8"));
                    _Truck = gb2312Requests["Truck"];
                }


                List<OTruck> list = OTruck.Cache.TruckList.FindAll(delegate(OTruck t)
                 {
                     Boolean returnValue = true;
                     string tmpString = string.Empty;
                     DateTime dateTime = DateTime.Now.ToLocalTime();

                     string ArriveYardTime = t.ArriveYardTime.ToString();

                     if (!string.IsNullOrEmpty(ArriveYardTime))
                     {
                         returnValue = returnValue && DateTime.Parse(ArriveYardTime).CompareTo(dateTime.AddDays(-10)) >0;
                     }

                     if (_Truck != null)
                     {
                         tmpString = _Truck;
                         if (!string.IsNullOrEmpty(tmpString))
                             returnValue = returnValue && (t.TruckNo.Equals(tmpString, StringComparison.OrdinalIgnoreCase));
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