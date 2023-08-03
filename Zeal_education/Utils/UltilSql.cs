using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using Zeal_education.Data;
using Zeal_education.Models;

namespace Zeal_education.Utils
{
    public class UltilSql
    {
        private static string _connectionstring = "Server=localhost;Database=zeal_education;Uid=root;Pwd=123456;";
        public static List<ReportModel> GetNumberOfCourseByCategory()
        {
            List<ReportModel> list = new List<ReportModel>();
            using (MySqlConnection sqlConnection = new MySqlConnection(_connectionstring))
            {
                sqlConnection.Open();
                string query = "SELECT Name, COUNT(*) as NumberOfCourse FROM Course JOIN Category ON Category .Id= Course.CategoryId GROUP BY Name";
                MySqlCommand command = new MySqlCommand(query, sqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReportModel report = new ReportModel()
                    {
                        name= reader.GetString("Name"),
                        numberofcourse= reader.GetInt32("NumberOfCourse"),
                    };
                    list.Add(report);
                }
            }
            return list;
        }
    }
}
