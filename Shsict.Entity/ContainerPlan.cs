using System;
using System.Collections.Generic;
using System.Data;


namespace Shsict.Entity
{
    /// <summary>
    /// 计划受理
    /// </summary>
    public class ContainerPlan
    {

        public ContainerPlan() { }

        public ContainerPlan(DataRow dr)
        {
            InitContainerPlan(dr);
        }

        private void InitContainerPlan(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                VesselVoyage = dr["VesselVoyage"].ToString();
                OPERATION = dr["OPERATION"].ToString();
                PLANACCEPT = dr["PLANACCEPT"].ToString();


                if (!string.IsNullOrEmpty(dr["PlanTime"].ToString()))
                {
                    PlanTime = DateTime.Parse(dr["PlanTime"].ToString());
                }
                else
                {
                    PlanTime = null;
                }
                if (!string.IsNullOrEmpty(dr["PlanAcceptedTime"].ToString()))
                {
                    PlanAcceptedTime = DateTime.Parse(dr["PlanAcceptedTime"].ToString());
                }
                else
                {
                    PlanAcceptedTime = null;
                }
                planno = dr["planno"].ToString();
                custom = dr["custom"].ToString();


                //if (!string.IsNullOrEmpty(dr["opsttm"].ToString()))
                //{
                //    opsttm = DateTime.Parse(dr["opsttm"].ToString());
                //}
                //else
                //{
                //    opsttm = null;
                //}
                //if (!string.IsNullOrEmpty(dr["opedtm"].ToString()))
                //{
                //    opedtm = DateTime.Parse(dr["opedtm"].ToString());
                //}
                //else
                //{
                //    opedtm = null;
                //}

            }
            else
            {
                throw new Exception("Unable to init Truck.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerPlan.GetContainerPlanByID(ID);

            if (dr != null)
            {
                InitContainerPlan(dr);
            }
        }

        public static List<ContainerPlan> GetContainerPlans()
        {
            DataTable dt = Shsict.DataAccess.ContainerPlan.GetContainerPlans();
            List<ContainerPlan> list = new List<ContainerPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerPlan(dr));
                }
            }

            return list;
        }

        public static List<ContainerPlan> GetContainerPlanbyCustom(string custom)
        {
            DataTable dt = Shsict.DataAccess.ContainerPlan.GetContainerPlans(custom);
            List<ContainerPlan> list = new List<ContainerPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerPlan(dr));
                }
            }

            return list;
        }

        public static class Cache
        {
            static Cache()
            {
                // InitCache();
            }

            public static void RefreshCache()
            {
                // InitCache();
                ContainerPlanCache.Clear();
                ContainerPlanCacheUsername.Clear();
            }

            //private static void InitCache(string custom)
            //{
            //    //ContainerPlanList = GetContainerPlanbyCustom();
            //}

            public static ContainerPlan Load(string tID)
            {
                if (ContainerPlanCache.ContainsKey(tID))
                {
                    return ContainerPlanCache[tID];
                }
                else
                {
                    ContainerPlan cp = new ContainerPlan();

                    cp.ID = tID;
                    cp.Select();

                    if (cp != null)
                    {
                        ContainerPlanCache.Add(tID, cp);
                    }

                    return cp;
                }
            }

            public static List<ContainerPlan> LoadByUsername(string username)
            {

                List<ContainerPlan> list = new List<ContainerPlan>();

                if (ContainerPlanCacheUsername.ContainsKey(username))
                {
                    list = ContainerPlanCacheUsername[username];
                }
                else
                {
                    list = GetContainerPlanbyCustom(username);

                    if (list != null && list.Count > 0)
                    {
                        ContainerPlanCacheUsername.Add(username, list);
                    }
                }

                return list;
            }

            private static Dictionary<string, ContainerPlan> ContainerPlanCache = new Dictionary<string, ContainerPlan>();
            private static Dictionary<string, List<ContainerPlan>> ContainerPlanCacheUsername = new Dictionary<string, List<ContainerPlan>>();
            //private static List<ContainerPlan> ContainerPlanList;
        }

        #region members and propertis

        public string ID { get; set; }

        public string VesselVoyage { get; set; }

        public string OPERATION { get; set; }

        public string PLANACCEPT { get; set; }

        public DateTime? PlanTime { get; set; }

        public DateTime? PlanAcceptedTime { get; set; }

        public string planno { get; set; }

        public string custom { get; set; }

        #endregion







    }
}
