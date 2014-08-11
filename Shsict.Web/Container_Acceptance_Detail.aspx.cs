using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Container_Acceptance_Detail : PageBase
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

        private string ContainerID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ContainerID"]))
                {
                    return Request.QueryString["ContainerID"];
                }
                else
                {
                    return null;
                }
            }
        }

        private void BindData()
        {

            if (!string.IsNullOrEmpty(ContainerID))
            {
                ContainerPlan con = ContainerPlan.Cache.Load(ContainerID);
                lblContainerNo.Text = string.Format("<h3 class=\"p15\">申请编号:{0}</h3>", con.ID);
                lblVoyageNumber.Text = con.VesselVoyage.ToString();
                lbloperation.Text = con.OPERATION.ToString();
                lblplanaccept.Text = con.PLANACCEPT.ToString();
                lblplanno.Text = con.planno.ToString();
                lblcustom.Text = con.custom.ToString();
                lblPlanTime.Text = con.PlanTime.ToString();
                lblPlanAcceptTime.Text = con.PlanAcceptedTime.ToString();


            }
        }
    }
}