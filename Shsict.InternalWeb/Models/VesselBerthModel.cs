using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 靠离泊情况
    /// </summary>
    public class VesselBerth
    {
        public VesselBerth() { }

        public VesselBerth(DataRow dr)
        {
            InitVesselBerth(dr);
        }

        private void InitVesselBerth(DataRow dr)
        {
            if (dr != null)
            {

                REPORT_DATE = DateTime.Parse(dr["REPORT_DATE"].ToString());

                VSL_CNNAME = dr["VSL_CNNAME"].ToString();

                if (!string.IsNullOrEmpty(dr["VBT_PBTHDT"].ToString()))
                {
                    VBT_PBTHDT = DateTime.Parse(dr["VBT_PBTHDT"].ToString());
                }
                else
                {
                    VBT_PBTHDT = null;
                }

                if (!string.IsNullOrEmpty(dr["VBT_ABTHDT"].ToString()))
                {
                    VBT_ABTHDT = DateTime.Parse(dr["VBT_ABTHDT"].ToString());
                }
                else
                {
                    VBT_ABTHDT = null;
                }

                VBT_STATUS = dr["VBT_STATUS"].ToString();

                if (!string.IsNullOrEmpty(dr["VOT_AWKSTTM"].ToString()))
                {
                    VOT_AWKSTTM = DateTime.Parse(dr["VOT_AWKSTTM"].ToString());
                }
                else
                {
                    VOT_AWKSTTM = null;
                }

                ISLATER = dr["ISLATER"].ToString();

                MyDate = REPORT_DATE.ToString("yyyy-MM-dd");

            }
            else
            {
                throw new Exception("Unable to init VesselBerth.");
            }
        }

        #region members and propertis

        public DateTime REPORT_DATE { get; set; }

        public string VSL_CNNAME { get; set; }

        public DateTime? VBT_PBTHDT { get; set; }

        public DateTime? VBT_ABTHDT { get; set; }

        public string VBT_STATUS { get; set; }

        public DateTime? VOT_AWKSTTM { get; set; }

        public string ISLATER { get; set; }

        public string MyDate { get; set; }

        public double punctualityRate { get; set; }

        #endregion

        //public void Select()
        //{
        //    DataRow dr = Shsict.DataAccess.ThreeShift.GetThreeShiftByID(SID);

        //    if (dr != null)
        //    {
        //        InitDailyReport(dr);
        //    }
        //}

        public static List<VesselBerth> GetVesselBerthByDate(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.VesselBerth.GetVesselBerthByDate(Date);
            List<VesselBerth> list = new List<VesselBerth>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselBerth(dr));
                }
            }

            return list;
        }

        public static List<VesselBerth> GetVesselBerths()
        {
            DataTable dt = Shsict.DataAccess.VesselBerth.GetVesselBerths();
            List<VesselBerth> list = new List<VesselBerth>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselBerth(dr));
                }
            }

            return list;
        }

    }

}