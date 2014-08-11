using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shsict.Scheduler;

namespace Shsict.Web
{
    public partial class ShsictThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (SchedulerManager.CurrentJobsList != null)
            {
                if (SchedulerManager.CurrentJobsList.Count >0)
                {
                    btnStart.Enabled = false;
                    foreach (KeyValuePair<string, System.Threading.Timer> item in SchedulerManager.CurrentJobsList)
                    {
                        lblThread.Text = lblThread.Text + "\r\n" + item.Key+"Has Open";
                    }
                }
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
          
                SchedulerManager.Start();

                lblThreadStatus.Text = string.Format("Total: {0} Jobs Started", SchedulerManager.CurrentJobsList.Count);
                btnStart.Visible = false;
                btnStop.Visible = true;
            }
            catch (Exception ex)
            {
                lblThreadStatus.Text = ex.Message;
                btnStart.Visible = true;
                btnStop.Visible = true;
            }
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                int _jobCounts = SchedulerManager.CurrentJobsList.Count;

                SchedulerManager.Stop();

                lblThreadStatus.Text = string.Format("Total: {0} Jobs Stopped", _jobCounts);
                btnStart.Visible = true;
                btnStop.Visible = false;

            }
            catch (Exception ex)
            {
                lblThreadStatus.Text = ex.Message;
                btnStart.Visible = true;
                btnStop.Visible = true;
            }
        }
    }
}