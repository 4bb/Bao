using System;
using System.Collections.Generic;
using System.Data;


namespace Shsict.Entity
{
    /// <summary>
    /// 箱子主表
    /// </summary>
    public class ContainerMain
    {
        public ContainerMain() { }

        public ContainerMain(DataRow dr)
        {
            InitContainerMain(dr);
        }

        private void InitContainerMain(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                ContainerNo = dr["ContainerNo"].ToString();
                BillOfLadingNum = dr["BillOfLadingNum"].ToString();
                IEFG = dr["IEFG"].ToString();
                ContainerStatus = dr["ContainerStatus"].ToString();
                VesselName = dr["VesselName"].ToString();
                VoyageNumber = dr["VoyageNumber"].ToString();

                if (!string.IsNullOrEmpty(dr["ArriveTime"].ToString()))
                {
                    ArriveTime = DateTime.Parse(dr["ArriveTime"].ToString());
                }
                else
                {
                    ArriveTime = null;
                }

                if (!string.IsNullOrEmpty(dr["DepartureTime"].ToString()))
                {
                    DepartureTime = DateTime.Parse(dr["DepartureTime"].ToString());
                }
                else
                {
                    DepartureTime = null;
                }

                ArriveType = dr["ArriveType"].ToString();
                DepartureType = dr["DepartureType"].ToString();


                if (!string.IsNullOrEmpty(dr["ArrivalContainerTime"].ToString()))
                {
                    ArrivalContainerTime = DateTime.Parse(dr["ArrivalContainerTime"].ToString());
                }
                else
                {
                    ArrivalContainerTime = null;
                }

                if (!string.IsNullOrEmpty(dr["CustomsClearanceTime"].ToString()))
                {
                    CustomsClearanceTime = DateTime.Parse(dr["CustomsClearanceTime"].ToString());
                }
                else
                {
                    CustomsClearanceTime = null;
                }

                if (!string.IsNullOrEmpty(dr["StowageTime"].ToString()))
                {
                    StowageTime = DateTime.Parse(dr["StowageTime"].ToString());
                }
                else
                {
                    StowageTime = null;
                }

                if (!string.IsNullOrEmpty(dr["VesselTime"].ToString()))
                {
                    VesselTime = DateTime.Parse(dr["VesselTime"].ToString());
                }
                else
                {
                    VesselTime = null;
                }

                Arrivefg = dr["Arrivefg"].ToString();
                Departurefg = dr["Departurefg"].ToString();
                CustomsClearance = dr["CustomsClearance"].ToString();
                Stowagefg = dr["Stowagefg"].ToString();
                Vesselfg = dr["Vesselfg"].ToString();

            }
            else
            {
                throw new Exception("Unable to init Truck.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerMain.GetContainerMainByID(ID);

            if (dr != null)
            {
                InitContainerMain(dr);
            }
        }

        public static List<ContainerMain> GetContainerByID(string ID)
        {
            DataRow dr = Shsict.DataAccess.ContainerMain.GetContainerMainByID(ID);
            List<ContainerMain> list = new List<ContainerMain>();

            if (dr != null)
            {

                list.Add(new ContainerMain(dr));

            }

            return list;
        }

        public static List<ContainerMain> GetContainerMains()
        {
            DataTable dt = Shsict.DataAccess.ContainerMain.GetContainerMains();
            List<ContainerMain> list = new List<ContainerMain>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerMain(dr));
                }
            }

            return list;
        }

        public static List<ContainerMain> GetContainerMainByContainerNo(string containerNo)
        {
            DataTable dt = Shsict.DataAccess.ContainerMain.GetContainerMainByContainerNo(containerNo);
            List<ContainerMain> list = new List<ContainerMain>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerMain(dr));
                }
            }

            return list;
        }

        public static List<ContainerMain> GetContainerMainByBillno(string billNo)
        {
            DataTable dt = Shsict.DataAccess.ContainerMain.GetContainerMainByBillno(billNo);
            List<ContainerMain> list = new List<ContainerMain>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerMain(dr));
                }
            }

            return list;
        }

        public static class Cache
        {
            static Cache()
            {
                //InitCache();
            }

            public static void RefreshCache()
            {
                ContainerMainCache.Clear();
                ContainerMainCacheBillno.Clear();
                ContainerMainCacheContainerNo.Clear();
            }

            //private static void InitCache()
            //{

            //}

            public static ContainerMain Load(string tID)
            {
                if (ContainerMainCache.ContainsKey(tID))
                {
                    return ContainerMainCache[tID];
                }
                else
                {
                    ContainerMain cm = new ContainerMain();

                    cm.ID = tID;
                    cm.Select();

                    if (cm != null)
                    {
                        ContainerMainCache.Add(tID, cm);
                    }

                    return cm;
                }
            }

            public static List<ContainerMain> LoadByBillno(string billNo)
            {

                List<ContainerMain> list = new List<ContainerMain>();

                if (ContainerMainCacheBillno.ContainsKey(billNo))
                {
                    list = ContainerMainCacheBillno[billNo];
                }
                else
                {
                    list = GetContainerMainByBillno(billNo);

                    if (list != null && list.Count > 0)
                    {
                        ContainerMainCacheBillno.Add(billNo, list);
                    }
                }

                return list;
            }

            public static List<ContainerMain> LoadByContainerNo(string ContainerNo)
            {

                List<ContainerMain> list = new List<ContainerMain>();

                if (ContainerMainCacheContainerNo.ContainsKey(ContainerNo))
                {
                    list = ContainerMainCacheContainerNo[ContainerNo];
                }
                else
                {
                    list = GetContainerMainByContainerNo(ContainerNo);

                    if (list != null && list.Count > 0)
                    {
                        ContainerMainCacheContainerNo.Add(ContainerNo, list);
                    }
                }

                return list;

            }

            private static Dictionary<string, ContainerMain> ContainerMainCache = new Dictionary<string, ContainerMain>();
            private static Dictionary<string, List<ContainerMain>> ContainerMainCacheContainerNo = new Dictionary<string, List<ContainerMain>>();
            private static Dictionary<string, List<ContainerMain>> ContainerMainCacheBillno = new Dictionary<string, List<ContainerMain>>();
            //private static List<ContainerMain> ContainerMainList;

        }

        #region members and propertis

        public string ID { get; set; }

        public string ContainerNo { get; set; }

        public string BillOfLadingNum { get; set; }

        public string IEFG { get; set; }

        public string ContainerStatus { get; set; }

        public string VesselName { get; set; }

        public string VoyageNumber { get; set; }

        public DateTime? ArriveTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string ArriveType { get; set; }

        public string DepartureType { get; set; }

        public DateTime? ArrivalContainerTime { get; set; }

        public DateTime? CustomsClearanceTime { get; set; }

        public DateTime? StowageTime { get; set; }

        public DateTime? VesselTime { get; set; }

        public string Arrivefg { get; set; }

        public string Departurefg { get; set; }

        public string CustomsClearance { get; set; }

        public string Stowagefg { get; set; }

        public string Vesselfg { get; set; }

        #endregion

    }
}
