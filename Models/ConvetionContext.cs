using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projectconventions.Models;

namespace project_conventions.Models
{
    public class ConventionContext
    {

        public Convention Save(Convention convention)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "insert into conventions values(" +
                "'" + convention.Apogee + "'," +
                "'" + convention.StartDate + "'," +
                "'" + convention.EndDate + "'," +
                "'" + convention.CompanyName + "'" +
                "'" + convention.City + "'" +
                "'" + convention.Comments + "'" +
                "'" + convention.Status + "'" +
            ")";

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();

            conn.Close();

            return convention;
        }

        public List<Convention> GetAll()
        {
            List<Convention> list = new List<Convention>();

            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "select * from conventions";

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Convention(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["Apogee"].ToString()),
                    reader["StartDate"].ToString(),
                    reader["EndDate"].ToString(),
                    reader["CompanyName"].ToString(),
                    reader["City"].ToString(),
                    reader["Comments"].ToString(),
                    reader["Status"].ToString()
                ));
            }

            conn.Close();

            return list;
        }



        public List<Convention> GetAllOfUser(int apogee)
        {
            List<Convention> list = new List<Convention>();

            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "select * from conventions where apogee=" + apogee;

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Convention(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["Apogee"].ToString()),
                    reader["StartDate"].ToString(),
                    reader["EndDate"].ToString(),
                    reader["CompanyName"].ToString(),
                    reader["City"].ToString(),
                    reader["Comments"].ToString(),
                    reader["Status"].ToString()
                ));
            }

            conn.Close();

            return list;
        }


        public Convention GetOneById(int id)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "select * from conventions where Id=" + id;

            Console.WriteLine(sqlCommand);

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();

            Convention convention = null;

            if (reader.Read())
            {
                convention = new Convention(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["Apogee"].ToString()),
                    reader["StartDate"].ToString(),
                    reader["EndDate"].ToString(),
                    reader["CompanyName"].ToString(),
                    reader["City"].ToString(),
                    reader["Comments"].ToString(),
                    reader["Status"].ToString()
                );
            }

            conn.Close();

            return convention;
        }


        public Convention Update(Convention convention)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "update conventions set " +
                "Apogee=" + convention.Apogee + ", " +
                "StartDate='" + convention.StartDate + "', " +
                "EndDate='" + convention.EndDate + "', " +
                "CompanyName='" + convention.CompanyName + "', " +
                "City='" + convention.City + "', " +
                "Comments='" + convention.Comments + "', " +
                "Status='" + convention.Status + "' " +
                "where Id=" + convention.Id;

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();

            conn.Close();

            return convention;
        }


        public void DeleteOneById(int id)
        {
            MySqlConnection conn = DB.GetConnection();

            conn.Open();

            string sqlCommand = "delete from conventions where Id=" + id;

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            var reader = cmd.ExecuteReader();
            conn.Close();
        }


    }
}
