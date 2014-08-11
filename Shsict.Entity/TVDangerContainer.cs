using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Shsict.Entity
{
    public class TVDangerContainer
    {

        public TVDangerContainer() { }

        public TVDangerContainer(DataRow dr)
        {
            InitTVDangerContainer(dr);
        }

        private void InitTVDangerContainer(DataRow dr)
        {
            if (dr != null)
            {
                CONTAINERNO = dr["CONTAINERNO"].ToString();
                PLANNO = dr["PLANNO"].ToString();

            }
            else
            {
                throw new Exception("Unable to init TVDangerContainer.");
            }
        }

        public static List<TVDangerContainer> GetTVDangerContainers()
        {
            DataTable dt = Shsict.DataAccess.TVDangerContainer.GetTVDangerContainers();
            List<TVDangerContainer> list = new List<TVDangerContainer>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TVDangerContainer(dr));
                }
            }

            return list;
        }

        public static List<TVDangerContainer> GetTVDangerContainers(string planNo)
        {
            DataTable dt = DataAccess.TVDangerContainer.GetTVDangerContainerByID(planNo);
            List<TVDangerContainer> list = new List<TVDangerContainer>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TVDangerContainer(dr));
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
                TVDangerContainerList = GetTVDangerContainers();
            }

            public static TVDangerContainer Load(string planNo)
            {
                return TVDangerContainerList.Find(delegate(TVDangerContainer p) { return p.PLANNO.Equals(planNo); });
            }

            public static List<TVDangerContainer> TVDangerContainerList;
        }

        #region members and propertis

        public string CONTAINERNO { get; set; }

        public string PLANNO { get; set; }

        #endregion
    }

}
