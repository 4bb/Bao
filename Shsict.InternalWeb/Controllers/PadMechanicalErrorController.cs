using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
namespace Shsict.InternalWeb.Controllers
{
    public class PadMechanicalErrorController : Controller
    {
        [Authorize(Roles = "JX")]
        public ActionResult Index(string id)
        {
            List<Mechanical> _MechanicalError;
            string user = this.HttpContext.Request.RequestContext.HttpContext.User.Identity.Name;
            if (id == null)
            {
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "$";

            }

            string _MyTime = id.Substring(0, id.LastIndexOf("$"));
            _MechanicalError = MechanicalErrorController.Cache.MechanicalList.FindAll(t => t.REPORTTIME.Date.Equals(DateTime.Parse(_MyTime))).ToList();

            string data = "";

            if (id.Length != id.IndexOf("$") + 1)
                data = id.Substring(id.IndexOf("$") + 1, id.Length - id.IndexOf("$") - 1);



            if (!string.IsNullOrEmpty(data))
            {
                _MechanicalError = _MechanicalError.FindAll(t => t.MECHANICALNO.ToUpper().Contains(data.ToUpper())).OrderByDescending(t => t.REPORTTIME).ToList();

            }
            else
            {
                _MechanicalError = _MechanicalError.OrderByDescending(t => t.REPORTTIME).ToList();

            }



            string noData = "暂无数据";

            if (_MechanicalError == null || _MechanicalError.Count == 0)
            {
                Mechanical mechanicalError = new Mechanical();

                mechanicalError.MECHANICALNO = noData;

                _MechanicalError.Add(mechanicalError);
            }

            _MechanicalError[0].SEARCHKEY = data;
            _MechanicalError[0].MyDate = _MyTime;

            foreach (MechanicalError item in MechanicalErrorController.Cache.MechanicalErrorList)
            {
                if (item.JobNo.Equals(user)&& item.ISSEND.ToUpper().Trim().Equals("Y"))
                {
                    MechanicalError.UpdateMechanicalError(item.ID);
                }
            }

            MechanicalErrorController.Cache.RefreshCache();

            return View(_MechanicalError.ToList());
        }

    }
}
