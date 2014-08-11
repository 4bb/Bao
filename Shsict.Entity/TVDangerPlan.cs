using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Shsict.Entity
{    /// <summary>
    /// 直装直提
    /// </summary>
   public class TVDangerPlan
    {
    
        public TVDangerPlan() { }

        public TVDangerPlan(DataRow dr)
        {
            InitTVDangerPlan(dr);
        }

        private void InitTVDangerPlan(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                PLANNO = dr["PLANNO"].ToString();
                CUSTOM = dr["CUSTOM"].ToString();
                VESSELVOYAGE = dr["VESSELVOYAGE"].ToString();


                if (!string.IsNullOrEmpty(dr["ARRIVE_PLAN_TIME"].ToString()))
                {
                    ARRIVE_PLAN_TIME = DateTime.Parse(dr["ARRIVE_PLAN_TIME"].ToString());
                }
                else
                {
                    ARRIVE_PLAN_TIME = null;
                }

                if (!string.IsNullOrEmpty(dr["DEPARTURE_PLAN_TIME"].ToString()))
                {
                    DEPARTURE_PLAN_TIME = DateTime.Parse(dr["DEPARTURE_PLAN_TIME"].ToString());
                }
                else
                {
                    DEPARTURE_PLAN_TIME = null;
                }

                if (!string.IsNullOrEmpty(dr["TVDATE"].ToString()))
                {
                    TVDATE = DateTime.Parse(dr["TVDATE"].ToString());
                }
                else
                {
                    TVDATE = null;
                }

                if (!string.IsNullOrEmpty(dr["EXACTTVDATE"].ToString()))
                {
                    EXACTTVDATE = DateTime.Parse(dr["EXACTTVDATE"].ToString());
                }
                else
                {
                    EXACTTVDATE = null;
                }

       

            }
            else
            {
                throw new Exception("Unable to init Truck.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.TVDangerPlan.GetTVDangerPlanByID(ID);

            if (dr != null)
            {
                InitTVDangerPlan(dr);
            }
        }

        public static List<TVDangerPlan> GetTVDangerPlans()
        {
            DataTable dt = Shsict.DataAccess.TVDangerPlan.GetTVDangerPlans();
            List<TVDangerPlan> list = new List<TVDangerPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TVDangerPlan(dr));
                }
            }

            return list;
        }

        public static List<TVDangerPlan> GetTVDangerPlanbyCustom(string custom)
        {
            DataTable dt = Shsict.DataAccess.TVDangerPlan.GetTVDangerPlans(custom);
            List<TVDangerPlan> list = new List<TVDangerPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TVDangerPlan(dr));
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
                TVDangerPlanCache.Clear();
                TVDangerPlanCacheUsername.Clear();
            }

            //private static void InitCache(string custom)
            //{
            //    //ContainerPlanList = GetContainerPlanbyCustom();
            //}

            public static TVDangerPlan Load(string tID)
            {
                if (TVDangerPlanCache.ContainsKey(tID))
                {
                    return TVDangerPlanCache[tID];
                }
                else
                {
                    TVDangerPlan cp = new TVDangerPlan();

                    cp.ID = tID;
                    cp.Select();

                    if (cp != null)
                    {
                        TVDangerPlanCache.Add(tID, cp);
                    }

                    return cp;
                }
            }

            public static List<TVDangerPlan> LoadByUsername(string username)
            {

                List<TVDangerPlan> list = new List<TVDangerPlan>();

                if (TVDangerPlanCacheUsername.ContainsKey(username))
                {
                    list = TVDangerPlanCacheUsername[username];
                }
                else
                {
                    list = GetTVDangerPlanbyCustom(username);

                    if (list != null && list.Count > 0)
                    {
                        TVDangerPlanCacheUsername.Add(username, list);
                    }
                }

                return list;
            }

            private static Dictionary<string, TVDangerPlan> TVDangerPlanCache = new Dictionary<string, TVDangerPlan>();
            private static Dictionary<string, List<TVDangerPlan>> TVDangerPlanCacheUsername = new Dictionary<string, List<TVDangerPlan>>();
            //private static List<TVDangerPlan> TVDangerPlanList;
        }

        #region members and propertis

        public string ID { get; set; }

        public string PLANNO { get; set; }

        public string CUSTOM { get; set; }

        public string VESSELVOYAGE { get; set; }

        public DateTime? ARRIVE_PLAN_TIME { get; set; }

        public DateTime? DEPARTURE_PLAN_TIME { get; set; }

        public DateTime? TVDATE { get; set; }

        public DateTime? EXACTTVDATE { get; set; }

        #endregion

    }
}

