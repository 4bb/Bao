using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 码头运抵报告
    /// </summary>
    public class ContainerEload
    {
        public static DataRow GetContainerEloadByID(string cntrID)
        {
            string sql = @"SELECT  cntrID, VesselName, VoyageNumber, BillOfLadingNum, ContainerNo, ArrivalContainerTime, SendPackingListTime
                           FROM  V_CONTAINER_ELOAD
                           WHERE (cntrID = :cntrID)";


            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("cntrID", cntrID);

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

        public static DataTable GetContainerEloads()
        {
            string sql = @"SELECT  cntrID, VesselName, VoyageNumber, BillOfLadingNum, ContainerNo, ArrivalContainerTime, SendPackingListTime
                           FROM  V_CONTAINER_ELOAD ";

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

        public static DataTable GetContainerEloadByContainerNo(string ContainerNo)
        {
            string sql = @"SELECT  cntrID, VesselName, VoyageNumber, BillOfLadingNum, ContainerNo, ArrivalContainerTime, SendPackingListTime
                           FROM  V_CONTAINER_ELOAD 
                           WHERE (ContainerNo = :ContainerNo) 
                           ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("ContainerNo", ContainerNo);

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
        public static DataTable GetContainerEloadByBillOfLadingNum(string BillOfLadingNum)
        {
            string sql = @"SELECT  cntrID, VesselName, VoyageNumber, BillOfLadingNum, ContainerNo, ArrivalContainerTime, SendPackingListTime
                           FROM  V_CONTAINER_ELOAD 
                           WHERE  cntrid in (select * from table(ssict_app_pak.STR2varlist(ssict_app_pak.Get_CntridByBillno(:BillOfLadingNum))))
                           ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("BillOfLadingNum", BillOfLadingNum);

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
