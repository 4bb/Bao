using System;
using System.Collections.Generic;
using System.Data;


namespace Shsict.Entity
{
    /// <summary>
    /// Truck 外集卡
    /// </summary>
    public class OTruck
    {
        public OTruck() { }

        public OTruck(DataRow dr)
        {
            InitTruck(dr);
        }

        private void InitTruck(DataRow dr)
        {
            if (dr != null)
            {
                ID =dr["ID"].ToString();
                TruckNo = dr["Container_Truck_Num"].ToString();

                if (!string.IsNullOrEmpty(dr["Arrive_Yard_Time"].ToString()))
                {
                    ArriveYardTime = DateTime.Parse(dr["Arrive_Yard_Time"].ToString());
                }
                else
                {
                    ArriveYardTime = null;
                }

                if (!string.IsNullOrEmpty(dr["Departure_Yard_Time"].ToString()))
                {
                    DepartureYardTime = DateTime.Parse(dr["Departure_Yard_Time"].ToString());
                }
                else
                {
                    DepartureYardTime = null;
                
                }
                IsActive = dr["is_active"].ToString();
                Remark = dr["Remark"].ToString();
                Fcontainer = dr["Fcontainer"].ToString();
                Acontainer = dr["Acontainer"].ToString();


            }
            else
            {
                throw new Exception("Unable to init Truck.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.OTruck.GetTruckByID(ID);

            if (dr != null)
            {
                InitTruck(dr);
            }
        }


        public static List<OTruck> GetTrucks()
        {
            DataTable dt = Shsict.DataAccess.OTruck.GetTrucks();
            List<OTruck> list = new List<OTruck>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OTruck(dr));
                }
            }

            return list;
        }
        public static List<OTruck> GetTrucks(string TruckNo)
        {
            DataTable dt = Shsict.DataAccess.OTruck.GetTrucksByNum(TruckNo);
            List<OTruck> list = new List<OTruck>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OTruck(dr));
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
                TruckList = GetTrucks();
                //TruckList_Active = TruckList.FindAll(delegate(OTruck t) { return true; });
            }
 
            public static OTruck Load(string tID)
            {
                return TruckList.Find(delegate(OTruck t) { return t.ID.Equals(tID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<OTruck> TruckList;
            //public static List<OTruck> TruckList_Active;
        }

        #region members and propertis

        public string ID { get; set; }

        public string TruckNo { get; set; }

        public DateTime? ArriveYardTime { get; set; }

        public DateTime? DepartureYardTime { get; set; }

        public string IsActive { get; set; }

        public string Remark { get; set; }

        public string Fcontainer { get; set; }

        public string Acontainer { get; set; }

        #endregion


    }

}
