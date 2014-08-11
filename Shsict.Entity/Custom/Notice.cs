using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shsict.Entity
{
    public class Notice
    {
        public Notice() { }

        public Notice(DataRow dr)
        {
            InitNotice(dr);
        }

        private void InitNotice(DataRow dr)
        {
            if (dr != null)
            {
                NoticeID = dr["NoticeID"].ToString();
                NoticeTitle = dr["NoticeTitle"].ToString();

                if (!string.IsNullOrEmpty(dr["CreateTime"].ToString()))
                {
                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
                }
                else
                {
                    CreateTime = null;
                }

                NoticeContent = dr["NoticeContent"].ToString();
                IsActive =Convert.ToInt32( dr["IsActive"]);
                Remark = dr["Remark"].ToString();

            }
            else
            {
                throw new Exception("Unable to init Notice.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.Notice.GetNoticeByID(NoticeID);

            if (dr != null)
            {
                InitNotice(dr);
            }
        }


        public static List<Notice> GetNotices()
        {
            DataTable dt = Shsict.DataAccess.Notice.GetNotices();
            List<Notice> list = new List<Notice>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Notice(dr));
                }
            }

            return list;
        }
        //public static List<Notice> GetTrucks(string TruckNo)
        //{
        //    DataTable dt = Shsict.DataAccess.OTruck.GetTrucksByNum(TruckNo);
        //    List<OTruck> list = new List<OTruck>();

        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(new OTruck(dr));
        //        }
        //    }

        //    return list;
        //}

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
                NoticeList = GetNotices();
                NoticeList_Active = NoticeList.FindAll(delegate(Notice n) { return n.IsActive.Equals(1); });
            }

            public static Notice Load(string nID)
            {
                return NoticeList.Find(delegate(Notice n) { return n.NoticeID.Equals(nID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<Notice> NoticeList;
            public static List<Notice> NoticeList_Active;
        }

        #region members and propertis

        public string NoticeID { get; set; }

        public string NoticeTitle { get; set; }

        public DateTime? CreateTime { get; set; }

        public string NoticeContent { get; set; }

        public int IsActive { get; set; }

        public string Remark { get; set; }

        #endregion




    }
   
}
