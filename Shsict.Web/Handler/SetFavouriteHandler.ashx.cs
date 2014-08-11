using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

using Shsict.Entity;

namespace Shsict.Web
{
    /// <summary>
    /// SetFavouriteHandler 的摘要说明
    /// </summary>
    public class SetFavouriteHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string responseText = string.Empty;

            try
            {
                string _url = string.Empty;
                string _username = string.Empty;

                if (!string.IsNullOrEmpty(context.Request.QueryString["PageUrl"]))
                {
                    _url = context.Request.QueryString["PageUrl"];
                }

                if (context.Request.Cookies["uid"] != null)
                {
                    _username = context.Request.Cookies["uid"].Values.ToString();
                }

                if (!string.IsNullOrEmpty(context.Request.QueryString["Method"]))
                {
                    if (context.Request.QueryString["Method"].Equals("get"))
                    {
                        #region Check Favourite Code
                        MyFavourite mf = MyFavourite.Cache.FavouriteList_Active.Find(f =>
                            f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase));

                        if (mf != null)
                        {
                            mf.STATUS = 0;
                            mf.Update();

                            MyFavourite.Cache.RefreshCache();

                            responseText = Boolean.TrueString;
                        }
                        else
                        {
                            responseText = Boolean.FalseString;
                        }
                        #endregion
                    }
                    else if (context.Request.QueryString["Method"].Equals("dele"))
                    {
                        if (!string.IsNullOrEmpty(_username))
                        {
                            #region Remove Favourite Code
                            MyFavourite mf = MyFavourite.Cache.FavouriteList_Active.Find(f =>
                               f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase));

                            if (mf != null)
                            {
                                mf.ISACTIVE = 0;
                                mf.Update();

                                MyFavourite.Cache.RefreshCache();

                                responseText = "success";
                            }
                            else
                            {
                                throw new Exception("收藏夹中未找到对应关注项");
                            }
                            #endregion
                        }
                        else
                        {
                            throw new Exception("nologin");
                        }
                    }
                    else if (context.Request.QueryString["Method"].Equals("post"))
                    {
                        if (!string.IsNullOrEmpty(_username))
                        {
                            #region Add Favourtie Code
                            string _objectID = string.Empty;
                            if (!string.IsNullOrEmpty(context.Request.QueryString["ObjectID"]))
                                _objectID = context.Request.QueryString["ObjectID"];

                            string _objectType = string.Empty;
                            if (!string.IsNullOrEmpty(context.Request.QueryString["ObjectType"]))
                                _objectType = context.Request.QueryString["ObjectType"];


                            if (MyFavourite.Cache.FavouriteList_Active.Exists(f =>
                               f.USERNAME.Equals(_username, StringComparison.OrdinalIgnoreCase) && f.URL.Equals(_url, StringComparison.OrdinalIgnoreCase)
                               && f.OBJECTID.Equals(_objectID, StringComparison.OrdinalIgnoreCase) && f.OBJECTTYPE.Equals(_objectType, StringComparison.OrdinalIgnoreCase)))
                            {
                                throw new Exception("收藏夹中已有相同关注项");
                            }

                            MyFavourite fav = new MyFavourite();

                            fav.ID = "";
                            fav.URL = _url;
                            fav.USERNAME = _username;
                            fav.UPDATETIME = DateTime.Now;
                            fav.CREATETIME = DateTime.Now;
                            fav.STATUS = 0;
                            fav.OBJECTID = _objectID;
                            fav.OBJECTTYPE = _objectType;

                            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                            string _objectContent = "";

                            switch (_objectType)
                            {
                                case "ContainerEload":
                                    ContainerEload listContainerEload = ContainerEload.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listContainerEload);
                                    break;
                                case "ContainerMain":
                                case "ContainerDetail":
                                    ContainerMain listContainerMain = ContainerMain.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listContainerMain);
                                    break;
                                case "ContainerPlan":
                                    ContainerPlan listContainerPlan = ContainerPlan.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listContainerPlan);
                                    break;
                                case "Truck":
                                    OTruck listOTruck = OTruck.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listOTruck);
                                    break;
                                case "VesselPlan":
                                    OVesselPlan listOVesselPlan = OVesselPlan.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listOVesselPlan);
                                    break;
                                case "TVDangerPlan":
                                    TVDangerPlan listTVDangerPlan = TVDangerPlan.Cache.Load(_objectID);
                                    _objectContent = jsonSerializer.Serialize(listTVDangerPlan);
                                    break;
                                default:
                                    break;
                            }

                            fav.OBJECTCONTENT = _objectContent;
                            fav.ISACTIVE = 1;
                            fav.REMARK = string.Empty;

                            fav.Insert();

                            MyFavourite.Cache.RefreshCache();

                            responseText = "success";

                            #endregion
                        }
                        else
                        {
                            throw new Exception("nologin");
                        }
                    }
                    else if (context.Request.QueryString["Method"].Equals("refresh"))
                    {
                        if (!string.IsNullOrEmpty(_username))
                        {
                            MyFavourite.RefreshByUser(_username, "cache");

                            responseText = "success";
                        }
                        else
                        {
                            throw new Exception("nologin");
                        }
                    }
                }
                else
                {
                    throw new Exception("传参错误，请重试");
                }

            }
            catch (Exception ex)
            {
                responseText = ex.Message;
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