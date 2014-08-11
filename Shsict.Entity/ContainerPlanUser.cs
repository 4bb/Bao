using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.Entity
{
    /// <summary>
    /// 箱货用户
    /// </summary>
    public class ContainerPlanUser
    {
        public ContainerPlanUser() { }

        public ContainerPlanUser(DataRow dr)
        {
            InitContainerPlanUser(dr);
        }

        private void InitContainerPlanUser(DataRow dr)
        {
            if (dr != null)
            {
                Usercd = dr["usercd"].ToString();
                Username = dr["username"].ToString();
                Userpasswd = dr["userpasswd"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerPlanUser.GetContainerPlanUserByID(Username, Userpasswd);

            if (dr != null)
            {
                InitContainerPlanUser(dr);
            }
        }


        public static List<ContainerPlanUser> GetContainerPlanUsers()
        {
            DataTable dt = Shsict.DataAccess.ContainerPlanUser.GetContainerPlanUsers();
            List<ContainerPlanUser> list = new List<ContainerPlanUser>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContainerPlanUser(dr));
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
                ContainerPlanUserList = GetContainerPlanUsers();
            }

            public static ContainerPlanUser Load(string Usercd)
            {
                return ContainerPlanUserList.Find(delegate(ContainerPlanUser t) { return t.Usercd.Equals(Usercd); });
            }

            public static List<ContainerPlanUser> ContainerPlanUserList;
            //public static List<ContainerPlanUser> ContainerPlanUserList_Active;
        }

        #region members and propertis

        public string Usercd { get; set; }

        public string Username { get; set; }

        public string Userpasswd { get; set; }

        #endregion

    }
}
