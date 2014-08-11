using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;

namespace Shsict.Entity
{
    /// <summary>
    /// Favourite 收藏夹
    /// </summary>
    public class MyFavourite
    {
        public MyFavourite() { }

        public MyFavourite(DataRow dr)
        {
            InitFavourite(dr);
        }
        private void InitFavourite(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                URL = dr["URL"].ToString();
                USERNAME = dr["USERNAME"].ToString();

                if (!string.IsNullOrEmpty(dr["CREATETIME"].ToString()))
                {
                    CREATETIME = DateTime.Parse(dr["CREATETIME"].ToString());
                }
                else
                {
                    CREATETIME = null;
                }
                STATUS = Convert.ToInt32(dr["STATUS"]);


                if (!string.IsNullOrEmpty(dr["UPDATETIME"].ToString()))
                {
                    UPDATETIME = DateTime.Parse(dr["UPDATETIME"].ToString());
                }
                else
                {
                    UPDATETIME = null;

                }
                OBJECTID = dr["OBJECTID"].ToString();
                OBJECTCONTENT = dr["OBJECTCONTENT"].ToString();
                OBJECTTYPE = dr["OBJECTTYPE"].ToString();
                ISACTIVE = Convert.ToInt32(dr["ISACTIVE"]);
                REMARK = dr["REMARK"].ToString();

                UpdateFlag = false;
            }
            else
            {
                throw new Exception("Unable to init Favourite.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.MyFavourite.GetFavouriteByID(ID);

            if (dr != null)
            {
                InitFavourite(dr);
            }
        }

        public void Insert()
        {
            Shsict.DataAccess.MyFavourite.InsertFavourite(ID, URL, USERNAME, (DateTime)CREATETIME, STATUS, (DateTime)UPDATETIME, OBJECTID, OBJECTCONTENT, OBJECTTYPE, ISACTIVE, REMARK);

        }

        public void Update()
        {
            Shsict.DataAccess.MyFavourite.UpdateFavourite(ID, URL, USERNAME, (DateTime)CREATETIME, STATUS, (DateTime)UPDATETIME, OBJECTID, OBJECTCONTENT, OBJECTTYPE, ISACTIVE, REMARK);

        }

        public void Delete()
        {
            Shsict.DataAccess.MyFavourite.DeleteFavourite(ID);

        }

        public static List<MyFavourite> GetFavourites()
        {
            DataTable dt = Shsict.DataAccess.MyFavourite.GetFavourites();
            List<MyFavourite> list = new List<MyFavourite>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MyFavourite(dr));
                }
            }

            return list;
        }

        private void OverRideObjContent(string objContent)
        {
            if (!objContent.Equals(OBJECTCONTENT, StringComparison.OrdinalIgnoreCase))
            {
                OBJECTCONTENT = objContent;
                UPDATETIME = DateTime.Now.ToLocalTime();
                STATUS = 1;
                UpdateFlag = true;
            }
        }

        public static void RefreshByUser(string username, string source)
        {
            List<MyFavourite> list = MyFavourite.Cache.FavouriteList_Active.FindAll(f => f.USERNAME.Equals(username));

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            if (list.Count > 0 && source == "cache")
            {
                foreach (MyFavourite mf in list)
                {
                    switch (mf.OBJECTTYPE)
                    {
                        case "ContainerEload":
                            ContainerEload ce = ContainerEload.Cache.Load(mf.OBJECTID);

                            if (ce != null) { mf.OverRideObjContent(jsonSerializer.Serialize(ce)); }

                            break;
                        case "ContainerMain":
                        case "ContainerDetail":
                            ContainerMain cm = ContainerMain.Cache.Load(mf.OBJECTID);

                            if (cm != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cm)); }

                            break;
                        case "ContainerPlan":
                            ContainerPlan cp = ContainerPlan.Cache.Load(mf.OBJECTID);

                            if (cp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cp)); }

                            break;
                        case "Truck":
                            OTruck truck = OTruck.Cache.Load(mf.OBJECTID);

                            if (truck != null) { mf.OverRideObjContent(jsonSerializer.Serialize(truck)); }

                            break;
                        case "VesselPlan":
                            OVesselPlan vp = OVesselPlan.Cache.Load(mf.OBJECTID);

                            if (vp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(vp)); }

                            break;
                        default:
                            break;
                    }
                }
            }
            else if (list.Count > 0 && source == "database")
            {
                foreach (MyFavourite mf in list)
                {
                    switch (mf.OBJECTTYPE)
                    {
                        case "ContainerEload":
                            ContainerEload ce = new ContainerEload();
                            ce.ID = mf.OBJECTID;
                            ce.Select();
                            if (ce != null) { mf.OverRideObjContent(jsonSerializer.Serialize(ce)); }

                            break;
                        case "ContainerMain":
                        case "ContainerDetail":
                            ContainerMain cm = new ContainerMain();
                            cm.ID = mf.OBJECTID;
                            cm.Select();

                            if (cm != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cm)); }

                            break;
                        case "ContainerPlan":
                            ContainerPlan cp = new ContainerPlan();
                            cp.ID = mf.OBJECTID;
                            cp.Select();

                            if (cp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cp)); }

                            break;
                        case "Truck":
                            OTruck truck = new OTruck();
                            truck.ID = mf.OBJECTID;
                            truck.Select();

                            if (truck != null) { mf.OverRideObjContent(jsonSerializer.Serialize(truck)); }

                            break;
                        case "VesselPlan":
                            OVesselPlan vp = new OVesselPlan();
                            vp.ID = mf.OBJECTID;
                            vp.Select();

                            if (vp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(vp)); }

                            break;
                        default:
                            break;
                    }
                }

            }

            // 持久化
            list = list.FindAll(f => f.UpdateFlag);

            foreach (MyFavourite mf in list)
            {
                mf.Update();
            }
        }

        public static void ReloadAll(string source)
        {
            List<MyFavourite> list = MyFavourite.Cache.FavouriteList_Active;

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            if (list.Count > 0 && source == "cache")
            {
                foreach (MyFavourite mf in list)
                {
                    switch (mf.OBJECTTYPE)
                    {
                        case "ContainerEload":
                            ContainerEload ce = ContainerEload.Cache.Load(mf.OBJECTID);

                            if (ce != null) { mf.OverRideObjContent(jsonSerializer.Serialize(ce)); }

                            break;
                        case "ContainerMain":
                        case "ContainerDetail":
                            ContainerMain cm = ContainerMain.Cache.Load(mf.OBJECTID);

                            if (cm != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cm)); }

                            break;
                        case "ContainerPlan":
                            ContainerPlan cp = ContainerPlan.Cache.Load(mf.OBJECTID);

                            if (cp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cp)); }

                            break;
                        case "Truck":
                            OTruck truck = OTruck.Cache.Load(mf.OBJECTID);

                            if (truck != null) { mf.OverRideObjContent(jsonSerializer.Serialize(truck)); }

                            break;
                        case "VesselPlan":
                            OVesselPlan vp = OVesselPlan.Cache.Load(mf.OBJECTID);

                            if (vp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(vp)); }

                            break;
                        default:
                            break;
                    }
                }
            }
            else if (list.Count > 0 && source == "database")
            {
                foreach (MyFavourite mf in list)
                {
                    switch (mf.OBJECTTYPE)
                    {
                        case "ContainerEload":
                            ContainerEload ce = new ContainerEload();
                            ce.ID = mf.OBJECTID;
                            ce.Select();
                            if (ce != null) { mf.OverRideObjContent(jsonSerializer.Serialize(ce)); }

                            break;
                        case "ContainerMain":
                        case "ContainerDetail":
                            ContainerMain cm = new ContainerMain();
                            cm.ID = mf.OBJECTID;
                            cm.Select();

                            if (cm != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cm)); }

                            break;
                        case "ContainerPlan":
                            ContainerPlan cp = new ContainerPlan();
                            cp.ID = mf.OBJECTID;
                            cp.Select();

                            if (cp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(cp)); }

                            break;
                        case "Truck":
                            OTruck truck = new OTruck();
                            truck.ID = mf.OBJECTID;
                            truck.Select();

                            if (truck != null) { mf.OverRideObjContent(jsonSerializer.Serialize(truck)); }

                            break;
                        case "VesselPlan":
                            OVesselPlan vp = new OVesselPlan();
                            vp.ID = mf.OBJECTID;
                            vp.Select();

                            if (vp != null) { mf.OverRideObjContent(jsonSerializer.Serialize(vp)); }

                            break;
                        default:
                            break;
                    }
                }

            }

            // 持久化
            list = list.FindAll(f => f.UpdateFlag);

            foreach (MyFavourite mf in list)
            {
                mf.Update();
            }
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
                FavouriteList = GetFavourites();
                FavouriteList_Active = FavouriteList.FindAll(delegate(MyFavourite f) { return f.ISACTIVE.Equals(1); });
            }

            public static MyFavourite Load(string fID)
            {
                return FavouriteList_Active.Find(delegate(MyFavourite f) { return f.ID.Equals(fID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<MyFavourite> FavouriteList;
            public static List<MyFavourite> FavouriteList_Active;
        }

        #region members and propertis

        public string ID { get; set; }

        public string URL { get; set; }

        public string USERNAME { get; set; }

        public DateTime? CREATETIME { get; set; }

        public DateTime? UPDATETIME { get; set; }

        public int STATUS { get; set; }

        public string OBJECTID { get; set; }

        public string OBJECTCONTENT { get; set; }

        public string OBJECTTYPE { get; set; }

        public int ISACTIVE { get; set; }

        public string REMARK { get; set; }

        private bool UpdateFlag { get; set; }

        #endregion
    }

    public class FavouriteObject
    {
        //_ObjectType
        private Type _ObjectList;

        public Type ObjectList
        {
            get
            {
                return _ObjectList;
            }

            set
            {
                _ObjectList = value;
            }
        }



    }
}
