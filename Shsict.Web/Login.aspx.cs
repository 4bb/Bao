using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbun.Text = this.UID;
            lblNextURL.Text = this.NextURL;
            //if (!IsPostBack)
            //{
            //    tbun.Text = this.UID;
            //    lblNextURL.Text = this.NextURL;
            //}
        }

    }
}