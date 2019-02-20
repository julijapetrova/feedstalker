using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Feed_Stalker.Services
{
    public class DBConnectionService
    {
        public DBConnectionService()
        {
        }
        public void Test()
        {

            //MySqlConnection con = new MySqlConnection();
            //string mysql = "server=mysql97.unoeuro.com;user id=julijapetrova_dk;persistsecurityinfo=True;database=julijapetrova_dk_db";
            //con.ConnectionString = mysql;
            //con.Open();

            //MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT * FROM FirstTable";
            //cmd.Connection = con;

            //MySqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    //Response.Write(reader.GetValue(0).ToString());
            //}

            //cmd.Dispose();
            //con.Close();




            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "mysql97.unoeuro.com";
            conn_string.UserID = "julijapetrova_dk";
            conn_string.Password = "12stuljev";
            conn_string.Database = "julijapetrova_dk_db";
            conn_string.Port = 3306;
            conn_string.PersistSecurityInfo = true;
            string n = conn_string.ToString();
            using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))

                try
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {    //watch out for this SQL injection vulnerability below
                        cmd.CommandText = string.Format("SELECT * FROM FirstTable");
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    
                }

            //MySqlConnection conn;
            //string myConnectionString;

            //myConnectionString = "Server=mysql97.unoeuro.com;Uid=julijapetrova_dk;" +
            //    "Pwd=12stuljev;Database=julijapetrova_dk_db";

            //try
            //{
            //    conn = new MySqlConnection();
            //    conn.ConnectionString = myConnectionString;
            //    conn.Open();
            //}
            //catch (MySqlException ex)
            //{

            //}
        }
    }
}