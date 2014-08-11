using Shsict.Entity;
using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Shsict.Web
{
    public partial class Portal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnVisible(false);
            if (!IsPostBack)
            {
                VisitMsg vm = new VisitMsg();

                string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(ipAddress))
                    ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (string.IsNullOrEmpty(ipAddress))
                    ipAddress = HttpContext.Current.Request.UserHostAddress;

                ipAddress = FormatIP(ipAddress);
                if (string.IsNullOrEmpty(ipAddress) || !IsIP(ipAddress))
                    ipAddress = "127.0.0.1";

                vm.IP = ipAddress;
                vm.VISIT_DATE = DateTime.Now.ToLocalTime();
                HttpBrowserCapabilities bc = Request.Browser;

                vm.BROWSER = bc.Browser;
                vm.MOBILE_USER_AGENT = Request.ServerVariables["HTTP_USER_AGENT"];

                if (Request.Cookies["uid"] != null)
                {
                    vm.USERNAME = Request.Cookies["uid"].Value;
                }
                else
                {
                    vm.USERNAME = "";
                }

                vm.Insert();
            }
        }

        private static string FormatIP(string ip)
        {
            if (ip.Contains(":"))
                return ip.Substring(0, ip.LastIndexOf(":"));
            else return ip;
        }

        private static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}