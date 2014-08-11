using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class VesselPlan_Period_Name : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnBack(false);
            master.setRefreshCountBtn(true);
          
        }
    }
}