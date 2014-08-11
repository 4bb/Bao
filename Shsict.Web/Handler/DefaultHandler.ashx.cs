using System;
using System.Collections.Generic;
using System.Web;

using Shsict.Entity;

namespace Shsict.Web
{
    public class DefaultHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            if (!string.IsNullOrEmpty(context.Request.QueryString["object"]))
            {
                string _strObjType = context.Request.QueryString["object"];

                try
                {
                    switch (_strObjType)
                    {
                        case "Favourite":
                            Shsict.Entity.MyFavourite.Cache.RefreshCache();
                            break;
                        case "Notice":
                            Shsict.Entity.Notice.Cache.RefreshCache();
                            break;
                        case "ContainerDetail":
                            ContainerDetail.Cache.RefreshCache();
                            break;
                        case "ContainerEload":
                            ContainerEload.Cache.RefreshCache();
                            break;
                        case "ContainerMain":
                            ContainerMain.Cache.RefreshCache();
                            break;
                        case "ContainerPlan":
                            ContainerPlan.Cache.RefreshCache();
                            break;
                        case "OTruck":
                            OTruck.Cache.RefreshCache();
                            break;
                        case "OVesselPlan":
                            OVesselPlan.Cache.RefreshCache();
                            break;
                        case "PortOfCall":
                            PortOfCall.Cache.RefreshCache();
                            break;
                        case "TVDangerPlan":
                            TVDangerPlan.Cache.RefreshCache();
                            break;
                        case "TVDangerContainer":
                            TVDangerContainer.Cache.RefreshCache();
                            break;
                        default:
                            responseText = string.Empty;
                            break;
                    }

                    responseText = "success";
                }
                catch (Exception ex)
                {
                    responseText = "Exception:" + ex.Message;
                }
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