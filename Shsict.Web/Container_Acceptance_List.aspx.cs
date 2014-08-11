using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class Container_Acceptance_List : PageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AnonymousRedirect = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //login
            // AnonymousRedirect = true;

            // NextURL = "Container_Acceptance_List.aspx";

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