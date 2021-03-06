using ConnectionStringDAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace ConnectionStringDAL
{
    public class ConnectionStringRepository
    {
        private SqlConnection conObj;
        private SqlCommand cmdObj;

        public ConnectionStringRepository(IConfiguration config)
        {
            conObj = new SqlConnection(config.GetConnectionString("DBConnectionString"));
        }

        // public string GetConnectionString()
        //{
            // var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //var config = builder.Build();
            //var connectionString = config.GetConnectionString("DBConnectionString");

            //return connectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            //return connectionString;
        //}

        public List<Course> GetCourseDetails()
        {
            List<Course> courseLst = new List<Course>();
            DataTable result = new DataTable();
            string query = "select * from Course";
            cmdObj = new SqlCommand(query, conObj);
            SqlDataAdapter sdaResult = new SqlDataAdapter(cmdObj);

            try
            {
                sdaResult.Fill(result);
                courseLst = (result.AsEnumerable().Select(x => new Course
                {
                    CourseID = Convert.ToInt32(x["courseID"]),
                    CourseName = Convert.ToString(x["courseName"])

                })).ToList();
                conObj.Open();
            }
            catch (Exception)
            {
                courseLst = null;

            }
            return courseLst;
        }
    }
}
