using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Container_Trace_Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                //ContainerMain con = ContainerMain.Cache.Load(ContainerID);
                ContainerMain con = new ContainerMain();
                con.ID = ContainerID;
                con.Select();

                lblContainerNo.Text = string.Format("<h3 class=\"p15\">箱号：{0}</h3>", con.ContainerNo);

                lblArrivalContainerTime.Text = con.ArrivalContainerTime.ToString();
                lblCustomsClearanceTime.Text = con.CustomsClearanceTime.ToString();
                lblStowageTime.Text = con.StowageTime.ToString();
                lblVesselTime.Text = con.VesselTime.ToString();
                lblDepartTime.Text = con.DepartureTime.ToString();
                lblVesselName.Text = con.VesselName.ToString();
                lblVoyageNumber.Text = con.VoyageNumber.ToString();
                lblArriveType.Text = con.ArriveType.ToString();
                lblDepartTime.Text = con.DepartureTime.ToString();
                lblArriveTime.Text = con.ArriveTime.ToString();

                if (con.IEFG == "E" || con.IEFG == "Y")
                {
                    pnlExport.Visible = true;

                }
                else if (con.IEFG == "I")
                {
                    pnlImport.Visible = true;

                }

            }
        }
    }
}