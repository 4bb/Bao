using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class Container_ArrangeTime_List : PageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AnonymousRedirect = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnBack(false);
            master.setRefreshCountBtn(true);


            #region Custom

            lblCustom.Attributes["style"] = "display:none";

            if (!string.IsNullOrEmpty(base.Custom))
            {
                lblCustom.Text = base.Custom;
            }

            #endregion
        }
      
  

      
    }
}