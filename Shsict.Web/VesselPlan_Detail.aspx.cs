using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class VesselPlan_Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private string _VesselPlanID = null;
        private string VesselPlanID
        {
            get
            {
                if (_VesselPlanID != null)
                    return _VesselPlanID;
                else if (!string.IsNullOrEmpty(Request.QueryString["VesselPlanID"]))
                    return Request.QueryString["VesselPlanID"];
                else
                    return null;
            }
            set { _VesselPlanID = value; }
        }

        private void BindData()
        {
            try
            {
                if (VesselPlanID != null)
                {
                    OVesselPlan vp = OVesselPlan.Cache.Load(VesselPlanID);

                    string ArriveTimeText = string.Empty;
                    string ArriveTime = string.Empty;

                    string DepartureTimeText = string.Empty;
                    string DepartureTime = string.Empty;

                    string BerthText = string.Empty;
                    string Berth = string.Empty;


                    switch (vp.VesselPlanStatus)
                    {
                        case "在港":
                            ArriveTimeText = "实际靠泊";
                            ArriveTime = "<td class=\"arrive-a-t\">" + vp.ArriveActualTime.ToString();
                            DepartureTimeText = "计划离泊";
                            DepartureTime = "<td class=\"departure-p-t\">" + vp.DeparturePlanTime.ToString();
                            BerthText = "实际泊位";
                            Berth = "<td class=\"berth-a\">" + vp.BerthActual.ToString();
                            break;
                        case "离港":
                            ArriveTimeText = "实际靠泊";
                            ArriveTime = "<td class=\"arrive-a-t\">" + vp.ArriveActualTime.ToString();
                            DepartureTimeText = "实际离泊";
                            DepartureTime = "<td class=\"departure-a-t\">" + vp.DepartureActualTime.ToString();
                            BerthText = "实际泊位";
                            Berth = "<td class=\"berth-a\">" + vp.BerthActual.ToString();

                            break;
                        case "计划":
                            ArriveTimeText = "计划靠泊";
                            ArriveTime = "<td class=\"arrive-p-t\">" + vp.ArrivePlanTime.ToString();
                            DepartureTimeText = "计划离泊";
                            DepartureTime = "<td class=\"departure-p-t\">" + vp.DeparturePlanTime.ToString();
                            BerthText = "计划泊位";
                            Berth = "<td class=\"berth-p\">" + vp.BerthPlan.ToString();
                            lblCustomsClosing.Text = string.Format("<td class=\"customs-c\">{0}</td>", vp.IsCustomsClosing.ToString());

                            break;
                        default:
                            break;
                    }
                    lblVesselName.Text = string.Format("<h3 class=\"p15\">船名:{0}</h3><h6  class=\"p15\">{1}</h6>", vp.VesselName, vp.VesselEnglishName);

                    lblVoyageNumber.Text = vp.VoyageNumber;
                    lblImportOrExport.Text = vp.ImportOrExportFlag;

                    lblArriveTime.Text = ArriveTime + "<div class=\"fieldLabel\">" + ArriveTimeText + "</div></td>";

                    lblDepartureTime.Text = DepartureTime + "<div class=\"fieldLabel\">" + DepartureTimeText + "</div></td>";

                    lblBerth.Text = Berth + "<div class=\"fieldLabel\">" + BerthText + "</div></td>";

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "failed", string.Format("alert('{0}');", ex.Message.ToString()), true);
            }
        }
    }
}