using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Shsict.Entity
{
    /// <summary>
    /// 访问信息
    /// </summary>
    public class VisitMsg
    {
        public VisitMsg() { }

        public VisitMsg(DataRow dr)
        {
            InitVisitMsg(dr);
        }

        private void InitVisitMsg(DataRow dr)
        {
            if (dr != null)
            {
                VISITID = dr["VISITID"].ToString();
                IP = dr["IP"].ToString();        
                VISIT_DATE = DateTime.Parse(dr["VISIT_DATE"].ToString());
                BROWSER = dr["BROWSER"].ToString();
                MOBILE_USER_AGENT = dr["MOBILE_USER_AGENT"].ToString();
                USERNAME = dr["USERNAME"].ToString();       
            }
            else
            {
                throw new Exception("Unable to init VisitMsg.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.VisitMsg.GetVisitMsgByID(VISITID);

            if (dr != null)
            {
                InitVisitMsg(dr);
            }
        }

        public void Insert()
        {
            Shsict.DataAccess.VisitMsg.InsertVisitMsg(VISITID, IP, VISIT_DATE, BROWSER, MOBILE_USER_AGENT, USERNAME);

        }

        public void Update()
        {
            Shsict.DataAccess.VisitMsg.UpdateVisitMsg(VISITID, IP, VISIT_DATE, BROWSER, MOBILE_USER_AGENT, USERNAME);

        }

        public void Delete()
        {
            Shsict.DataAccess.VisitMsg.DeleteVisitMsg(VISITID);

        }



      

        #region members and propertis
        public string VISITID { get; set; }

        public string IP { get; set; }

        public DateTime VISIT_DATE { get; set; }

        public string BROWSER { get; set; }

        public string MOBILE_USER_AGENT { get; set; }

        public string USERNAME { get; set; }
  
        #endregion


      
    }
}



