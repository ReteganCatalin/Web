using Lab8.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Communication_Layer
{
    public class CommunicationLayer
    {
        public MySqlConnection getConnection()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=catalin;pwd=1234cata;database=multimediaasp;";
            return new MySqlConnection(myConnectionString);

        }

        public bool login(string user, string password)
        {

            List<String> users = new List<String>();

            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + user + "'and password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    users.Add(myreader.GetString("username"));
                }
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            return users.Count == 1;

        }

        public List<string> GetAllFormats()
        {
            List<string> formats = new List<string>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select distinct media.format from media" ;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    formats.Add(myreader.GetString("format"));
                    System.Diagnostics.Debug.WriteLine(myreader.GetString("format"));
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return formats;
        }

        public List<string> GetAllGenres()
        {
            List<string> genres = new List<string>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select distinct media.genre from media";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    genres.Add(myreader.GetString("genre"));
                    System.Diagnostics.Debug.WriteLine(myreader.GetString("genre"));
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return genres;
        }


        public List<File> GetAllFilesWithGenre(string genre)
        {
            List<File> files = new List<File>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from  media where media.genre='" + genre + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                string new_genre = myreader.GetString("genre");
                string location = myreader.GetString("location");
                string title = myreader.GetString("title");
                string format = myreader.GetString("format");
                int id = myreader.GetInt32("media_id");
                File file = new File();
                file.Id = id;file.Format = format;file.Location = location;file.Title = title;file.Genre = new_genre;
                files.Add(file);
                    System.Diagnostics.Debug.WriteLine(file);
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return files;
        }

        public List<File> GetAllFilesWithFormat(string format)
        {
            List<File> files = new List<File>();
            try
            {
                MySqlConnection conn = getConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from  media where media.format='" + format + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string genre = myreader.GetString("genre");
                    string location = myreader.GetString("location");
                    string title = myreader.GetString("title");
                    string new_format = myreader.GetString("format");
                    int id = myreader.GetInt32("media_id");
                    File file = new File();
                    file.Id = id; file.Format = new_format; file.Location = location; file.Title = title; file.Genre = genre;
                    files.Add(file);
                    System.Diagnostics.Debug.WriteLine(file);
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return files;
        }

        public List<File> GetFiles()
        {
                List<File> files = new List<File>();
                try
                {
                    MySqlConnection conn = getConnection();
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from media";
                    MySqlDataReader myreader = cmd.ExecuteReader();

                    while (myreader.Read())
                    {
                        File file = new File();
                        file.Id = myreader.GetInt32("media_id");
                        file.Genre = myreader.GetString("genre");
                        file.Format = myreader.GetString("format");
                        file.Location = myreader.GetString("location");
                        file.Title = myreader.GetString("title");
                        files.Add(file);
                    }
                    myreader.Close();

                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("here");
                    Console.Write(ex.Message);
                }
                return files;
        }

        public bool AddFile(File file)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = getConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO media (format,genre,location,title) VALUES (\'" +
                file.Format + "\',\'" + file.Genre + "\',\'" + file.Location + "\',\'" + file.Title + "\');";
            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
            int cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt == 1;
        }
        public bool UpdateFile(File file)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = getConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE media SET title = '" + file.Title +"', format = '"+ file.Format +"',genre = '"+file.Genre+"', location = '"+file.Location+"' WHERE media_id = "+file.Id+"; " ;
            int cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt == 1;
        }

        public bool DeleteFile(int id)
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = getConnection();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM media WHERE media_id=" + id;
                System.Diagnostics.Debug.WriteLine(cmd.CommandText);
                int cnt = cmd.ExecuteNonQuery();
                conn.Close();
                return cnt == 1;
            }

           
        
    }
}