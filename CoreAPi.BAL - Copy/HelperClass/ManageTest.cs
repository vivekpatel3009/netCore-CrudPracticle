using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AthletePerformanceTrackerAPI.BAL.Model;
using Microsoft.Extensions.Configuration;
using AthletePerformanceTrackerAPI.BAL.Repository;

namespace AthletePerformanceTrackerAPI.BAL.HelperClass
{
    public class ManageTest : IManageTest
    {
        private IConfiguration _config;
        private string conn = string.Empty;
        public ManageTest(IConfiguration config)
        {
            this._config = config;
            this.conn = _config["ConnectionStrings:AthletePerformanceTrackerDatabase"];
        }

        /// <summary>
        /// Method for creating test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public string CreateTest(AthletePerformanceTrackerAPI.BAL.Model.Test test)
        {
            try
            {
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "CreateTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@TestMasterId", SqlDbType.Int).Value = test.TestMasterId;
                        command.Parameters.Add("@Date", SqlDbType.DateTime).Value = test.Date;
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        /// <summary>
        /// Method for checking whether test is exist for particular date or not
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public string IsTestExist(AthletePerformanceTrackerAPI.BAL.Model.Test test)
        {
            try
            {
                long Count = 0;
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "IsTestExist";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@TestMasterId", SqlDbType.BigInt).Value = test.TestMasterId;
                        command.Parameters.Add("@Date", SqlDbType.DateTime).Value = test.Date;
                        command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Count = Convert.ToInt32(reader["TestCount"].ToString());   
                        }
                        connection.Close();
                    }
                }
                return (Count > 0) ? "exist" : "notfound";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }

        /// <summary>
        /// Method for removing particular test
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        public string DeleteTest(long testId)
        {
            try
            {
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "DeleteTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@TestId", SqlDbType.BigInt).Value = testId;
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                return "Sucess";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }

        /// <summary>
        /// Method for get all test
        /// </summary>
        /// <returns>test list</returns>
        public List<GetAllTest> GetAllTest()
        {
            try
            {
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "GetAllTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            GetAllTest getAllTest = new GetAllTest();
                            getAllTest.Date = Convert.ToDateTime(reader["Date"].ToString());
                            getAllTest.TestId = long.Parse(reader["TestId"].ToString());
                            getAllTest.Name = reader["Name"].ToString();
                            getAllTest.AthleteCount = int.Parse(reader["AthleteCount"].ToString());
                            lstGetAllTest.Add(getAllTest);
                        }
                        connection.Close();
                    }
                }
                return lstGetAllTest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
