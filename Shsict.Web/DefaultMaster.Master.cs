using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class DefaultMaster : System.Web.UI.MasterPage, IMaster
    {
        private string _uID = string.Empty;

        /// <summary>
        /// Current UID
        /// </summary>
        public string UID
        {
            set
            {
                _uID = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region MasterPage Header

            //Title Text
            lbltitle.Text = this.Page.Title.ToString();

            //Button Back
            btnBack.Visible = BtnBackVisible;
            //btnBack.Attributes["data-role"] = "button";
            //btnBack.Attributes["data-inline"] = "true";

            //btnBack.Attributes["data-transition"] = "slidedown";
            //btnBack.Attributes["data-icon"] = "arrow-l";
            //btnBack.Attributes["data-iconpos"] = "notext";
            //btnBack.Attributes["data-mini"] = "true";

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

            //Button Refresh Notice
            //btnRefreshNotice.Visible = BtnRefreshNoticeVisible;

            //btnRefreshFavourite.Visible = BtnRefreshFavouriteVisible;

            //btnRefreshCount.Attributes["data-role"] = "button";
            //btnRefreshCount.Attributes["data-icon"] = "refresh";
            //btnRefreshCount.Attributes["data-iconpos"] = "notext";

            btnRefreshCount.Visible = BtnRefreshCountVisible;

            //btnRefreshNotice.Attributes["data-role"] = "button";
            //btnRefreshNotice.Attributes["data-iconpos"] = "notext";
            //btnRefreshNotice.Attributes["data-icon"] = "refresh";
            //btnRefreshFavourite.Attributes["data-role"] = "button";
            //btnRefreshFavourite.Attributes["data-iconpos"] = "notext";
            //btnRefreshFavourite.Attributes["data-icon"] = "refresh";
            #endregion

            //Hide Lable ObjectContent && ObjectID
            lblObjectType.Attributes["style"] = "display:none";
            lblObjectID.Attributes["style"] = "display:none";

            // Is Active CtrlFoot
            if (Session["mode"] != null)
            {
                ctrlFooter.Visible = true;
            }
            else
            {
                ctrlFooter.Visible = false;
            }
            

        }

        #region  Back Button

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

        public void setHeaderBtnVisible(bool value)
        {
            //ctrlHeader.BtnBackVisible = value;
            BtnBackVisible = value;
        }

        public void setHeaderBtnBack(bool value)
        {
            //ctrlHeader.IsBtnBack = value;
            IsBtnBack = value;

        }

        #endregion

        #region RefreshCount Button

        private bool _BtnRefreshCountVisible = false;

        public bool BtnRefreshCountVisible
        {
            get
            {
                return _BtnRefreshCountVisible;
            }

            set
            {
                _BtnRefreshCountVisible = value;
            }
        }

        public void setRefreshCountBtn(bool value)
        {

            BtnRefreshCountVisible = value;

        }
        #endregion

    }
}