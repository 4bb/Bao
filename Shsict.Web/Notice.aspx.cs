using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class Notice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnVisible(false);
            //master.setRefreshNoticeBtn(true);

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                List<Shsict.Entity.Notice> list = Shsict.Entity.Notice.Cache.NoticeList_Active.FindAll(delegate(Shsict.Entity.Notice vp)
                {
                    Boolean returnValue = true;
                    string tmpString = string.Empty;
                    DateTime dateTime = DateTime.Now.ToLocalTime() ;

                    return returnValue;
                });

                rptNotice.DataSource = list;
                rptNotice.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "failed", string.Format("alert('{0}');", ex.Message.ToString()), true);
            }
        }

        protected void rptNotice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _strVP_Info = string.Empty;
                Shsict.Entity.Notice vp = e.Item.DataItem as Shsict.Entity.Notice;

                Literal ltrlNotice = e.Item.FindControl("ltrlNotice") as Literal;

                if (ltrlNotice != null && vp != null)
                {
                    string _tmpltrlText = "<div class=\"ui-corner-all custom-corners p15a\" id=\"listNotice\"><div class=\"ui-bar ui-bar-c\"> <h3>{0}</h3></div><div class=\"ui-body-d p15\"><p>{1}</p><p style=\"font-size:11px; color:#a4a4a4; border-top:#e8e8e8 1px solid; padding-top:7px;\">{2}</p> </div></div>";

                    string CreateTime= vp.CreateTime.ToString();
                    _strVP_Info = string.Format(_tmpltrlText, vp.NoticeTitle, vp.NoticeContent, CreateTime.Substring(0, CreateTime.Length-3));

                    ltrlNotice.Text = _strVP_Info;
                }
            }

        }
    }
}