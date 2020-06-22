using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebAppASP.Models;

namespace WebAppASP.CommunicateLayer
{
    public class Database
    {
        public MySqlConnection getConnection()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=catalin;pwd=1234cata;database=assets;";
            return new MySqlConnection(myConnectionString);

        }

        public int login(string user, string password)
        {

            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + user + "'and password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                int user_id = 0 ;
                while (myreader.Read())
                {
                    user_id = myreader.GetInt32("id");
                   
                }
                myreader.Close();
                return user_id;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return 0;
            }

      

        }


        public List<Asset> GetAssets()
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from assets";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Asset asset = new Asset();
                    asset.Id = myreader.GetInt32("id");
                    asset.UserID = myreader.GetInt32("userID");
                    asset.Name = myreader.GetString("name");
                    asset.Description = myreader.GetString("description");
                    asset.Value = myreader.GetInt32("value");
                    assets.Add(asset);
                }
                myreader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("here");
                Console.Write(ex.Message);
            }
            return assets;
        }

        public bool AddAsset(Asset asset)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = getConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO assets (userID,name,description,value) VALUES (\'" +
                asset.UserID + "\',\'" + asset.Name + "\',\'" + asset.Description + "\',\'" + asset.Value + "\');";
            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
            int cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt == 1;
        }
 



    }
}
