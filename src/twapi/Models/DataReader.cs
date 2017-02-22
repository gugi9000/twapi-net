using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace twapi.Models
{
    public class DataReader
    {
        public static void GetEmployees()
        {
            // 1. Instantiate the connection
            SqlConnection conn = new SqlConnection(
                "Data Source=tcp:localhost\\SQLEXPRESS;Initial Catalog=RIS;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select Sum(ServiceCaseTime.TimeUsed) as Total, SUBSTRING(Customer.Name, 1, 21) AS Kunde from[ServiceCaseTime] join[ServiceCase] on(ServiceCaseTime.ServiceCaseId = ServiceCase.Id) join[Customer] on(ServiceCase.CustomerId = Customer.Id) where[Done] > '2017-02-01' GROUP BY SUBSTRING(Customer.Name, 1, 21) Order By Total DESC", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
