using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// Truck 外集卡
    /// </summary>
    public class OTruck
    {

        public static DataRow GetTruckByID(string tID)
        {
            string sql = @"SELECT ID, Container_Truck_Num, Arrive_Yard_Time, Departure_Yard_Time, is_active, Remark ,Fcontainer ,Acontainer
                            FROM v_truck WHERE (ID = :tID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("tID", tID);

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

        public static DataTable GetTrucks()
        {
            string sql = @"SELECT  ID, Container_Truck_Num, Arrive_Yard_Time, Departure_Yard_Time, is_active, Remark ,Fcontainer ,Acontainer
                            FROM      v_truck ";

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

        public static DataTable GetTrucksByNum(string truckNo)
        {
            string sql = @"SELECT  ID, Container_Truck_Num, Arrive_Yard_Time, Departure_Yard_Time, is_active, Remark ,Fcontainer ,Acontainer
                            FROM      v_truck Where  Container_Truck_Num = :truckNo";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("truckNo", truckNo);

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
