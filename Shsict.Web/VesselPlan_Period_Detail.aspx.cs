using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class VesselPlan_Period_Detail : PageBase
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

            if (VesselPlanID != null)
            {
                OVesselPlan vp = OVesselPlan.Cache.Load(VesselPlanID);

                lblVesselName.Text = string.Format("<h3  class=\"p15\">船名：{0}</h3><h6 class=\"p15\">{1}</h6>", vp.VesselName, vp.VesselEnglishName);

                lblVoyageNumber.Text = vp.VoyageNumber;
                lblImportOrExport.Text = vp.ImportOrExportFlag;
                lblArrivePlanTime.Text = vp.ArrivePlanTime.ToString();
                lblArriveActualTime.Text = vp.ArriveActualTime.ToString();
                lblDeparturePlanTime.Text = vp.DeparturePlanTime.ToString();
                lblDepartureActualTime.Text = vp.DepartureActualTime.ToString();
                lblIsCustomsClosing.Text = vp.IsCustomsClosing.ToString();

            }
        }
    }
}