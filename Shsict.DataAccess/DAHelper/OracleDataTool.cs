using System;
using System.Data;
using System.Data.OracleClient;

namespace Microsoft.ApplicationBlocks.Data
{
    public class OracleDataTool
    {

        public static int ExecuteNonQuery(string connection, string strSQL, OracleParameter[] commandParameters)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, commandParameters);
            return ExecuteNonQuery(connection, myCommand);
        }

        public static DataTable ExecuteDataTable(string connection, String strSQL, OracleParameter[] commandParameters)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, commandParameters);
            return ExecuteDataTable(connection, myCommand);
        }

        public static DataSet ExecuteDataset(string connection, string strSQL, OracleParameter[] commandParameters)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, commandParameters);
            return ExecuteDataset(connection, myCommand);
        }

        public static DataSet ExecuteDataset(string connection, string strSQL, OracleParameter commandParameter)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, commandParameter);
            return ExecuteDataset(connection, myCommand);
        }

        public static DataSet ExecuteDataset(string connection, string strSQL)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, (OracleParameter[])null);
            return ExecuteDataset(connection, myCommand);
        }

        public static int ExecuteCount(string connection, string strSQL, OracleParameter[] commandParameters)
        {
            OracleCommand myCommand = getNewSQLCommand(strSQL, commandParameters);
            return ExecuteCount(connection, myCommand);
        }

        public static int ExecuteNonQuery(string connection, OracleCommand sqlcmd)
        {
            int resulState = -1;
            OracleConnection myConn = OracleDataHelper.getConnectionByPool(connection);
            OracleTransaction myTrans;
            myTrans = myConn.BeginTransaction(IsolationLevel.ReadCommitted);
            sqlcmd.Connection = myConn;
            sqlcmd.Transaction = myTrans;
            try
            {
                resulState = sqlcmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                throw e;
            }
            finally
            {
                try
                {
                    OracleDataHelper.freeConnectionToPool(myConn,connection);
                }
                catch (Exception err)
                {
                    throw err;
                }
            }

            return resulState;
        }

        public static DataSet ExecuteDataset(string connection, OracleCommand sqlcmd)
        {
            DataSet dataSet = new DataSet();
            OracleConnection conn = OracleDataHelper.getConnectionByPool(connection);
            try
            {

                OracleDataAdapter myDbDA;
                myDbDA = new OracleDataAdapter();
                myDbDA.SelectCommand = sqlcmd;
                sqlcmd.Connection = conn;
                myDbDA.Fill(dataSet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                try
                {
                    OracleDataHelper.freeConnectionToPool(conn, connection);
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);

                }

            }
            return dataSet;
        }

        public static DataTable ExecuteDataTable(string connection, OracleCommand sqlcmd)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = OracleDataHelper.getConnectionByPool(connection);
            try
            {

                OracleDataAdapter myDbDA;
                myDbDA = new OracleDataAdapter();
                myDbDA.SelectCommand = sqlcmd;
                sqlcmd.Connection = conn;
                myDbDA.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                try
                {
                    OracleDataHelper.freeConnectionToPool(conn, connection);
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);

                }

            }
            return dt;
        }

        public static int ExecuteCount(string connection, OracleCommand sqlcmd)
        {
            DataSet dataSet = new DataSet();
            OracleConnection conn = OracleDataHelper.getConnectionByPool(connection);
            try
            {

                OracleDataAdapter myDbDA;
                myDbDA = new OracleDataAdapter();
                myDbDA.SelectCommand = sqlcmd;
                sqlcmd.Connection = conn;
                myDbDA.Fill(dataSet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                try
                {
                    OracleDataHelper.freeConnectionToPool(conn, connection);
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);

                }

            }
            return dataSet.Tables[0].Rows.Count;
        }

        private static OracleCommand getNewSQLCommand(string strSQL, OracleParameter[] commandParameters)
        {
            OracleCommand myCommand = new OracleCommand();
            myCommand.CommandText = strSQL;
            if (commandParameters != null && commandParameters.Length > 0)
            {
                foreach (OracleParameter para in commandParameters)

                    myCommand.Parameters.Add(para);
            }
            return myCommand;
        }

        private static OracleCommand getNewSQLCommand(string strSQL, OracleParameter commandParameter)
        {
            OracleCommand myCommand = new OracleCommand();
            myCommand.CommandText = strSQL;
            if (commandParameter != null)
            {
                myCommand.Parameters.Add(commandParameter);
            }
            return myCommand;
        }

    }
}
