using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using MySql.Data.MySqlClient;

namespace Feed_Stalker.Services
{
    public class DBConnectionService
    {
        public DBConnectionService()
        {
        }
        public MySqlConnection Connect()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "mysql97.unoeuro.com";
            conn_string.UserID = "julijapetrova_dk";
            conn_string.Password = "12stuljev";
            conn_string.Database = "julijapetrova_dk_db";
            conn_string.Port = 3306;
            conn_string.PersistSecurityInfo = true;
            using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))

                try
                {
                    conn.Open();
                    return conn;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }


        }
        public List<string> getAllFromDB()
        {
            MySqlConnection conn = Connect();
            using (MySqlCommand cmd = conn.CreateCommand())
            {    //watch out for this SQL injection vulnerability below



                cmd.CommandText = string.Format("SELECT * FROM FirstTable");
                cmd.ExecuteNonQuery();
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                List<string> stringArray = new List<string>();
                while (mySqlDataReader.Read())
                {
                    stringArray.Add($"{mySqlDataReader.GetInt16(0)}-{mySqlDataReader.GetInt16(1)}");


                }
                return stringArray;
            }
        }

        public HttpResponseMessage saveFeed(string item1, string item2)
        {
            MySqlConnection conn = Connect();
            using (MySqlCommand cmd = conn.CreateCommand())
            {    //watch out for this SQL injection vulnerability below



                cmd.CommandText = string.Format($"INSERT INTO Feed(secret_key,syndication_feed) VALUES({item1},{item2})");
                try
                {
                    cmd.ExecuteNonQuery();
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }

            }
        }
    }
}