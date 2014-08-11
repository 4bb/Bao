using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class VesselPlan_Container_Detail : PageBase
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

                lblVesselName.Text = string.Format("<h3  class=\"p15\">船名：{0}</h3><h6  class=\"p15\">{1}</h6>", vp.VesselName, vp.VesselEnglishName);
                lblCSI.Text = vp.CSI;
                lblVoyageNumber.Text = vp.VoyageNumber;
                lblImportOrExport.Text = vp.ImportOrExportFlag.ToString();
                lblContainerBeginTime.Text = vp.ContainerBeginTime.ToString();
                lblContainerDeadLine.Text = vp.ContainerDeadline.ToString();
                lblAgency.Text = vp.Agency;
                //lblPortOfCallId.Text = vp.PortOfCallID.ToString();
               


                List<PortOfCall> list = PortOfCall.GetPortOfCalls(vp.PortOfCallID.ToString()).FindAll(delegate(PortOfCall t)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    //if (vp.PortOfCallID.ToString() != null)
                    //{
                    //    tmpString = vp.PortOfCallID.ToString();
                    //    if (!string.IsNullOrEmpty(tmpString))
                    //        returnValue = returnValue && (t.ID.Equals(tmpString, StringComparison.OrdinalIgnoreCase));
                    //}

                    return returnValue;
                });

                rptPortOfCall.DataSource = list;
                rptPortOfCall.DataBind();
                rptth.DataSource = list;
                rptth.DataBind();

            }
        }

        protected void rptPortOfCall_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _strVP_Info = string.Empty;

                //string tmpString = string.Empty;
                //tmpString = ViewState["PortOfCallID"].ToString();


                PortOfCall poc = e.Item.DataItem as PortOfCall;

                Literal ltrlPortOfCall = e.Item.FindControl("ltrlPortOfCall") as Literal;

                if (ltrlPortOfCall != null && poc != null)
                {
                    string _tmpltrlText = "<td>{0} - {1}</td>";

                    _strVP_Info = string.Format(_tmpltrlText, poc.CN, poc.EDI);

                    ltrlPortOfCall.Text = _strVP_Info;

                }
                else
                {
                }
            }
            else { }
        }



    }
}