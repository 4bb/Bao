using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 在泊船舶实际及计划毛船时量
    /// </summary>
    public class VesselAmount
    {
        public VesselAmount() { }

        public VesselAmount(DataRow dr)
        {
            InitVesselAmount(dr);
        }

        private void InitVesselAmount(DataRow dr)
        {
            if (dr != null)
            {
                VESSELNAME = dr["VESSELNAME"].ToString();
                VESSELTYPE = dr["VESSELTYPE"].ToString();
                VOCOPTM = dr["VOCOPTM"].ToString();
                AMOUNTOFVESSEL = dr["AMOUNTOFVESSEL"].ToString();
                TARGETVOCTM = dr["TARGETVOCTM"].ToString();
            }
            else
            {
                throw new Exception("Unable to init VesselAmount.");
            }
        }

        #region members and propertis

        public string VESSELNAME { get; set; }

        public string VESSELTYPE { get; set; }

        public string VOCOPTM { get; set; }

        public string AMOUNTOFVESSEL { get; set; }

        public string TARGETVOCTM { get; set; }

        #endregion

        public static List<VesselAmount> GetVesselAmounts()
        {
            DataTable dt = Shsict.DataAccess.OnBerth.GetOnBerths();
            List<VesselAmount> list = new List<VesselAmount>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselAmount(dr));
                }
            }

            return list;
        }


       
    }

}