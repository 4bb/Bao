using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 单车运行周期
    /// </summary>
    public class TruckOperationCycle
    {
        public TruckOperationCycle() { }

        public TruckOperationCycle(DataRow dr)
        {
            InitTruckOperationCycle(dr);
        }

        private void InitTruckOperationCycle(DataRow dr)
        {
            if (dr != null)
            {
                TRUCKNO = dr["TRUCKNO"].ToString();
                if (!string.IsNullOrEmpty(dr["COMPLETETRUCKNUM"].ToString()))
                {
                    COMPLETETRUCKNUM = Int32.Parse(dr["COMPLETETRUCKNUM"].ToString());
                }
                else
                {
                    COMPLETETRUCKNUM = 0;
                }
                if (!string.IsNullOrEmpty(dr["AVEPERIOD"].ToString()))
                {
                    AVEPERIOD = double.Parse(dr["AVEPERIOD"].ToString());
                }
                else
                {
                    AVEPERIOD = 0;
                }

                if (!string.IsNullOrEmpty(dr["CURRENTINSTRUCTION"].ToString()))
                {
                    CURRENTINSTRUCTION = double.Parse(dr["CURRENTINSTRUCTION"].ToString());
                }
                else
                {
                    CURRENTINSTRUCTION = 0;
                }

                TOLOC1 = dr["TOLOC1"].ToString();
                TOLOC2 = dr["TOLOC2"].ToString();
                STATUS = dr["STATUS"].ToString();
                STOPFG = dr["STOPFG"].ToString();

            }
            else
            {
                throw new Exception("Unable to init TruckOperationCycle.");
            }
        }

        #region members and propertis
        public string TRUCKNO { get; set; }

        public int COMPLETETRUCKNUM { get; set; }

        public double AVEPERIOD { get; set; }

        public double CURRENTINSTRUCTION { get; set; }

        public int Sort { get; set; }

        public string myTime { get; set; }

        public string TOLOC1 { get; set; }

        public string TOLOC2 { get; set; }

        public string STATUS { get; set; }

        public string STOPFG { get; set; }

        #endregion

        public static List<TruckOperationCycle> GetTruckOperationCycles()
        {
            DataTable dt = Shsict.DataAccess.TruckStatus.GetTruckStatus();
            List<TruckOperationCycle> list = new List<TruckOperationCycle>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TruckOperationCycle(dr));
                }
            }

            return list;
        }

      
    }

}