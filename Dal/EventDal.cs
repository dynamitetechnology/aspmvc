using ASPMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public int deleteEvent(string id)
        {
            try
            {
                string sql = "delete from event  where id = '"+id+"'";
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return 0;
        }

        public List<Event> getEventList()
        {
            List<Event> employee = new List<Event>();
            try
            {
                
                    con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select id, name, startdate, endtdate, description from event", con))
                    {
                        cmd1.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                
                                foreach (DataRow dr in dt.Rows)
                                {
                                    Event comp = new Event();
                                    comp.id = Convert.ToInt32(dr[0].ToString());
                                    comp.eventName = dr[1].ToString();
                                    comp.startDate = dr[2].ToString();
                                    comp.endDate = dr[3].ToString();
                                    comp.description = dr[4].ToString();
                                    employee.Add(comp);
                                }
                            }
                        }
                    }
                    con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employee;
        }


        public List<Event> getEventById(string id)
        {
            List<Event> employee = new List<Event>();
            try
            {

                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, name, startdate, endtdate, description from event where id = '"+id+"'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Event comp = new Event();
                                comp.id = Convert.ToInt32(dr[0].ToString());
                                comp.eventName = dr[1].ToString();
                                comp.startDate = dr[2].ToString();
                                comp.endDate = dr[3].ToString();
                                comp.description = dr[4].ToString();
                                employee.Add(comp);
                            }
                        }
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employee;
        }

        public int updateEvent(Event events)
        {
            try
            {
                string sql = "update event set name = '" + events.eventName + "', startdate = '" + events.startDate + "', endtdate = '" + events.endDate + "', description = '" + events.description + "' where id = '"+events.id+"'";
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
            catch (Exception ex)
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