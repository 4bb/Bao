using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;
using System.Data.OracleClient;

/// <summary>
/// Truck 外集卡
/// </summary>

namespace Shsict.DataAccess
{
    public class Truck
    {
        public static DataRow GetTruckByID(int tID)
        {
            string sql = @"SELECT     ID, TruckNo, ArriveYardTime, DepartureYardTime, IsActive, Remark
                            FROM      Truck
                            WHERE     (ID = :tID)";


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

        public static void InsertTruck(int tID, string truckNo, DateTime arriveYardTime, DateTime departureYardTime, bool isActive, string remark)
        {
            string sql = @"INSERT INTO [Truck] 
                            (TruckNo, ArriveYardTime, DepartureYardTime,  IsActive, Remark) VALUES 
                            (@truckNo, @arriveYardTime, @departureYardTime, isActive, remark";

            SqlParameter[] para = { new SqlParameter(),
                                    new SqlParameter("@truckNo", truckNo), 
                                    new SqlParameter("@arriveYardTime", arriveYardTime), 
                                    new SqlParameter("@departureYardTime", departureYardTime), 
                                    new SqlParameter("@isActive", isActive), 
                                    new SqlParameter("@remark", remark)
                                 };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateTruck(int tID, string truckNo, DateTime arriveYardTime, DateTime departureYardTime, bool isActive, string remark)
        {
            string sql = @"UPDATE [Truck] SET TruckNo = @truckNo, ArriveYardTime = @arriveYardTime, DepartureYardTime=@departureYardTime, IsActive=@isActive, Remark=@remark WHERE ID = @tID";

            SqlParameter[] para = { new SqlParameter("@tID",tID),
                                    new SqlParameter("@truckNo", truckNo), 
                                    new SqlParameter("@arriveYardTime", arriveYardTime), 
                                    new SqlParameter("@departureYardTime", departureYardTime), 
                                    new SqlParameter("@isActive", isActive), 
                                    new SqlParameter("@remark", remark)
                                 };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteTruck(int tID)
        {
            string sql = "DELETE FROM [Truck] WHERE ID = @tID";

            SqlParameter[] para = { new SqlParameter("@ctID", tID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static DataTable GetTrucks()
        {
            string sql = @"SELECT ID, truckNo, ArriveYardTime, DepartureYardTime, IsActive, Remark
                           FROM [Truck] ORDER BY ID DESC";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql);

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
