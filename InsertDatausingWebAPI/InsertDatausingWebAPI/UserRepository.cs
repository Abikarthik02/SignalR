using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace InsertDatausingWebAPI
{
    internal class UserRepository
    {

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TestDBConnection"].ToString();
            con = new SqlConnection(constr);


        }

        public string RegisterUsers(User User)
        {
            connection();
            con.Open();
            com = new SqlCommand("InsertData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FName", User.FirstName);
            com.Parameters.AddWithValue("@Lname", User.LastName);
            com.Parameters.AddWithValue("@Addr", User.Address);
            
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "User Data Saved Successfully";

            }
            else
            {
                return "User Data failed to Save";

            }
        }
    }
}