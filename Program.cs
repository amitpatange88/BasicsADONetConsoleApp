using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;

namespace BasicsADONetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                conn.Open();
                // ACID Property : Atomicity, Consistency, Integrity, Durability
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [EmployeeManagement].[dbo].[ACCOUNT] set AVAIL_BALANCE = AVAIL_BALANCE - 10 WHERE ACCOUNT_ID = 2", conn, tran);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE [EmployeeManagement].[dbo].[ACCOUNT] set AVAIL_BALANCE = AVAIL_BALANCE + 10 WHERE ACCOUNT_ID = 5", conn, tran);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Transcation Successful.");
                    Console.ReadLine();
                }
                catch(Exception e)
                {
                    tran.Rollback();
                    Console.WriteLine("Transcation Failed."+e.Message);
                    Console.ReadLine();
                }   
            }
        }
    }
}
