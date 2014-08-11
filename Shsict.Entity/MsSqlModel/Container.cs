using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Container 集装箱有关信息
/// </summary>
public class Container
{
    public Container() { }

    public Container(DataRow dr)
    {
        InitContainer(dr);
    }

    private void InitContainer(DataRow dr)
    {
        if (dr != null)
        {
            ID = Convert.ToInt16(dr["ID"]);
            ContainerNo = dr["ContainerNo"].ToString();
            ArriveTime = DateTime.Parse(dr["ArriveTime"].ToString());
            DepartureTime = DateTime.Parse(dr["DepartureTime"].ToString());
            ArriveType = dr["ArriveType"].ToString();
            DepartureType = dr["DepartureType"].ToString();
            CustomsClearance = dr["CustomsClearance"].ToString();
            VesselID = Convert.ToInt16(dr["VesselID"]);
            ArrivalContainerTime = DateTime.Parse(dr["ArrivalContainerTime"].ToString());
            CustomsClearanceTime = DateTime.Parse(dr["CustomsClearanceTime"].ToString());
            StowageTime = DateTime.Parse(dr["StowageTime"].ToString());
            VesselTime = DateTime.Parse(dr["VesselTime"].ToString());
            PlanTime = DateTime.Parse(dr["PlanTime"].ToString());
            PlanAcceptedTime = DateTime.Parse(dr["PlanAcceptedTime"].ToString());
            VesselName = dr["VesselName"].ToString();
            VoyageNumber = dr["VoyageNumber"].ToString();
            BillOfLadingNum = dr["BillOfLadingNum"].ToString();
            ArrivalPortTime = DateTime.Parse(dr["ArrivalPortTime"].ToString());
            SendPackingListTime = DateTime.Parse(dr["SendPackingListTime"].ToString());
            PlanAarrangeTime = DateTime.Parse(dr["PlanAarrangeTime"].ToString());
            AcceptanceNo = dr["AcceptanceNo"].ToString();
            IsActive = bool.Parse(dr["IsActive"].ToString());
            Remark = dr["Remark"].ToString();
        }
        else
        {
            throw new Exception("Unable to init Container.");
        }
    }

    public void Select()
    {
        DataRow dr = Shsict.DataAccess.Container.GetContainerByID(ID);

        if (dr != null)
        {
            InitContainer(dr);
        }
    }

    public void Insert()
    {
        Shsict.DataAccess.Container.InsertContainer(ID, ContainerNo, ArriveTime, DepartureTime, ArriveType, DepartureType, CustomsClearance, VesselID, ArrivalContainerTime, CustomsClearanceTime, StowageTime, VesselTime, PlanTime, PlanAcceptedTime, VesselName, VoyageNumber, BillOfLadingNum, ArrivalPortTime, SendPackingListTime, PlanAarrangeTime, AcceptanceNo, IsActive, Remark);
    }

    public void Update()
    {
        Shsict.DataAccess.Container.UpdateContainer(ID, ContainerNo, ArriveTime, DepartureTime, ArriveType, DepartureType, CustomsClearance, VesselID, ArrivalContainerTime, CustomsClearanceTime, StowageTime, VesselTime, PlanTime, PlanAcceptedTime, VesselName, VoyageNumber, BillOfLadingNum, ArrivalPortTime, SendPackingListTime, PlanAarrangeTime, AcceptanceNo, IsActive, Remark);
    }

    public void Delete()
    {
        Shsict.DataAccess.Container.DeleteContainer(ID);
    }

    public static List<Container> GetContainers()
    {
        DataTable dt = Shsict.DataAccess.Container.GetContainers();
        List<Container> list = new List<Container>();

        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Container(dr));
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
            ContainerList = GetContainers();
            ContainerList_Active = ContainerList.FindAll(delegate(Container c) { return c.IsActive; });
        }

        public static Container Load(int csmID)
        {
            return ContainerList.Find(delegate(Container csm) { return csm.ID.Equals(csmID); });
            //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
        }

        public static List<Container> ContainerList;
        public static List<Container> ContainerList_Active;
    }

    #region members and propertis

    public int ID { get; set; }

    public string ContainerNo { get; set; }

    public DateTime ArriveTime { get; set; }

    public DateTime DepartureTime { get; set; }

    public string ArriveType { get; set; }

    public string DepartureType { get; set; }

    public string CustomsClearance { get; set; }

    public int VesselID { get; set; }

    public DateTime ArrivalContainerTime { get; set; }

    public DateTime CustomsClearanceTime { get; set; }

    public DateTime StowageTime { get; set; }

    public DateTime VesselTime { get; set; }

    public DateTime PlanTime { get; set; }

    public DateTime PlanAcceptedTime { get; set; }

    public string VesselName { get; set; }

    public string VoyageNumber { get; set; }

    public string BillOfLadingNum { get; set; }

    public DateTime ArrivalPortTime { get; set; }

    public DateTime SendPackingListTime { get; set; }

    public DateTime PlanAarrangeTime { get; set; }

    public string AcceptanceNo { get; set; }

    public bool IsActive { get; set; }

    public string Remark { get; set; }

    #endregion

}