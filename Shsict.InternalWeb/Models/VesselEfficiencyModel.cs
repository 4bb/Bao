using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 船舶效率
    /// </summary>
    public class VesselEfficiency
    {
        public VesselEfficiency() { }

        public VesselEfficiency(DataRow dr)
        {
            InitVesselEfficiency(dr);
        }

        private void InitVesselEfficiency(DataRow dr)
        {
            if (dr != null)
            {

                REPORT_DATE = DateTime.Parse(dr["REPORT_DATE"].ToString());
                VSL_CNNAME = dr["VSL_CNNAME"].ToString();
                QCOPTM = dr["QCOPTM"].ToString();
                QCNETTM = dr["QCNETTM"].ToString();
                AVGEFF = dr["AVGEFF"].ToString();
                ABTHNO = dr["ABTHNO"].ToString();

                MyDate = REPORT_DATE.ToString("yyyy-MM-dd");

            }
            else
            {
                throw new Exception("Unable to init DailyReport.");
            }
        }

        #region members and propertis

        public DateTime REPORT_DATE { get; set; }

        public string VSL_CNNAME { get; set; }

        public string QCOPTM { get; set; }

        public string QCNETTM { get; set; }

        public string AVGEFF { get; set; }

        public string ABTHNO { get; set; }

        public string MyDate { get; set; }
        #endregion

        //public void Select()
        //{
        //    DataRow dr = Shsict.DataAccess.ThreeShift.GetThreeShiftByID(SID);

        //    if (dr != null)
        //    {
        //        InitDailyReport(dr);
        //    }
        //}

        public static List<VesselEfficiency> GetVesselEfficiencyByDate(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.VesselEfficiency.GetVesselEfficiencyByDate(Date);
            List<VesselEfficiency> list = new List<VesselEfficiency>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselEfficiency(dr));
                }
            }

            return list;
        }

        public static List<VesselEfficiency> GetVesselEfficiencys()
        {
            DataTable dt = Shsict.DataAccess.VesselEfficiency.GetVesselEfficiencys();
            List<VesselEfficiency> list = new List<VesselEfficiency>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselEfficiency(dr));
                }
            }

            return list;
        }

    }

}