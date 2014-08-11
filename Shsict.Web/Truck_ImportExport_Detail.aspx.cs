using System;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Truck_ImportExport_Detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private string _TruckID = null;
        private string TruckID
        {
            get
            {
                if (_TruckID != null)
                    return _TruckID;
                else if (!string.IsNullOrEmpty(Request.QueryString["TruckID"]))
                    return Request.QueryString["TruckID"];
                else
                    return null;
            }
            set { _TruckID = value; }
        }
        private void BindData()
        {

            if (TruckID != null)
            {
                OTruck t = OTruck.Cache.Load(TruckID);
                lblTruckNo.Text = string.Format("<h3>集卡号：{0}</h3>", t.TruckNo);
                lblArriveYardTime.Text = t.ArriveYardTime.ToString();
                lblDepartureYardTime.Text = t.DepartureYardTime.ToString();
                lblFcontainer.Text = t.Fcontainer.ToString();
                lblAcontainer.Text = t.Acontainer.ToString();

            }
        }
    }
}