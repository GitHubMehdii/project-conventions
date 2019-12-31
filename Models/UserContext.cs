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
            try {
                conn.Open();

                string sqlCommand = "insert into users values(" +
                    user.Apogee + "," +
                    "'" + user.BirthDate + "'," +
                    "'" + user.FirstName + "'," +
                    "'" + user.LastName + "'," +
                    "'" + user.Email + "'," +
                    "'" + user.Filiere + "'," +
                    "'" + user.Year + "'," +
                    "'" + user.About + "'," +
                    "'" + user.IsAdmin + "'" +
                ")";

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
            return user;
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            MySqlConnection conn = DB.GetConnection();

            try {
                conn.Open();

                string sqlCommand = "select * from users where isAdmin = 'no'";

                Console.WriteLine(sqlCommand);

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

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

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
            return list;
        }


        public User GetOneByApogee(int apogee)
        {
            MySqlConnection conn = DB.GetConnection();

            User user = null;

            try
            {
                conn.Open();

                string sqlCommand = "select * from users where Apogee=" + apogee;

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

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

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }
            return user;
        }


        public User GetOneByApogeeAndBirthDate(int Apogee, string BirthDate)
        {
            MySqlConnection conn = DB.GetConnection();

            User user = null;

            try
            {
                conn.Open();

                string sqlCommand = "select * from users where Apogee=" + Apogee + " and BirthDate='" + BirthDate + "'";

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

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
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public User GetOneByEmailAndBirthDate(string Email, string BirthDate)
        {
            MySqlConnection conn = DB.GetConnection();

            User user = null;

            try
            {
                conn.Open();

                string sqlCommand = "select * from users where email='" + Email + "' and BirthDate='" + BirthDate + "' and IsAdmin='yes'";

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

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
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

            return user;
        }


        public User Update(User user)
        {
            MySqlConnection conn = DB.GetConnection();

            try {
                conn.Open();

                string sqlCommand = "update users set " +
                    "BirthDate='" + user.BirthDate + "', " +
                    "FirstName='" + user.FirstName + "', " +
                    "LastName='" + user.LastName + "', " +
                    "Email='" + user.Email + "', " +
                    "Filiere='" + user.Filiere + "', " +
                    "Year='" + user.Year + "', " +
                    "About='" + user.About + "', " +
                    "IsAdmin='" + user.IsAdmin + "' " +
                    "where Apogee=" + user.Apogee;

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

            return user;
        }


        public void DeleteOneByApogee(int apogee)
        {
            MySqlConnection conn = DB.GetConnection();

            try {
                conn.Open();

                string sqlCommand = "delete from users where Apogee=" + apogee;

                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                var reader = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                conn.Close();
            }

        }


    }
}
