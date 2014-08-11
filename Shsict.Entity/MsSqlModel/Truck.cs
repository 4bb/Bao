using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Truck 外集卡
/// </summary>
public class Truck
{
    public Truck() { }

    public Truck(DataRow dr)
    {
        InitTruck(dr);
    }

    private void InitTruck(DataRow dr)
    {
        if (dr != null)
        {
            ID = Convert.ToInt16(dr["ID"]);
            TruckNo = dr["TruckNo"].ToString();
            ArriveYardTime = DateTime.Parse(dr["ArriveYardTime"].ToString());
            DepartureYardTime = DateTime.Parse(dr["DepartureYardTime"].ToString());
            IsActive = bool.Parse(dr["IsActive"].ToString());
            Remark = dr["Remark"].ToString();
        }
        else
        {
            throw new Exception("Unable to init Truck.");
        }
    }

    public void Select()
    {
        DataRow dr = Shsict.DataAccess.Truck.GetTruckByID(ID);

        if (dr != null)
        {
            InitTruck(dr);
        }
    }

    public void Insert()
    {
        Shsict.DataAccess.Truck.InsertTruck(ID, TruckNo, ArriveYardTime, DepartureYardTime, IsActive, Remark);
    }

    public void Update()
    {
        Shsict.DataAccess.Truck.UpdateTruck(ID, TruckNo, ArriveYardTime, DepartureYardTime, IsActive, Remark);
    }

    public void Delete()
    {
        Shsict.DataAccess.Truck.DeleteTruck(ID);
    }

    public static List<Truck> GetTrucks()
    {
        DataTable dt = Shsict.DataAccess.Truck.GetTrucks();
        List<Truck> list = new List<Truck>();

        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Truck(dr));
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
            TruckList_Active = TruckList.FindAll(delegate(Truck t) { return t.IsActive; });
        }

        public static Truck Load(int tID)
        {
            return TruckList.Find(delegate(Truck t) { return t.ID.Equals(tID); });
            //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
        }

        public static List<Truck> TruckList;
        public static List<Truck> TruckList_Active;
    }

    #region members and propertis

    public int ID { get; set; }

    public string TruckNo { get; set; }

    public DateTime ArriveYardTime { get; set; }

    public DateTime DepartureYardTime { get; set; }

    public bool IsActive { get; set; }

    public string Remark { get; set; }

    #endregion







}