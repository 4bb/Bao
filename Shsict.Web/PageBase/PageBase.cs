using System;
using System.Web;


namespace Shsict.Web
{
    public class PageBase : System.Web.UI.Page
    {
 
        public string UID
        {
            get
            {
                if (Request.Cookies["uid"] != null && !string.IsNullOrEmpty(Request.Cookies["uid"].Value))
                {
                    //already login
                    return Request.Cookies["uid"].Value;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Custom
        {
            get
            {
                if (Request.Cookies["custom"] != null && !string.IsNullOrEmpty(Request.Cookies["custom"].Value))
                    return HttpUtility.UrlDecode(Request.Cookies["custom"].Value);
                else
                    return string.Empty;
            }
        }

        public string NextURL
        {
            get
            {
                if (Request.QueryString["NextURL"] != null && !string.IsNullOrEmpty(Request.QueryString["NextURL"]))
                    return Request.QueryString["NextURL"];
                else
                    return string.Empty;
            }
        }

        public bool AnonymousRedirect { get; set; }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);

            //not Login
            if (AnonymousRedirect)
            {
                if (string.IsNullOrEmpty(UID))
                {
                    Response.Clear();

                    string loginURL = string.Format("Login.aspx?NextURL={0}", Request.Url.PathAndQuery);

                    Response.Redirect(loginURL, false);

                    Context.ApplicationInstance.CompleteRequest();
                }
            }

            //Set Master Page Info
            if (this.Master != null && this.Master is DefaultMaster)
            {
                DefaultMaster masterPage = this.Master as DefaultMaster;

                masterPage.UID = UID;

            }
        }

    }
}

