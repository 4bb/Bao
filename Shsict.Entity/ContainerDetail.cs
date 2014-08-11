using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.Entity
{
    /// <summary>
    /// 箱子详细
    /// </summary>
    public class ContainerDetail
    {

        public ContainerDetail() { }

        public ContainerDetail(DataRow dr)
        {
            InitContainerDetail(dr);
        }

        private void InitContainerDetail(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                ContainerNo = dr["ContainerNo"].ToString();
                CTNSize = dr["CTNSize"].ToString();
                CTNType = dr["CTNType"].ToString();
                CTNHeight = dr["CTNHeight"].ToString();
                CTNStat = dr["CTNStat"].ToString();
                SealNO = dr["SealNO"].ToString();
                BLNO = dr["BLNO"].ToString();
                CTNOwner = dr["CTNOwner"].ToString();
                CTNNetWeight = dr["CTNNetWeight"].ToString();
                RCTemerature = dr["RCTemerature"].ToString();
                DGType = dr["DGType"].ToString();
                DGUNNO = dr["DGUNNO"].ToString();
                CTNIOType = dr["DGUNNO"].ToString();

                if (!string.IsNullOrEmpty(dr["PlanWorkTime"].ToString()))
                {
                    PlanWorkTime = DateTime.Parse(dr["PlanWorkTime"].ToString());
                }
                else
                {
                    PlanWorkTime = null;
                }

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

                if (!string.IsNullOrEmpty(dr["TCTNEmpty"].ToString()))
                {
                    TCTNEmpty = DateTime.Parse(dr["TCTNEmpty"].ToString());
                }
                else
                {
                    TCTNEmpty = null;
                }

                RCTNEmpty = dr["RCTNEmpty"].ToString();
                FirstVVessel = dr["FirstVVessel"].ToString();
                FirstVVoyage = dr["FirstVVoyage"].ToString();
                SecondVVessel = dr["SecondVVessel"].ToString();
                SecondVVoyage = dr["SecondVVoyage"].ToString();
                LoadingPort = dr["LoadingPort"].ToString();
                DischargingPort = dr["DischargingPort"].ToString();
                DestinationPort = dr["DestinationPort"].ToString();
                CustomsClearance = dr["CustomsClearance"].ToString();
                Stowagefg = dr["Stowagefg"].ToString();
                CTNYardSlot = dr["CTNYardSlot"].ToString();
                OverCTNType = dr["OverCTNType"].ToString();
                OverWeight = dr["OverWeight"].ToString();
                OverHeight = dr["OverHeight"].ToString();
                FOL = dr["FOL"].ToString();
                BOL = dr["BOL"].ToString();
                LOW = dr["LOW"].ToString();
                RoWidth = dr["RoWidth"].ToString();
                IsTurnCTN = dr["IsTurnCTN"].ToString();
                //InvoiceNO = dr["InvoiceNO"].ToString();
                IsDamaged = dr["IsDamaged"].ToString();

                ArriveISLate = dr["ArriveISLate"].ToString();

            }
            else
            {
                throw new Exception("Unable to init ContainerDetail.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerDetail.GetContainerDetailByID(ID);

            if (dr != null)
            {
                InitContainerDetail(dr);
            }
        }

        public static List<ContainerDetail> GetContainerDetails()
        {
            DataTable dt = Shsict.DataAccess.ContainerDetail.GetContainerDetails();
            List<ContainerDetail> list = new List<ContainerDetail>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerDetail(dr));
                }
            }

            return list;
        }

        //public static List<ContainerDetail> GetContainerDetails(string ContainerNoOrbill)
        //{
        //    DataTable dt = Shsict.DataAccess.ContainerDetail.GetContainerDetailByNum(ContainerNoOrbill);
        //    List<ContainerDetail> list = new List<ContainerDetail>();

        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(new ContainerDetail(dr));
        //        }
        //    }

        //    return list;
        //}

        public static List<ContainerDetail> GetContainerDetailsByBLNO(string billNo)
        {
            DataTable dt = Shsict.DataAccess.ContainerDetail.GetContainerDetailByBLNO(billNo);
            List<ContainerDetail> list = new List<ContainerDetail>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerDetail(dr));
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
                ContainerDetailCache.Clear();
            }

            private static void InitCache()
            {
                ContainerDetailList = GetContainerDetails();
            }

            public static ContainerDetail Load(string tID)
            {
                if (ContainerDetailCache.ContainsKey(tID))
                {
                    return ContainerDetailCache[tID];
                }
                else
                {
                    ContainerDetail cd = new ContainerDetail();

                    cd.ID = tID;
                    cd.Select();

                    if (cd != null)
                    {
                        ContainerDetailCache.Add(tID, cd);
                    }

                    return cd;
                }
            }

            private static Dictionary<string, ContainerDetail> ContainerDetailCache = new Dictionary<string, ContainerDetail>();
            private static List<ContainerDetail> ContainerDetailList;
        }

        #region members and propertis

        public string ID { get; set; }

        public string ContainerNo { get; set; }

        public string CTNSize { get; set; }

        public string CTNType { get; set; }

        public string CTNHeight { get; set; }

        public string CTNStat { get; set; }

        public string SealNO { get; set; }

        public string BLNO { get; set; }

        public string CTNOwner { get; set; }

        public string CTNNetWeight { get; set; }

        public string RCTemerature { get; set; }

        public string DGType { get; set; }

        public string DGUNNO { get; set; }

        public string CTNIOType { get; set; }

        public DateTime? PlanWorkTime { get; set; }

        public DateTime? ArriveTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string ArriveType { get; set; }

        public string DepartureType { get; set; }

        public DateTime? TCTNEmpty { get; set; }

        public string RCTNEmpty { get; set; }

        public string FirstVVessel { get; set; }

        public string FirstVVoyage { get; set; }

        public string SecondVVessel { get; set; }

        public string SecondVVoyage { get; set; }

        public string LoadingPort { get; set; }

        public string DischargingPort { get; set; }

        public string DestinationPort { get; set; }

        public string CustomsClearance { get; set; }

        public string Stowagefg { get; set; }

        public string CTNYardSlot { get; set; }

        public string OverCTNType { get; set; }

        public string OverWeight { get; set; }

        public string OverHeight { get; set; }

        public string FOL { get; set; }

        public string BOL { get; set; }

        public string LOW { get; set; }

        public string RoWidth { get; set; }

        public string IsTurnCTN { get; set; }

        //public string InvoiceNO { get; set; }

        public string IsDamaged { get; set; }

        public string ArriveISLate { get; set; }

        #endregion



    }
}
