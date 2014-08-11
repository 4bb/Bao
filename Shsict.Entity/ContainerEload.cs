using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.Entity
{
    /// <summary>
    /// 码头运抵报告
    /// </summary>
    public class ContainerEload
    {
        public ContainerEload() { }

        public ContainerEload(DataRow dr)
        {
            InitContainerEload(dr);
        }

        private void InitContainerEload(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["cntrID"].ToString();
                VesselName = dr["VesselName"].ToString();
                VoyageNumber = dr["VoyageNumber"].ToString();
                BillOfLadingNum = dr["BillOfLadingNum"].ToString();
                ContainerNo = dr["ContainerNo"].ToString();

                if (!string.IsNullOrEmpty(dr["ArrivalContainerTime"].ToString()))
                {
                    ArrivalContainerTime = DateTime.Parse(dr["ArrivalContainerTime"].ToString());
                }
                else
                {
                    ArrivalContainerTime = null;
                }

                if (!string.IsNullOrEmpty(dr["SendPackingListTime"].ToString()))
                {
                    SendPackingListTime = DateTime.Parse(dr["SendPackingListTime"].ToString());
                }
                else
                {
                    SendPackingListTime = null;
                }
            }
            else
            {
                throw new Exception("Unable to init ContainerEload.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerEload.GetContainerEloadByID(ID);

            if (dr != null)
            {
                InitContainerEload(dr);
            }
        }

        public static List<ContainerEload> GetContainerEloadByID(string id)
        {
            DataRow dr = Shsict.DataAccess.ContainerEload.GetContainerEloadByID(id);
            List<ContainerEload> list = new List<ContainerEload>();

            if (dr != null)
            {
                list.Add(new ContainerEload(dr));
            }

            return list;
        }

        public static List<ContainerEload> GetContainerEloads()
        {
            DataTable dt = Shsict.DataAccess.ContainerEload.GetContainerEloads();
            List<ContainerEload> list = new List<ContainerEload>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerEload(dr));
                }
            }

            return list;
        }

        public static List<ContainerEload> GetContainerEloadsByContainerNo(string ContainerNo)
        {
            DataTable dt = Shsict.DataAccess.ContainerEload.GetContainerEloadByContainerNo(ContainerNo);
            List<ContainerEload> list = new List<ContainerEload>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerEload(dr));
                }
            }

            return list;
        }
        public static List<ContainerEload> GetContainerEloadsByBillOfLadingNum(string BillOfLadingNum)
        {
            DataTable dt = Shsict.DataAccess.ContainerEload.GetContainerEloadByBillOfLadingNum(BillOfLadingNum);
            List<ContainerEload> list = new List<ContainerEload>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerEload(dr));
                }
            }

            return list;
        }


        public static class Cache
        {
            static Cache()
            {
                //  InitCache();
            }

            public static void RefreshCache()
            {
                ContainerEloadCacheContainerNo.Clear();
                ContainerEloadCacheBillno.Clear();
            }

            private static void InitCache()
            {
                ContainerEloadList = GetContainerEloads();
            }

            public static ContainerEload Load(string tID)
            {
                if (ContainerEloadCache.ContainsKey(tID))
                {
                    return ContainerEloadCache[tID];
                }
                else
                {
                    ContainerEload ce = new ContainerEload();

                    ce.ID = tID;
                    ce.Select();

                    if (ce != null)
                    {
                        ContainerEloadCache.Add(tID, ce);
                    }

                    return ce;
                }
            }

            public static List<ContainerEload> LoadByContainerNo(string containerNo)
            {
                List<ContainerEload> list = new List<ContainerEload>();

                if (ContainerEloadCacheContainerNo.ContainsKey(containerNo))
                {
                    list = ContainerEloadCacheContainerNo[containerNo];
                }
                else
                {
                    list = GetContainerEloadsByContainerNo(containerNo);

                    if (list != null && list.Count > 0)
                    {
                        ContainerEloadCacheContainerNo.Add(containerNo, list);
                    }
                }

                return list;

            }

            public static List<ContainerEload> LoadByBillno(string billNo)
            {

                List<ContainerEload> list = new List<ContainerEload>();

                if (ContainerEloadCacheBillno.ContainsKey(billNo))
                {
                    list = ContainerEloadCacheBillno[billNo];
                }
                else
                {
                    list = GetContainerEloadsByBillOfLadingNum(billNo);

                    if (list != null && list.Count > 0)
                    {
                        ContainerEloadCacheBillno.Add(billNo, list);
                    }
                }

                return list;
            }

            private static Dictionary<string, ContainerEload> ContainerEloadCache = new Dictionary<string, ContainerEload>();
            private static Dictionary<string, List<ContainerEload>> ContainerEloadCacheContainerNo = new Dictionary<string, List<ContainerEload>>();
            private static Dictionary<string, List<ContainerEload>> ContainerEloadCacheBillno = new Dictionary<string, List<ContainerEload>>();
            private static List<ContainerEload> ContainerEloadList;

        }

        #region members and propertis

        public string ID { get; set; }

        public string VesselName { get; set; }

        public string VoyageNumber { get; set; }

        public string BillOfLadingNum { get; set; }

        public string ContainerNo { get; set; }

        public DateTime? ArrivalContainerTime { get; set; }

        public DateTime? SendPackingListTime { get; set; }

        #endregion

    }
}
