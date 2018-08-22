using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace BasicsADONetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) as TotalRows from EMPLOYEE", conn);
                conn.Open();
                int rows = (int)cmd.ExecuteScalar();
            }
        }
    }
}
