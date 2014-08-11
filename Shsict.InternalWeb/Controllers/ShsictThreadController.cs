using Shsict.InternalWeb.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shsict.InternalWeb.Controllers
{
    public class ShsictThreadController : Controller
    {
        //
        // GET: /ShsictThread/

        public ActionResult Index()
        {
            ViewBag.ThreadStatus = "";

            if (SchedulerManager.CurrentJobsList != null)
            {
                if (SchedulerManager.CurrentJobsList.Count > 0)
                {

                    foreach (KeyValuePair<string, System.Threading.Timer> item in SchedulerManager.CurrentJobsList)
                    {
                        ViewBag.ThreadStatus = ViewBag.ThreadStatus + "\r\n" + item.Key + "Has Open";
                    }
                }
            }

            return View();
        }
        public void ThreadStar()
        {
            try
            {

                SchedulerManager.Start();

                  Response.Write(string.Format("Total: {0} Jobs Started", SchedulerManager.CurrentJobsList.Count));

            
            }
            catch (Exception ex)
            {
                Response.Write("error:"+ex);
            }

       
        }
        public void ThreadStop()
        {
            try
            {
                int _jobCounts = SchedulerManager.CurrentJobsList.Count;

                SchedulerManager.Stop();

                Response.Write (string.Format("Total: {0} Jobs Stopped", _jobCounts));


            }
            catch (Exception ex)
            {
                Response.Write("error:" + ex);
            }
        }
    }
}
