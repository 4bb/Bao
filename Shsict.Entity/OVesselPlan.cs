using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.Entity
{
    /// <summary>
    /// VesselPlan 船舶计划
    /// </summary>
    /// 
    public class OVesselPlan
    {

        public OVesselPlan() { }

        public OVesselPlan(DataRow dr)
        {
            InitVesselPlan(dr);
        }

        private void InitVesselPlan(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                VesselName = dr["VESSEL_NAME"].ToString();
                VesselEnglishName = dr["VESSEL_ENGLISH_NAME"].ToString();
                VesselTypeInfo = dr["VESSEL_TYPE"].ToString();
                //VesselType = (VesselTypes)Enum.Parse(typeof(VesselTypes), dr["VESSEL_TYPE"].ToString());
                VoyageNumber = dr["VOYAGE_NUMBER"].ToString();
                ImportOrExportFlag = dr["Import_Or_Export_Flag"].ToString();

                ArrivePlanTime = DateTime.Parse(dr["ARRIVE_PLAN_TIME"].ToString());

                if (!string.IsNullOrEmpty(dr["ARRIVE_ACTUAL_TIME"].ToString()))
                {
                    ArriveActualTime = DateTime.Parse(dr["ARRIVE_ACTUAL_TIME"].ToString());
                }
                else
                {
                    ArriveActualTime = null;
                }

                DeparturePlanTime = DateTime.Parse(dr["DEPARTURE_PLAN_TIME"].ToString());

                if (!string.IsNullOrEmpty(dr["DEPARTURE_ACTUAL_TIME"].ToString()))
                {
                    DepartureActualTime = DateTime.Parse(dr["DEPARTURE_ACTUAL_TIME"].ToString());

                }
                else
                {
                    DepartureActualTime = null;
                }

                BerthPlan = dr["BERTH_PLAN"].ToString();
                BerthActual = dr["BERTH_ACTUAL"].ToString();
                IsCustomsClosing = dr["IS_CUSTOMS_CLOSING"].ToString();

                VesselPlanStatus = dr["STATUS"].ToString();
                if (VesselPlanStatus == "预报" || VesselPlanStatus == "确报")
                {
                    VesselPlanStatus = "计划";
                }
                //Status = (VesselPlanStatus)Enum.Parse(typeof(VesselPlanStatus), dr["STATUS"].ToString());

                CSI = dr["CSI"].ToString();

                if (!string.IsNullOrEmpty(dr["CONTAINER_BEGIN_TIME"].ToString()))
                {
                    ContainerBeginTime = DateTime.Parse(dr["CONTAINER_BEGIN_TIME"].ToString());
                }
                else
                {
                    ContainerBeginTime = null;
                }

                if (!string.IsNullOrEmpty(dr["Container_Deadline"].ToString()))
                {
                    ContainerDeadline = DateTime.Parse(dr["Container_Deadline"].ToString());
                }
                else
                {
                    ContainerBeginTime = null;
                }

                Agency = dr["Agency"].ToString();
                PortOfCallID = Convert.ToInt32(dr["Port_Of_Call_ID"]);
                IsActive = dr["Is_Active"].ToString();
                Remark = dr["Remark"].ToString();

                #region Generate Status Information && Enum VesselType
                switch (VesselPlanStatus)
                {
                    case "在港":
                        Status = "I";
                        break;
                    case "离港":
                        Status = "O";
                        break;
                    case "离泊":
                        Status = "O";
                        break;
                    case "计划":
                        Status = "P";
                        break;
                    default:
                        Status = "";
                        break;
                }

                switch (VesselTypeInfo)
                {
                    case "大船":
                        VesselType = "D";
                        break;
                    case "驳船":
                        VesselType = "B";
                        break;
                    case "杂货船":
                        VesselType = "Z";
                        break;
                    default:
                        VesselType = "";
                        break;
                }
                #endregion


                #region ContainerStatus

                string _ContainerBeginTime = ContainerBeginTime.ToString();
                string _ContainerDeadline = ContainerDeadline.ToString();

                DateTime dateTime = DateTime.Now.ToLocalTime();

                if (!string.IsNullOrEmpty(_ContainerBeginTime) && !string.IsNullOrEmpty(_ContainerDeadline))
                {
                    if (DateTime.Parse(_ContainerBeginTime) > dateTime)
                    {
                        ContainerStatus = "W";
                    }
                    else if (DateTime.Parse(_ContainerBeginTime) < dateTime && DateTime.Parse(_ContainerDeadline) > dateTime)
                    {
                        ContainerStatus = "G";
                    }
                    else
                    {
                        ContainerStatus = "N";
                    }
                }
                else
                {
                    ContainerStatus = "N";
                
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
            DataRow dr = Shsict.DataAccess.OVesselPlan.GetVesselPlanByID(ID);

            if (dr != null)
            {
                InitVesselPlan(dr);
            }
        }

        protected static List<OVesselPlan> GetVesselPlans()
        {
            DataTable dt = Shsict.DataAccess.OVesselPlan.GetVesselPlans();
            List<OVesselPlan> list = new List<OVesselPlan>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OVesselPlan(dr));
                }
            }

            return list;
        }

        //public static List<OVesselPlan> GetVesselPlans(DateTime dateStart, DateTime dateEnd)
        //{
        //    DataTable dt = Shsict.DataAccess.OVesselPlan.GetVesselPlans(dateStart, dateEnd);
        //    List<OVesselPlan> list = new List<OVesselPlan>();

        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(new OVesselPlan(dr));
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
                VesselPlanList = GetVesselPlans();
            }

            public static OVesselPlan Load(string vpID)
            {
                return VesselPlanList.Find(delegate(OVesselPlan vp) { return vp.ID.Equals(vpID); });
                //return VesselPlansList.Find(vp => vp.ID.Equals(vpID));
            }

            public static List<OVesselPlan> VesselPlanList;
        }

        #region members and propertis

        public string ID { get; set; }

        public string VesselName { get; set; }

        public string VesselEnglishName { get; set; }

        public string VesselType { get; set; }

        public string VesselTypeInfo { get; set; }

        public string VoyageNumber { get; set; }

        public string ImportOrExportFlag { get; set; }

        public DateTime ArrivePlanTime { get; set; }

        public DateTime? ArriveActualTime { get; set; }

        public DateTime DeparturePlanTime { get; set; }

        public DateTime? DepartureActualTime { get; set; }

        public string BerthPlan { get; set; }

        public string BerthActual { get; set; }

        public string IsCustomsClosing { get; set; }

        public string Status { get; set; }

        public string VesselPlanStatus { get; set; }

        //public VesselPlanStatus Status { get; set; }

        public string CSI { get; set; }

        public DateTime? ContainerBeginTime { get; set; }

        public DateTime? ContainerDeadline { get; set; }

        public string Agency { get; set; }

        public int PortOfCallID { get; set; }

        public string IsActive { get; set; }

        public string Remark { get; set; }


        public string ContainerStatus { get; set; }

        #endregion

    }
}