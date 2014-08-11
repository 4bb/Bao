using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 离泊情况
    /// </summary>
    public class VesselDepart
    {
        public VesselDepart() { }

        public VesselDepart(DataRow dr)
        {
            InitVesselDepart(dr);
        }

        private void InitVesselDepart(DataRow dr)
        {
            if (dr != null)
            {
                REPORT_DATE = DateTime.Parse(dr["REPORT_DATE"].ToString());

                VSL_CNNAME = dr["VSL_CNNAME"].ToString();

                if (!string.IsNullOrEmpty(dr["VBT_PDPTDT"].ToString()))
                {
                    VBT_PDPTDT = DateTime.Parse(dr["VBT_PDPTDT"].ToString());
                }
                else
                {
                    VBT_PDPTDT = null;
                }

                if (!string.IsNullOrEmpty(dr["VBT_ADPTDT"].ToString()))
                {
                    VBT_ADPTDT = DateTime.Parse(dr["VBT_ADPTDT"].ToString());
                }
                else
                {
                    VBT_ADPTDT = null;
                }

                VBT_STATUS = dr["VBT_STATUS"].ToString();

                ISLATER = dr["ISLATER"].ToString();

                VOT_AWKENTM = dr["VOT_AWKENTM"].ToString();


                WKLATER = dr["WKLATER"].ToString();


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

        public DateTime? VBT_PDPTDT { get; set; }

        public DateTime? VBT_ADPTDT { get; set; }

        public string VBT_STATUS { get; set; }

        public string ISLATER { get; set; }

        public string VOT_AWKENTM { get; set; }

        public string WKLATER { get; set; }

        public string MyDate { get; set; }

        public double punctualityRate { get; set; }

        #endregion

        public static List<VesselDepart> GetVesselDeparts()
        {
            DataTable dt = Shsict.DataAccess.VesselDepart.GetVesselDeparts();
            List<VesselDepart> list = new List<VesselDepart>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselDepart(dr));
                }
            }

            return list;
        }

    }

}