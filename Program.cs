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
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from EMPLOYEE", conn);
                conn.Open();
                SqlDataReader rows = cmd.ExecuteReader();
            }
        }
    }
}
