using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// VesselPlan 船舶计划
/// </summary>
/// 
namespace Shsict.Entity
{
    public class VesselPlan
    {
        public VesselPlan() { }

        public VesselPlan(DataRow dr)
        {
            InitVesselPlan(dr);
        }

        private void InitVesselPlan(DataRow dr)
        {
            if (dr != null)
            {
                ID = Convert.ToInt16(dr["ID"]);
                VesselName = dr["VesselName"].ToString();
                VesselEnglishName = dr["VesselEnglishName"].ToString();
                VesselType = (VesselTypes)Enum.Parse(typeof(VesselTypes), dr["VesselType"].ToString());
                VoyageNumber = dr["VoyageNumber"].ToString();
                ImportOrExportFlag = dr["ImportOrExportFlag"].ToString();
                ArrivePlanTime = DateTime.Parse(dr["ArrivePlanTime"].ToString());

                if (!string.IsNullOrEmpty(dr["ArriveActualTime"].ToString()))
                {
                    ArriveActualTime = DateTime.Parse(dr["ArriveActualTime"].ToString());

                }
                else
                {
                    ArriveActualTime = null;
                }

                DeparturePlanTime = DateTime.Parse(dr["DeparturePlanTime"].ToString());

                if (!string.IsNullOrEmpty(dr["DepartureActualTime"].ToString()))
                {
                    DepartureActualTime = DateTime.Parse(dr["DepartureActualTime"].ToString());

                }
                else
                {
                    DepartureActualTime = null;
                }

                BerthPlan = dr["BerthPlan"].ToString();
                BerthActual = dr["BerthActual"].ToString();
                IsCustomsClosing = bool.Parse(dr["IsCustomsClosing"].ToString());
                Status = (VesselPlanStatus)Enum.Parse(typeof(VesselPlanStatus), dr["Status"].ToString());
                CSI = dr["CSI"].ToString();
                ContainerBeginTime = DateTime.Parse(dr["ContainerBeginTime"].ToString());
                ContainerDeadline = DateTime.Parse(dr["ContainerDeadline"].ToString());
                Agency = dr["Agency"].ToString();
                PortOfCallID = Convert.ToInt16(dr["PortOfCallID"]);
                IsActive = bool.Parse(dr["IsActive"].ToString());
                Remark = dr["Remark"].ToString();

                #region Generate Status Information && VesselType Information
                switch (Status)
                {
                    case VesselPlanStatus.InPort:
                        StatusInfo = "在港";
                        break;
                    case VesselPlanStatus.OutPort:
                        StatusInfo = "离泊";
                        break;
                    case VesselPlanStatus.InPlan:
                        StatusInfo = "计划";
                        break;
                    default:
                        StatusInfo = "其他";
                        break;
                }

                switch (VesselType)
                {
                    case VesselTypes.Vessel:
                        VesselTypeInfo = "大船";
                        break;
                    case VesselTypes.Barge:
                        VesselTypeInfo = "驳船";
                        break;
                    default:
                        VesselTypeInfo = "其他";
                        break;
                }
                #endregion

            }
            else
            {
                throw new Exception("Unable to init VesselPlan.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.VesselPlan.GetVesselPlanByID(ID);

            if (dr != null)
            {
                InitVesselPlan(dr);
            }
        }

        public void Insert()
        {
            Shsict.DataAccess.VesselPlan.InsertVesselPlan(ID, VesselName, VesselEnglishName, (int)VesselType, VoyageNumber, ImportOrExportFlag, ArrivePlanTime, ArriveActualTime, DeparturePlanTime, DepartureActualTime, BerthPlan, BerthActual, IsCustomsClosing, (int)Status, CSI, ContainerBeginTime, ContainerDeadline, Agency, PortOfCallID, IsActive, Remark);
        }

        public void Update()
        {
            Shsict.DataAccess.VesselPlan.UpdateVesselPlan(ID, VesselName, VesselEnglishName, (int)VesselType, VoyageNumber, ImportOrExportFlag, ArrivePlanTime, ArriveActualTime, DeparturePlanTime, DepartureActualTime, BerthPlan, BerthActual, IsCustomsClosing, (int)Status, CSI, ContainerBeginTime, ContainerDeadline, Agency, PortOfCallID, IsActive, Remark);
        }

        public void Delete()
        {
            Shsict.DataAccess.VesselPlan.DeleteVesselPlan(ID);
        }

        public static List<VesselPlan> GetVesselPlans()
        {
            DataTable dt = Shsict.DataAccess.VesselPlan.GetVesselPlans();
            List<VesselPlan> list = new List<VesselPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VesselPlan(dr));
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
                VesselPlanList = GetVesselPlans();
                VesselPlanList_Active = VesselPlanList.FindAll(delegate(VesselPlan vp) { return vp.IsActive; });
            }

            public static VesselPlan Load(int vpID)
            {
                return VesselPlanList.Find(delegate(VesselPlan vp) { return vp.ID.Equals(vpID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<VesselPlan> VesselPlanList;
            public static List<VesselPlan> VesselPlanList_Active;
        }

        #region members and propertis

        public int ID { get; set; }

        public string VesselName { get; set; }

        public string VesselEnglishName { get; set; }

        public VesselTypes VesselType { get; set; }

        public string VesselTypeInfo { get; set; }

        public string VoyageNumber { get; set; }

        public string ImportOrExportFlag { get; set; }

        public DateTime ArrivePlanTime { get; set; }

        public DateTime? ArriveActualTime { get; set; }

        public DateTime DeparturePlanTime { get; set; }

        public DateTime? DepartureActualTime { get; set; }
        
        public string BerthPlan { get; set; }

        public string BerthActual { get; set; }

        public bool IsCustomsClosing { get; set; }

        public VesselPlanStatus Status { get; set; }

        public string StatusInfo { get; set; }

        public string CSI { get; set; }

        public DateTime ContainerBeginTime { get; set; }

        public DateTime ContainerDeadline { get; set; }

        public string Agency { get; set; }

        public short PortOfCallID { get; set; }

        public bool IsActive { get; set; }

        public string Remark { get; set; }

        #endregion

        public enum VesselPlanStatus
        {
            InPort = 1,
            OutPort = 2,
            InPlan = 3,
            Null = 0
        }
        public enum VesselTypes
        {
            Vessel = 1,
            Barge = 2,
            Null = 0
        }
    }
}