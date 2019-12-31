using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projectconventions.Models;

namespace project_conventions.Models
{
    public class UserContext
    {

        public User Save(User user)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("insert into users values(" +
                user.Apogee + "," +
                "'" + user.BirthDate + "'," +
                "'" + user.FirstName + "'," +
                "'" + user.LastName + "'," +
                "'" + user.Email + "'," +
                "'" + user.Filiere + "'," +
                "'" + user.Year + "'," +
                "'" + user.About + "'" +
                "'" + user.IsAdmin + "'" +
            ")", conn);

            var reader = cmd.ExecuteReader();

            conn.Close();

            return user;
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("select * from users", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User(
                    Convert.ToInt32(reader["Apogee"]),
                    reader["BirthDate"].ToString(),
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["Filiere"].ToString(),
                    reader["Year"].ToString(),
                    reader["About"].ToString(),
                    reader["IsAdmin"].ToString()
                ));
            }

            conn.Close();

            return list;
        }


        public User GetOneByApogee(int apogee)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users where Apogee=" + apogee, conn);

            var reader = cmd.ExecuteReader();

            User user = null;

            if (reader.Read())
            {
                user = new User(
                    Convert.ToInt32(reader["Apogee"]),
                    reader["BirthDate"].ToString(),
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["Filiere"].ToString(),
                    reader["Year"].ToString(),
                    reader["About"].ToString(),
                    reader["IsAdmin"].ToString()
                );
            }

            conn.Close();

            return user;
        }


        public User GetOneByApogeeAndBirthDate(int Apogee, string BirthDate)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users where Apogee=" + Apogee + " and BirthDate='" + BirthDate + "'", conn);

            var reader = cmd.ExecuteReader();

            User user = null;

            if (reader.Read())
            {
                user = new User(
                    Convert.ToInt32(reader["Apogee"]),
                    reader["BirthDate"].ToString(),
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["Filiere"].ToString(),
                    reader["Year"].ToString(),
                    reader["About"].ToString(),
                    reader["IsAdmin"].ToString()
                );
            }

            conn.Close();

            return user;
        }


        public User Update(User user)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("update users set" +
                "Apogee=" + user.Apogee + "," +
                "BirthDate=" + user.BirthDate + "," +
                "FirstName=" + user.FirstName + "," +
                "LastName=" + user.LastName + "," +
                "Email=" + user.Email + "," +
                "Filiere=" + user.Filiere + "," +
                "Year=" + user.Year + "," +
                "About=" + user.About +
                "IsAdmin=" + user.IsAdmin
            , conn);

            var reader = cmd.ExecuteReader();

            conn.Close();

            return user;
        }


        public void DeleteOneByApogee(int apogee)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("delete from users where Apogee=" + apogee, conn);

            var reader = cmd.ExecuteReader();
            conn.Close();
        }


    }
}
