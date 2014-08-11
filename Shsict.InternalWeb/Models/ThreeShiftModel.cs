using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    public class ThreeShift
    {
        public ThreeShift() { }

        public ThreeShift(DataRow dr)
        {
            InitThreeShift(dr);
        }

        private void InitThreeShift(DataRow dr)
        {
            if (dr != null)
            {
                SHIFTDATE = DateTime.Parse(dr["SHIFTDATE"].ToString());
                SHIFT = dr["SHIFT"].ToString();
                SHIFTPLAN = dr["SHIFTPLAN"].ToString();
                SHIFTACTUAL = dr["SHIFTACTUAL"].ToString();
                SHIFTCOMPLETERATE = dr["round(SHIFTCOMPLETERATE,5)"].ToString();

                if (string.IsNullOrEmpty(SHIFTCOMPLETERATE))
                {
                    MySHIFTCOMPLETERATE = double.Parse(SHIFTCOMPLETERATE).ToString("0.##%");
                }

                MyDate = SHIFTDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                throw new Exception("Unable to init ThreeShift.");
            }
        }

        #region members and propertis

        public DateTime SHIFTDATE { get; set; }

        public string SHIFT { get; set; }

        public string SHIFTPLAN { get; set; }

        public string SHIFTACTUAL { get; set; }

        public string SHIFTCOMPLETERATE { get; set; }

        public string MyDate { get; set; }

        public string MySHIFTCOMPLETERATE { get; set; }

        #endregion

        public static List<ThreeShift> GetContainerByDate(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.ThreeShift.GetThreeShiftByDate(Date);
            List<ThreeShift> list = new List<ThreeShift>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ThreeShift(dr));
                }
            }

            return list;
        }

        public static List<ThreeShift> GetContainerMains()
        {
            DataTable dt = Shsict.DataAccess.ThreeShift.GetThreeShifts();
            List<ThreeShift> list = new List<ThreeShift>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ThreeShift(dr));
                }
            }

            return list;
        }


    }

}