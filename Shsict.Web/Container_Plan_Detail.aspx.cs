using System;
using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Container_Plan_Detail : PageBase
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
            // Todo: 先取出ContainerMain，进行页面数据绑定，剩下的数据，应通过ajax异步加载ContainerDetail数据对象，并进行动态绑定。
            if (!string.IsNullOrEmpty(ContainerID))
            {
                ContainerMain con = ContainerMain.Cache.Load(ContainerID);

                lblContainerNo.Text = string.Format("<h3>箱号：{0}</h3>", con.ContainerNo);


                lblCNo.Text = con.ContainerNo;


                string _ArriveTime = string.Empty;
                string _DepartureTime = string.Empty;

                if (con.ArriveTime != null)
                {
                    _ArriveTime = DateTime.Parse(con.ArriveTime.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (con.DepartureTime != null)
                {
                    _DepartureTime = DateTime.Parse(con.DepartureTime.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }

                lblArriveTime.Text = _ArriveTime;


                lblDeparTureTime.Text = _DepartureTime;

                lblArriveType.Text = con.ArriveType.ToString();
                lblDepartureType.Text = con.DepartureType.ToString();
                ;
                lblCustomsCLearance.Text = con.CustomsClearance;

                lblVesselID.Text = con.Stowagefg.ToString();


            }
        }
    }
}