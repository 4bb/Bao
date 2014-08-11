using System.Configuration;

namespace Shsict.DataAccess
{
    public class ConnectStringOracle
    {
        public static string GetViewConnection()
        {
            return ConfigurationManager.ConnectionStrings["Shsict.Oracle.View.ConnectionString"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["Shsict.Oracle.View.ConnectionString"].ConnectionString;
        }
        public static string GetTableConnection()
        {
            return ConfigurationManager.ConnectionStrings["Shsict.Oracle.Table.ConnectionString"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["Shsict.Oracle.Table.ConnectionString"].ConnectionString;
        }
        public static string GetInternalTableConnection()
        {
            return ConfigurationManager.ConnectionStrings["ShsictInternal.Oracle.Table.ConnectionString.Shsict"].ConnectionString;
        }
    }
}
