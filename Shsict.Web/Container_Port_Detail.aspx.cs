using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Container_Port_Detail : PageBase
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
        private string Type
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                {
                    return Request.QueryString["Type"];
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
                // ContainerEload con = ContainerEload.Cache.Load(ContainerID);
                ContainerEload con = new ContainerEload();
                con.ID = ContainerID;
                con.Select();

                if (Type == "c")
                {
                    lblContainerNo.Text = string.Format("<h3 class=\"p15\">箱号：{0}</h3>", con.ContainerNo);
                }
                else
                {
                    lblContainerNo.Text = string.Format("<h3 class=\"p15\">订单号：{0}</h3>", con.BillOfLadingNum);
                }

                lblVesselName.Text = con.VesselName;
                lblVoyageNumber.Text = con.VoyageNumber;

                lblBillOfLadingNum.Text = con.BillOfLadingNum;

                lblSendPackingListTime.Text = con.SendPackingListTime.ToString();
                lblArrivalPortTime.Text = con.ArrivalContainerTime.ToString();

            }
        }
    }
}