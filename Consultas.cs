using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ConexionSQL01.Models;

namespace ConexionSQL01
{
    class Consultas
    {
        DataSet ds;
        DataTable dt;
        public DataSet RecuperaPeopleDS()
        {   
            using (SqlConnection sql = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DBSample"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spPeople1Select_All", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds = new DataSet());
                    return ds;
                }
            }
            
        }

        public DataSet RecuperaPeopleAndCity()
        {
            using (SqlConnection sql = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DBSample"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetPeopleAndCity", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds = new DataSet());
                }
            }
            return ds;
        }

        public DataTable RecuperarPeopleDT() {
            using (SqlConnection sql = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DBSample"].ConnectionString)) 
            {
                using (SqlCommand cmd = new SqlCommand("spPeople1Select_All", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt = new DataTable());
                }
            }

            return dt;
        }
    }
}
