using ASPMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPMvc.Dal
{
    public class EventDal
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public int insertEvent(Event events)
        {
            try
            {
                string sql = "insert into event (name, startdate, endtdate, description) values('" + events.eventName + "', '" + events.startDate + "', '" + events.endDate + "', '" + events.description + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

           return 0;

        }

    }
}