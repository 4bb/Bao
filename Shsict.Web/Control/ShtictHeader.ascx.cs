using System;

namespace Shsict.Web.Control
{
    public partial class ShtictHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbltitle.Text = this.Page.Title.ToString();

            btnBack.Visible = BtnBackVisible;
            btnBack.Attributes["data-role"] = "button";
            btnBack.Attributes["data-inline"] = "true";

            btnBack.Attributes["data-transition"] = "slidedown";
            btnBack.Attributes["data-icon"] = "arrow-l";
            btnBack.Attributes["data-iconpos"] = "notext";
            btnBack.Attributes["data-mini"] = "true";

            if (IsBtnBack)
            {
                btnBack.Attributes["data-rel"] = "back";
            }
            else
            {
                btnBack.Attributes["data-rel"] = "external";
                btnBack.Attributes["href"] = "Portal.aspx";
                btnBack.Target = "_top";

            }

        }

        private bool _isbtnBack = true;
        public bool IsBtnBack
        {
            get
            {
                return _isbtnBack;
            }

            set
            {
                _isbtnBack = value;
            }
        }
        private bool _btnBackVisible = true;
        public bool BtnBackVisible
        {
            get
            {
                return _btnBackVisible;
            }

            set
            {
                _btnBackVisible = value;
            }
        }
    }
}