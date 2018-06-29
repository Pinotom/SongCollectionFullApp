using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DB
    {
        public static SqlConnection ConnectToDB()
        {
            string connection = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            return new SqlConnection(connection);
        }
    }
}
