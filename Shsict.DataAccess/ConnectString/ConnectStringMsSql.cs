using System.Configuration;
using System.Data.SqlClient;

namespace Shsict.DataAccess
{
    public class ConnectStringMsSql
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Shsict.MsSql.ConnectionString"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
