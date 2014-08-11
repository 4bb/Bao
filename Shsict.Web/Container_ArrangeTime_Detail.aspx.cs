using Shsict.Entity;
using System;
using System.Collections.Generic;

namespace Shsict.Web
{
    public partial class Container_ArrangeTime_Detail : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //login
            AnonymousRedirect = true;

            base.OnInitComplete(e);

            if (!IsPostBack)
            {
                BindData();
            }

        }
        private string NoType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["NoType"]))
                {
                    return Request.QueryString["NoType"];
                }
                else
                {
                    return null;
                }
            }
        }
        private string ArrangeTime
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ArrangeTime"]))
                {
                    return Request.QueryString["ArrangeTime"];
                }
                else
                {
                    return null;
                }
            }
        }
        private void BindData()
        {

            if (!string.IsNullOrEmpty(ArrangeTime))
            {
                TVDangerPlan tcDanger = TVDangerPlan.Cache.Load(ArrangeTime);
                if (!string.IsNullOrEmpty(NoType) && NoType.ToUpper() == "A")
                {
                    lblTitleNo.Text = string.Format("<h3 class=\"p15\">申请编号:{0}</h3>", tcDanger.ID);
                    lblNoName.Text = "计划号";
                    lblNo.Text = tcDanger.PLANNO;
                }
                else
                {
                    lblTitleNo.Text = string.Format("<h3 class=\"p15\">计划号:{0}</h3>", tcDanger.PLANNO);
                    lblNoName.Text = "申请编号";
                    lblNo.Text = tcDanger.ID;
                }

                lblVesselVoyage.Text = tcDanger.VESSELVOYAGE;
                if (tcDanger.ARRIVE_PLAN_TIME != null)
                {
                    string _ARRIVE_PLAN_TIME = tcDanger.ARRIVE_PLAN_TIME.ToString();
                    lblArrivePlanTime.Text = _ARRIVE_PLAN_TIME.Substring(0, _ARRIVE_PLAN_TIME.Length - 3);
                }
                if (tcDanger.DEPARTURE_PLAN_TIME != null)
                {
                    string _DEPARTURE_PLAN_TIME = tcDanger.DEPARTURE_PLAN_TIME.ToString();
                    lblDeparturePlanTime.Text = _DEPARTURE_PLAN_TIME.Substring(0, _DEPARTURE_PLAN_TIME.Length - 3);
                }
                if (tcDanger.TVDATE != null)
                {
                    string _TVDATE = tcDanger.TVDATE.ToString();
                    lblTVDate.Text = _TVDATE.Substring(0, _TVDATE.Length - 3);
                }
                if (tcDanger.EXACTTVDATE != null)
                {
                    string _EXACTTVDATE = tcDanger.EXACTTVDATE.ToString();
                    lblExActTvDate.Text = _EXACTTVDATE.Substring(0, _EXACTTVDATE.Length - 3);
                }

                string _ContainerNo = "";
                List<TVDangerContainer> list = TVDangerContainer.GetTVDangerContainers(tcDanger.PLANNO).FindAll(delegate(TVDangerContainer t)
               {
                   _ContainerNo += t.CONTAINERNO + "<br>";
                   return true;
               });

                lblContainerNo.Text = _ContainerNo;
            }
        }

    }
}