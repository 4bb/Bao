using System;
using System.Collections.Generic;
using System.Data;


namespace Shsict.Entity
{
    /// <summary>
    /// 挂靠港
    /// </summary>
    public class PortOfCall
    {

        public PortOfCall() { }

        public PortOfCall(DataRow dr)
        {
            InitPortOfCall(dr);
        }

        private void InitPortOfCall(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                CN = dr["CN"].ToString();
                EDI = dr["EDI"].ToString();
                PortDisplayIndex = Convert.ToInt32(dr["PortDisplayIndex"]);

            }
            else
            {
                throw new Exception("Unable to init Truck.");
            }
        }

        public static List<PortOfCall> GetPortOfCalls()
        {
            DataTable dt = Shsict.DataAccess.PortOfCall.GetPortOfCalls();
            List<PortOfCall> list = new List<PortOfCall>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PortOfCall(dr));
                }
            }

            return list;
        }

        public static List<PortOfCall> GetPortOfCalls(string pId)
        {
            DataTable dt = DataAccess.PortOfCall.GetPortOfCallByID(pId);
            List<PortOfCall> list = new List<PortOfCall>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PortOfCall(dr));
                }
            }

            return list;
        }

        public static class Cache
        {
            static Cache()
            {
                InitCache();
            }

            public static void RefreshCache()
            {
                InitCache();
            }

            private static void InitCache()
            {
                PortOfCallList = GetPortOfCalls();
            }

            public static PortOfCall Load(string tID)
            {
                return PortOfCallList.Find(delegate(PortOfCall p) { return p.ID.Equals(tID); });
            }

            public static List<PortOfCall> PortOfCallList;
        }

        #region members and propertis

        public string ID { get; set; }

        public string CN { get; set; }

        public string EDI { get; set; }

        public int PortDisplayIndex { get; set; }

        #endregion







    }

}

