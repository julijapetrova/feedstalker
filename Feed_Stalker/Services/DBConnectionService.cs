using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
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
        public Dictionary<string, SyndicationFeed> getAllFromDB()
        {
            MySqlConnection conn = Connect();
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT * FROM Feed");
                cmd.ExecuteNonQuery();

                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                Dictionary<string, SyndicationFeed> stringArray = new Dictionary<string, SyndicationFeed>();
                while (mySqlDataReader.Read())
                {
                    stringArray[mySqlDataReader.GetString(0)] = JsonConvert.DeserializeObject<SyndicationFeed>(mySqlDataReader.GetString(1));
                }
                conn.Close();
                return stringArray;
            }
        }

        public HttpResponseMessage saveFeed(string secretkey, string syndicationfeed)
        {
            MySqlConnection conn = Connect();
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO Feed(secret_key,syndication_feed) VALUES(@secret_key, @syndication_feed)";
                try
                {
                    cmd.Parameters.AddWithValue("@secret_key", secretkey);
                    cmd.Parameters.AddWithValue("@syndication_feed", syndicationfeed);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                catch (MySqlException ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }
        public SyndicationFeed GetFeed(string secretkey)
        {
            MySqlConnection conn = Connect();
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT * FROM Feed WHERE secret_key='@secret_key'");
                try
                {
                    cmd.Parameters.AddWithValue("@secret_key", secretkey);
                    cmd.ExecuteNonQuery();
                    string result = null;
                    MySqlDataReader mySqlDataReader = cmd.ExecuteReader();


                    while (mySqlDataReader.Read())
                    {
                        result = (string)mySqlDataReader[1];
                        Console.WriteLine(mySqlDataReader[0].ToString(), mySqlDataReader[1]);
                    }
                    conn.Close();

                    SyndicationFeed synfeed = new SyndicationFeed();
                    synfeed.Title = new TextSyndicationContent("Heyheyheyhey");
                    //JsonConvert.DeserializeObject<SyndicationFeed>(result);

                    return synfeed;



                }
                catch (MySqlException ex)
                {
                    conn.Close();
                    throw ex;
                }
            }

        }

    }
}