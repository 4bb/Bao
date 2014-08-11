using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 双吊具
    /// </summary>
    public class TwinLift
    {
        public TwinLift() { }

        public TwinLift(DataRow dr)
        {
            InitTwinLift(dr);
        }

        private void InitTwinLift(DataRow dr)
        {
            if (dr != null)
            {
                SCD_ID = dr["SCD_ID"].ToString();
                VESSELNAME = dr["VESSELNAME"].ToString();
                IEFG = dr["IEFG"].ToString();
                TOTALCNT = dr["TOTALCNT"].ToString();
                CANSTGOPTCNT = dr["CANSTGOPTCNT"].ToString();
                CANSTGOPTRATE = dr["CANSTGOPTRATE"].ToString();
                STORAGECNT = dr["STORAGECNT"].ToString();
                STORAGERATE = dr["STORAGERATE"].ToString();
                OPERATECNT = dr["OPERATECNT"].ToString();
                OPERATERATE = dr["OPERATERATE"].ToString();
                REPORTDATE = DateTime.Parse(dr["REPORTDATE"].ToString());
                EFFICIENCY = dr["EFFICIENCY"].ToString();
                MyDate = REPORTDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                throw new Exception("Unable to init TwinLift.");
            }
        }

        #region members and propertis

        public string SCD_ID { get; set; }

        public string VESSELNAME { get; set; }

        public string IEFG { get; set; }

        public string TOTALCNT { get; set; }

        public string CANSTGOPTCNT { get; set; }

        public string CANSTGOPTRATE { get; set; }

        public string STORAGECNT { get; set; }

        public string STORAGERATE { get; set; }

        public string OPERATECNT { get; set; }

        public string OPERATERATE { get; set; }

        public string EFFICIENCY { get; set; }

        public DateTime REPORTDATE { get; set; }

        public string MyDate { get; set; }

        #endregion

        public static List<TwinLift> GetTwinLifts()
        {
            DataTable dt = Shsict.DataAccess.TwinLift.GetTwinLifts();
            List<TwinLift> list = new List<TwinLift>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TwinLift(dr));
                }
            }

            return list;
        }
    }
}