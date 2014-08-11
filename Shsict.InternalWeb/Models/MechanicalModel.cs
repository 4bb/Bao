using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    public class Mechanical
    {
        public Mechanical() { }

        public Mechanical(DataRow dr)
        {
            InitMechanical(dr);
        }

        private void InitMechanical(DataRow dr)
        {
            if (dr != null)
            {
                MECHANICALNO = dr["MECHANICALNO"].ToString();
                SENDMESSAGE = dr["SENDMESSAGE"].ToString();
                FaultStatus = dr["FaultStatus"].ToString();
                EngERRORTIME = dr["EngERRORTIME"].ToString();
                OptERRORTIME = dr["OptERRORTIME"].ToString();
                REPORTTIME = DateTime.Parse(dr["REPORTTIME"].ToString());

                if (!string.IsNullOrEmpty(dr["RECEIVETIME"].ToString()))
                {
                    RECEIVETIME = DateTime.Parse(dr["RECEIVETIME"].ToString());
                }
                else
                {
                    RECEIVETIME = null;
                }
                if (!string.IsNullOrEmpty(dr["REPAIRTIME"].ToString()))
                {
                    REPAIRTIME = DateTime.Parse(dr["REPAIRTIME"].ToString());
                }
                else
                {
                    REPAIRTIME = null;
                }

                if (!string.IsNullOrEmpty(dr["CONFIRMREPAIRTIME"].ToString()))
                {
                    CONFIRMREPAIRTIME = DateTime.Parse(dr["CONFIRMREPAIRTIME"].ToString());
                }
                else
                {
                    CONFIRMREPAIRTIME = null;
                }               

            }
            else
            {
                throw new Exception("Unable to init Mechanical.");
            }
        }

        #region members and propertis

        
        #endregion

        public static List<Mechanical> GetMechanicals()
        {
            DataTable dt = Shsict.DataAccess.SendMessage.GetFaultMessages();
            List<Mechanical> list = new List<Mechanical>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Mechanical(dr));
                }
            }

            return list;
        }

        public string MECHANICALNO { get; set; }

        public string SENDMESSAGE { get; set; }

        public string FaultStatus { get; set; }

        public string EngERRORTIME { get; set; }

        public string OptERRORTIME { get; set; }

        public DateTime REPORTTIME { get; set; }

        public DateTime? RECEIVETIME { get; set; }

        public DateTime? REPAIRTIME { get; set; }

        public DateTime? CONFIRMREPAIRTIME { get; set; }

        public string SEARCHKEY { get; set; }

        public string MyDate { get; set; }
    }
}