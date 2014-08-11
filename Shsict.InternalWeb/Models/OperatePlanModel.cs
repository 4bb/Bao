using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    public class OperatePlan
    {
        public OperatePlan() { }

        public OperatePlan(DataRow dr)
        {
            InitOperatePlan(dr);
        }

        private void InitOperatePlan(DataRow dr)
        {

            if (dr != null)
            {
                SHIFT_DATE = DateTime.Parse(dr["SHIFT_DATE"].ToString());
                SHIFT = dr["SHIFT"].ToString();
                TEAMNAME = dr["TEAMNAME"].ToString();
                OP_ROUTE = dr["OP_ROUTE"].ToString();
                QB = dr["QB"].ToString();
                HG = dr["HG"].ToString();
                FZ = dr["FZ"].ToString();
                OTHER = dr["OTHER"].ToString();
                SHIFT_NUM = dr["SHIFT_NUM"].ToString();
                ATD_DIFF = dr["ATD_DIFF"].ToString();
                MyDate = SHIFT_DATE.ToString("yyyy-MM-dd");
            }
            else
            {
                throw new Exception("Unable to init OperatePlan.");
            }
        }

        #region members and propertis
        public DateTime SHIFT_DATE { get; set; }

        public string SHIFT { get; set; }

        public string TEAMNAME { get; set; }

        public string OP_ROUTE { get; set; }

        public string QB { get; set; }

        public string HG { get; set; }

        public string FZ { get; set; }

        public string OTHER { get; set; }

        public string SHIFT_NUM { get; set; }

        public string ATD_DIFF { get; set; }

          public string MyDate { get; set; }

        #endregion

        public static List<OperatePlan> GetOperatePlans()
        {
            DataTable dt = Shsict.DataAccess.OperatePlan.GetOperatePlans();
            List<OperatePlan> list = new List<OperatePlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OperatePlan(dr));
                }
            }

            return list;
        } 
    }

}