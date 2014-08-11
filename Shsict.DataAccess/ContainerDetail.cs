using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 箱子详细
    /// </summary>
    public class ContainerDetail
    {
        public static DataRow GetContainerDetailByID(string ID)
        {
            string sql = @"SELECT     ID, ContainerNo, CTNSize, CTNType, CTNHeight, CTNStat, SealNO, BLNO, CTNOwner, CTNNetWeight, 
                           RCTemerature, DGType, DGUNNO, CTNIOType, PlanWorkTime, ArriveTime, DepartureTime, ArriveType, DepartureType, 
                           TCTNEmpty ,RCTNEmpty, FirstVVessel, FirstVVoyage, SecondVVessel, SecondVVoyage, LoadingPort, DischargingPort,
                           DestinationPort, CustomsClearance, Stowagefg, CTNYardSlot, OverCTNType, OverWeight, OverHeight, FOL, BOL, LOW, 
                           RoWidth, IsTurnCTN, IsDamaged ,ArriveISLate
                           FROM  V_CONTAINER_DETAIL
                           WHERE (ID = :ID)";


            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("ID", ID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetContainerDetails()
        {
            string sql = @"SELECT  ID, ContainerNo, CTNSize, CTNType, CTNHeight, CTNStat, SealNO, BLNO, CTNOwner, CTNNetWeight, 
                           RCTemerature, DGType, DGUNNO, CTNIOType, PlanWorkTime, ArriveTime, DepartureTime, ArriveType, DepartureType, 
                           TCTNEmpty ,RCTNEmpty, FirstVVessel, FirstVVoyage, SecondVVessel, SecondVVoyage, LoadingPort, DischargingPort,
                           DestinationPort, CustomsClearance, Stowagefg, CTNYardSlot, OverCTNType, OverWeight, OverHeight, FOL, BOL, LOW, 
                           RoWidth, IsTurnCTN,  IsDamaged ,ArriveISLate
                           FROM      V_CONTAINER_DETAIL  ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetContainerDetailByNum(string ContainerNoOrbill)
        {
            string sql = @"SELECT  ID, ContainerNo, CTNSize, CTNType, CTNHeight, CTNStat, SealNO, BLNO, CTNOwner, CTNNetWeight, 
                           RCTemerature, DGType, DGUNNO, CTNIOType, PlanWorkTime, ArriveTime, DepartureTime, ArriveType, DepartureType, 
                           TCTNEmpty ,RCTNEmpty, FirstVVessel, FirstVVoyage, SecondVVessel, SecondVVoyage, LoadingPort, DischargingPort,
                           DestinationPort, CustomsClearance, Stowagefg, CTNYardSlot, OverCTNType, OverWeight, OverHeight, FOL, BOL, LOW, 
                           RoWidth, IsTurnCTN,  IsDamaged ,ArriveISLate
                           FROM      V_CONTAINER_DETAIL 
                           WHERE (ContainerNo = :ContainerNoOrbill) ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("ContainerNoOrbill", ContainerNoOrbill);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql, para);



            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetContainerDetailByBLNO(string BLNO)
        {
            string sql = @"SELECT  ID, ContainerNo, CTNSize, CTNType, CTNHeight, CTNStat, SealNO, BLNO, CTNOwner, CTNNetWeight, 
                           RCTemerature, DGType, DGUNNO, CTNIOType, PlanWorkTime, ArriveTime, DepartureTime, ArriveType, DepartureType, 
                           TCTNEmpty ,RCTNEmpty, FirstVVessel, FirstVVoyage, SecondVVessel, SecondVVoyage, LoadingPort, DischargingPort,
                           DestinationPort, CustomsClearance, Stowagefg, CTNYardSlot, OverCTNType, OverWeight, OverHeight, FOL, BOL, LOW, 
                           RoWidth, IsTurnCTN,  IsDamaged ,ArriveISLate
                           FROM      V_CONTAINER_DETAIL 
                           WHERE (BLNO = :BLNO) ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("BLNO", BLNO);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

    }
}
