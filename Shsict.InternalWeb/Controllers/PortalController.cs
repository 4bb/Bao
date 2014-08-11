using System;
using System.Web.Mvc;
using System.Web.Security;


namespace Shsict.InternalWeb.Controllers
{
    public class PortalController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var id = this.HttpContext.Request.RequestContext.HttpContext.User.Identity as FormsIdentity;

            if (Session["myMenu"] != null)
                ViewBag.myMenu = Session["myMenu"].ToString();

            if (id != null && id.IsAuthenticated)
            {
                string[] roles = id.Ticket.UserData.Split(',');

                return View(roles);
            }
        

            return View();
        }

        [Authorize]
        public ActionResult Pad()
        {
            if (Session["myMenu"] != null)
                ViewBag.myMenu = Session["myMenu"].ToString();

            var id = this.HttpContext.Request.RequestContext.HttpContext.User.Identity as FormsIdentity;

            if (id != null && id.IsAuthenticated)
            {
                string[] roles = id.Ticket.UserData.Split(',');

                return View(roles);
            }
          
            return View();
        }

        public void SaveMenu(string id)
        {
            string[] menuArr;
            int _num;

            if (Session["myMenu"] != null)
            {
                menuArr = Session["myMenu"].ToString().Split(',');
            }
            else
            {
                menuArr = new string[5] { "true", "true", "true", "true", "true" };
            }

         
            if (int.TryParse(id, out _num) && _num <= 5)
            {
                _num -= 1;
                if (menuArr[_num].ToLower() == "true")
                {
                    menuArr[_num] = "false";
                }
                else if (menuArr[_num].ToLower() == "false")
                {
                    menuArr[_num] = "true";

                }
                string myMenu = String.Join(",", menuArr);
                Session["myMenu"] = String.Join(",", menuArr);

                Response.Write("success");
            }
            else
            {
                Response.Write("error");

            }
        }

    }
}
