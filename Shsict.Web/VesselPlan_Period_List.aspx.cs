using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Shsict.Entity;

namespace Shsict.Web
{
    public partial class VesselPlan_Period_List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnBack(true);


        }

    }
}