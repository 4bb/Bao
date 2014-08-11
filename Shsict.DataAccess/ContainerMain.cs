using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 箱子主表
    /// </summary>
    public class ContainerMain
    {
        public static DataRow GetContainerMainByID(string cID)
        {
            string sql = @"SELECT  ID, ContainerNo, BillOfLadingNum , IEFG ,ContainerStatus ,VesselName, VoyageNumber, ArriveTime,
                           DepartureTime, ArriveType, DepartureType, ArrivalContainerTime, CustomsClearanceTime,
                           StowageTime,  VesselTime, Arrivefg, Departurefg, CustomsClearance, Stowagefg, Vesselfg
                           FROM  v_container_main
                           WHERE (ID = :cID)";


            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("cID", cID);

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

        public static DataTable GetContainerMains()
        {
            string sql = @"SELECT  ID, ContainerNo, BillOfLadingNum , IEFG ,ContainerStatus ,VesselName, VoyageNumber, ArriveTime,
                           DepartureTime, ArriveType, DepartureType, ArrivalContainerTime, CustomsClearanceTime,
                           StowageTime,  VesselTime, Arrivefg, Departurefg, CustomsClearance, Stowagefg, Vesselfg
                            FROM      v_container_main  ";

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

        public static DataTable GetContainerMainByContainerNo(string ContainerNoOrbill)
        {
            string sql = @"SELECT  ID, ContainerNo, BillOfLadingNum , IEFG ,ContainerStatus ,VesselName, VoyageNumber, ArriveTime,
                           DepartureTime, ArriveType, DepartureType, ArrivalContainerTime, CustomsClearanceTime,
                           StowageTime,  VesselTime, Arrivefg, Departurefg, CustomsClearance, Stowagefg, Vesselfg
                            FROM      v_container_main  
                            WHERE (ContainerNo = :ContainerNoOrbill)  ";



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

        public static DataTable GetContainerMainByBillno(string Billno)
        {
            string sql = @"SELECT  ID, ContainerNo, BillOfLadingNum , IEFG ,ContainerStatus ,VesselName, VoyageNumber, ArriveTime,
                           DepartureTime, ArriveType, DepartureType, ArrivalContainerTime, CustomsClearanceTime,
                           StowageTime,  VesselTime, Arrivefg, Departurefg, CustomsClearance, Stowagefg, Vesselfg
                            FROM      v_container_main  
                            WHERE ID IN  (SELECT * FROM TABLE(ssict_app_pak.STR2varlist(ssict_app_pak.Get_CntridByBillno(:Billno))) )  ";



            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("Billno", Billno);

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
