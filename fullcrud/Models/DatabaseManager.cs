using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace fullcrud.Models
{
    public class DatabaseManager
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-1759H6O\\SQLEXPRESS; Initial Catalog=test;Integrated Security=true");

        public bool insert_update_delete(string command)   //method
        {
            SqlCommand cmd = new SqlCommand(command, con);  //command
            if (con.State == ConnectionState.Closed)        //check connection
            {
                con.Open();                                    //open connnection
            }
            int n = cmd.ExecuteNonQuery();                  //Execute Query
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataTable display_all_record(string command) //method
        {
            SqlDataAdapter sa = new SqlDataAdapter(command, con);//create a object of sqlDA
            DataTable dt = new DataTable();                         //create a object of datatable
            sa.Fill(dt);
            return dt;
        }
    }
}