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
                SqlCommand cmd = new SqlCommand("select * from EMPLOYEE;select * from CUSTOMER;", conn);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    //BindtoFirstGriddatasource = rdr;

                    while(rdr.NextResult())
                    {
                        //BindtoSecondGriddatasource = rdr;
                    }
                }
                    
            }


            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from EMPLOYEE; select* from CUSTOMER;", conn1);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //bind to data source here somewhere
            }
        }
    }
}
