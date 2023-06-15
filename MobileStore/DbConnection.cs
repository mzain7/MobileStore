
using System.Data.SqlClient;


namespace MobileStore
{
    public class DbConnection
    {
        public static string connectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True";

        public DbConnection()
        {
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
