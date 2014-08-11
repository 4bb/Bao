using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Favourite : PageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AnonymousRedirect = true;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnVisible(false);

            //master.setRefreshFavouriteBtn(true);

            BindData();
        }

        private void BindData()
        {
            try
            {
                List<MyFavourite> list = MyFavourite.Cache.FavouriteList_Active.FindAll(delegate(MyFavourite f) { return f.USERNAME.Equals(UID); });

                rptrFavourite.DataSource = list;
                rptrFavourite.DataBind();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(typeof(string), "failed", string.Format("alert('{0}');", ex.Message.ToString()), true);

            }
        }
        protected void rptrFavourite_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _strVP_Info = string.Empty;

                MyFavourite fav = e.Item.DataItem as MyFavourite;

                Literal ltrlFavourite = e.Item.FindControl("ltrlFavourites") as Literal;

                string _update = string.Empty;
                if (fav.STATUS == 1)
                {
                    _update = "<span class=\"ui-li-count\">New</span>";

                }

                switch (fav.OBJECTTYPE.ToUpper())
                {
                    case "CONTAINERPLAN":
                        string _tmpltrlContainerPlan = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>申请/实际进港时间：{2}</p><p> 进港结束时间：{3} </p>{4}</li>";

                        ContainerPlan cp = ContainerPlan.Cache.Load(fav.OBJECTID);

                        if (cp != null)
                        {
                            string _planTime = "";

                            if (!string.IsNullOrEmpty(cp.PlanTime.ToString()))
                            {
                                _planTime = cp.PlanTime.ToString();
                                _planTime = _planTime.Substring(0, _planTime.Length - 3);
                            }

                            string _planAcceptedTime = "";

                            if (!string.IsNullOrEmpty(cp.PlanAcceptedTime.ToString()))
                            {
                                _planAcceptedTime = cp.PlanAcceptedTime.ToString();
                                _planAcceptedTime = _planAcceptedTime.Substring(0, _planAcceptedTime.Length - 3);
                            }

                            ltrlFavourite.Text = string.Format(_tmpltrlContainerPlan, fav.URL, cp.ID, _planTime, _planAcceptedTime, _update);
                        }
                        else
                        { ltrlFavourite.Visible = false; }

                        break;

                    case "CONTAINERMAIN":
                        string _tmpltrlContainerMain = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>进港时间：{2} </p>{3}</li>";

                        ContainerMain c = new ContainerMain();
                        c.ID = fav.OBJECTID;
                        c.Select();

                        if (c != null)
                        {
                            string _arriveContainerTime = "";

                            if (!string.IsNullOrEmpty(c.ArrivalContainerTime.ToString()))
                            {
                                _arriveContainerTime = c.ArrivalContainerTime.ToString();
                                _arriveContainerTime = _arriveContainerTime.Substring(0, _arriveContainerTime.Length - 3);
                            }

                            ltrlFavourite.Text = string.Format(_tmpltrlContainerMain, fav.URL, c.ContainerNo, _arriveContainerTime, _update);
                        }
                        else
                        {
                            ltrlFavourite.Visible = false;
                        }
                        break;
                    case "CONTAINERDETAIL":
                        string _tmpltrlContainerDetail = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>进场：{2} | 出场：{3} </p> <p>入场方式：{4} | 出场方式：{5}</p>{6}</li>";

                        ContainerMain cm = new ContainerMain();
                        cm.ID = fav.OBJECTID;
                        cm.Select();

                        if (cm != null)
                        {
                            string _arriveTime = "";

                            if (!string.IsNullOrEmpty(cm.ArriveTime.ToString()))
                            {
                                _arriveTime = cm.ArriveTime.ToString();
                                _arriveTime = _arriveTime.Substring(0, _arriveTime.Length - 3);
                            }

                            string _departureTime = "";

                            if (!string.IsNullOrEmpty(cm.DepartureTime.ToString()))
                            {
                                _departureTime = cm.DepartureTime.ToString();
                                _departureTime = _departureTime.Substring(0, _departureTime.Length - 3);
                            }

                            ltrlFavourite.Text = string.Format(_tmpltrlContainerDetail, fav.URL, cm.ContainerNo, _arriveTime, _departureTime, cm.ArriveType.ToString(), cm.DepartureType.ToString(), _update);
                        }
                        else
                        {
                            ltrlFavourite.Visible = false;
                        }
                        break;
                    case "CONTAINERELOAD":
                        string _tmpltrlContainerEload = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>船名：{2} | 航次：{3} </p><p> 进港时间: {4}</p>{5}</li>";

                        ContainerEload ce = new ContainerEload();
                        ce.ID = fav.OBJECTID;
                        ce.Select();

                        if (ce != null)
                        {
                            string _sendPackingListTime = "";

                            if (!string.IsNullOrEmpty(ce.SendPackingListTime.ToString()))
                            {
                                _sendPackingListTime = ce.SendPackingListTime.ToString();
                                _sendPackingListTime = _sendPackingListTime.Substring(0, _sendPackingListTime.Length - 3);
                            }

                            ltrlFavourite.Text = string.Format(_tmpltrlContainerEload, fav.URL, ce.ContainerNo, ce.VesselName, ce.VoyageNumber, _sendPackingListTime, _update);
                        }
                        else
                        {
                            ltrlFavourite.Visible = false;
                        }
                        break;

                    case "TRUCK":
                        string _tmpltrlOTruck = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>进堆场时间：{2} </p><p> 出堆场时间：{3} </p>{4}</li>";

                        OTruck t = OTruck.Cache.Load(fav.OBJECTID);

                        if (t != null)
                        {
                            string _arriveYardTime = "";

                            if (!string.IsNullOrEmpty(t.ArriveYardTime.ToString()))
                            {
                                _arriveYardTime = t.ArriveYardTime.ToString();
                                _arriveYardTime = _arriveYardTime.Substring(0, _arriveYardTime.Length - 3);
                            }
                            string _departureYardTime = "";

                            if (!string.IsNullOrEmpty(t.DepartureYardTime.ToString()))
                            {
                                _departureYardTime = t.DepartureYardTime.ToString();
                                _departureYardTime = _departureYardTime.Substring(0, _departureYardTime.Length - 3);
                            }

                            ltrlFavourite.Text = string.Format(_tmpltrlOTruck, fav.URL, t.TruckNo, _arriveYardTime, _departureYardTime, _update);
                        }
                        else
                        {
                            ltrlFavourite.Visible = false;
                        }
                        break;

                    case "VESSELPLAN":

                        string _tmpltrlVesselPlan = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}({2})</h3><p>航次：{3} | 进/出口：{4} | 范围：{5}</p>{6}</li>";

                        OVesselPlan vp = OVesselPlan.Cache.Load(fav.OBJECTID);

                        if (vp != null)
                        {
                            ltrlFavourite.Text = string.Format(_tmpltrlVesselPlan, fav.URL, vp.VesselName, vp.VesselEnglishName, vp.VoyageNumber, vp.ImportOrExportFlag.Equals("E", StringComparison.OrdinalIgnoreCase) ? "出口" : "进口", vp.VesselPlanStatus, _update);
                        }
                        else
                        {
                            ltrlFavourite.Visible = false;
                        }
                        break;

                    case "TVDANGERPLAN":
                        string _tmpltrlTVDangerPlan = "<li style=\"cursor: pointer\" onclick=\"window.location.href=\'{0}\'\"><h3>{1}</h3><p>船名/航次：{2}</p><p> 直装时间：{3} </p>{4}</li>";

                        TVDangerPlan tv = TVDangerPlan.Cache.Load(fav.OBJECTID);

                        if (tv != null)
                        {
                            string _TVDate = "";

                            if (!string.IsNullOrEmpty(tv.TVDATE.ToString()))
                            {
                                _TVDate = tv.TVDATE.ToString();
                                _TVDate = _TVDate.Substring(0, _TVDate.Length - 3);
                            }



                            ltrlFavourite.Text = string.Format(_tmpltrlTVDangerPlan, fav.URL, tv.ID, tv.VESSELVOYAGE, tv.TVDATE, _update);
                        }
                        else
                        { ltrlFavourite.Visible = false; }

                        break;

                    default:

                        break;
                }
            }
        }
    }
}