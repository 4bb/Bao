using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 昼夜吞吐量
    /// </summary>
    public class DailyReport
    {
        public DailyReport() { }

        public DailyReport(DataRow dr)
        {
            InitDailyReport(dr);
        }

        private void InitDailyReport(DataRow dr)
        {
            if (dr != null)
            {

                REPORT_DATE = DateTime.Parse(dr["REPORT_DATE"].ToString());
                LASTALLDAY_PLAN = dr["LASTALLDAY_PLAN"].ToString();
                LASTALLDAY_ACTUAL = dr["LASTALLDAY_ACTUAL"].ToString();
                LASTALLDAY_BARGE = dr["LASTALLDAY_BARGE"].ToString();
                LASTALLDAY_SHUTTLE = dr["LASTALLDAY_SHUTTLE"].ToString();
                LASTALLDAY_COMPLETERATE = dr["round(LASTALLDAY_COMPLETERATE,5)"].ToString();
                MONTHLY_PLAN = dr["MONTHLY_PLAN"].ToString();
                MONTHLY_TARGET = dr["MONTHLY_TARGET"].ToString();
                MONTHLY_ACTUAL = dr["MONTHLY_ACTUAL"].ToString();
                MONTHLY_BARGE = dr["MONTHLY_BARGE"].ToString();
                MONTHLY_SHUTTLE = dr["MONTHLY_SHUTTLE"].ToString();
                MONTHLY_COMPLETERATE = dr["round(MONTHLY_COMPLETERATE,5)"].ToString();
                MONTHLY_PLANCONTAINER = dr["round(MONTHLY_PLANCONTAINER,5)"].ToString();
                ANNUAL_PLAN = dr["ANNUAL_PLAN"].ToString();
                ANNUAL_ACTUAL = dr["ANNUAL_ACTUAL"].ToString();
                ANNUAL_BARGE = dr["ANNUAL_BARGE"].ToString();
                ANNUAL_SHUTTLE = dr["ANNUAL_SHUTTLE"].ToString();
                ANNUAL_COMPLETERATE = dr["round(ANNUAL_COMPLETERATE,5)"].ToString();
                ANNUAL_PLANCONTAINER = dr["round(ANNUAL_PLANCONTAINER,5)"].ToString();

                if (!string.IsNullOrEmpty(LASTALLDAY_COMPLETERATE))
                {
                    MyLASTALLDAY_COMPLETERATE = double.Parse(LASTALLDAY_COMPLETERATE).ToString("0.##%");
                }
                if (!string.IsNullOrEmpty(MONTHLY_COMPLETERATE ))
                {
                    MyMONTHLY_COMPLETERATE = double.Parse(MONTHLY_COMPLETERATE).ToString("0.##%");
                }
                if (!string.IsNullOrEmpty(ANNUAL_COMPLETERATE))
                {
                    MyANNUAL_COMPLETERATE = double.Parse(ANNUAL_COMPLETERATE).ToString("0.##%");
                }
                
                MyDate = REPORT_DATE.ToString("yyyy-MM-dd");
            }
            else
            {
                throw new Exception("Unable to init DailyReport.");
            }
        }

        #region members and propertis

        public DateTime REPORT_DATE { get; set; }

        public string LASTALLDAY_PLAN { get; set; }

        public string LASTALLDAY_ACTUAL { get; set; }

        public string LASTALLDAY_BARGE { get; set; }

        public string LASTALLDAY_SHUTTLE { get; set; }

        public string LASTALLDAY_COMPLETERATE { get; set; }

        public string MONTHLY_PLAN { get; set; }

        public string MONTHLY_TARGET { get; set; }

        public string MONTHLY_ACTUAL { get; set; }

        public string MONTHLY_BARGE { get; set; }

        public string MONTHLY_SHUTTLE { get; set; }

        public string MONTHLY_COMPLETERATE { get; set; }

        public string MONTHLY_PLANCONTAINER { get; set; }

        public string ANNUAL_PLAN { get; set; }

        public string ANNUAL_ACTUAL { get; set; }

        public string ANNUAL_BARGE { get; set; }

        public string ANNUAL_SHUTTLE { get; set; }

        public string ANNUAL_COMPLETERATE { get; set; }

        public string ANNUAL_PLANCONTAINER { get; set; }

        public string MyLASTALLDAY_COMPLETERATE { get; set; }

        public string MyMONTHLY_COMPLETERATE { get; set; }

        public string MyANNUAL_COMPLETERATE { get; set; }

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

        public static List<DailyReport> GetContainerByDate(DateTime Date)
        {

            DataTable dt = Shsict.DataAccess.DailyReport.GetDailyReportByDate(Date);
            List<DailyReport> list = new List<DailyReport>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DailyReport(dr));
                }
            }

            return list;
        }

        public static List<DailyReport> GetContainerMains()
        {
            DataTable dt = Shsict.DataAccess.DailyReport.GetDailyReports();
            List<DailyReport> list = new List<DailyReport>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DailyReport(dr));
                }
            }

            return list;
        }


    }

}