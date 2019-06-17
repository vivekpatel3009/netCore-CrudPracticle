using AthletePerformanceTrackerAPI.BAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using AthletePerformanceTrackerAPI.BAL.Repository;

namespace AthletePerformanceTrackerAPI.BAL.HelperClass
{
    public class ManageAthlete :IManageAthlete
    {
        private IConfiguration configuration;
        private string conn = string.Empty;
        private IConfiguration _config;
        public ManageAthlete(IConfiguration config)
        {
            this._config = config;
            this.conn = _config["ConnectionStrings:AthletePerformanceTrackerDatabase"];
        }
        /// <summary>
        /// Add Athlete in test
        /// </summary>
        /// <param name="athleteTest">userid,testid,score</param>
        /// <returns></returns>
        public string AddAthleteInTest(AthleteTest athleteTest)
        {
            try
            {
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "AddAthleteInTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@UserId", SqlDbType.BigInt).Value = athleteTest.UserId;
                        command.Parameters.Add("@TestId", SqlDbType.BigInt).Value = athleteTest.TestId;
                        command.Parameters.Add("@Score", SqlDbType.NVarChar).Value = athleteTest.Score;
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
        /// Athlete list for add and edit athlete in test
        /// </summary>
        /// <param name="auFlag">Operation flag</param>
        /// <param name="testId"></param>
        /// <returns>Athlete list</returns>
        public List<GetTestAthlete> GetAthleteListForAddNUpdate(string auFlag, long testId)
        {
            
            List<GetTestAthlete> lstGetTestAthlete = new List<GetTestAthlete>();
            using (SqlConnection connection = new SqlConnection(this.conn))
            {
                string sql = "GetAthleteListForAddNUpdate";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@AUFlag", SqlDbType.NVarChar).Value = auFlag;
                    command.Parameters.Add("@TestId", SqlDbType.BigInt).Value = testId;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetTestAthlete getTestAthlete = new GetTestAthlete();
                        getTestAthlete.UserId = long.Parse((reader["UserId"].ToString()));
                        getTestAthlete.FirstName = reader["FirstName"].ToString();
                        getTestAthlete.LastName = reader["LastName"].ToString();
                        getTestAthlete.Score = decimal.Parse(reader["Score"].ToString());
                        lstGetTestAthlete.Add(getTestAthlete);
                    }
                    connection.Close();
                }
            }
            return lstGetTestAthlete;
        }

        /// <summary>
        /// Remove athlete from particular test
        /// </summary>
        /// <param name="userTestId"></param>
        /// <returns></returns>
        public string DeleteAthleteFromTest(long userTestId)
        {
            try
            {
                List<GetAllTest> lstGetAllTest = new List<GetAllTest>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "DeleteAthleteFromTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@UserTestId", SqlDbType.BigInt).Value = userTestId;
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                return "Sucess";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        /// <summary>
        /// Get athlete list for particular test
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>Athlete list</returns>
        public List<GetTestAthlete> GetTestAthlete(long testId)
        {
            try
            {
                List<GetTestAthlete> lstGetTestAthlete = new List<GetTestAthlete>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "GetTestAthlete";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TestId", SqlDbType.BigInt).Value = testId;
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            GetTestAthlete getTestAthlete = new GetTestAthlete();
                            getTestAthlete.UserId = long.Parse(reader["UserId"].ToString());
                            getTestAthlete.UserTestId = long.Parse(reader["UserTestId"].ToString());
                            getTestAthlete.TestId = long.Parse(reader["TestId"].ToString());
                            getTestAthlete.TestMasterId = Int16.Parse(reader["TestMasterId"].ToString());
                            getTestAthlete.FirstName = reader["FirstName"].ToString();
                            getTestAthlete.LastName = reader["LastName"].ToString();
                            getTestAthlete.Score = decimal.Parse(reader["Score"].ToString());

                            lstGetTestAthlete.Add(getTestAthlete);
                        }
                        connection.Close();
                    }
                }
                return lstGetTestAthlete;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Update athlete score in test
        /// </summary>
        /// <param name="athleteTest"></param>
        /// <returns></returns>
        public string UpdateAthleteInTest(AthleteTest athleteTest)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "UpdateAthleteInTest";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        command.Parameters.Add("@UserId", SqlDbType.BigInt).Value = athleteTest.UserId;
                        command.Parameters.Add("@TestId", SqlDbType.BigInt).Value = athleteTest.TestId;
                        command.Parameters.Add("@Score", SqlDbType.NVarChar).Value = athleteTest.Score;

                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                return "Sucess";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }
         
        /// <summary>
        /// Method for getting result of all test for athlete
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Result list</returns>
        public List<AthleteResult> GetAthleteResult(long userId)
        {
            try
            {
                List<AthleteResult> lstAthleteResult = new List<AthleteResult>();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "GetAthleteResult";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@UserId", SqlDbType.BigInt).Value = userId;
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            AthleteResult athleteResult = new AthleteResult();
                            athleteResult.UserTestId = long.Parse(reader["UserTestId"].ToString());
                            athleteResult.TestName = reader["Name"].ToString();
                            athleteResult.Date = Convert.ToDateTime(reader["Date"].ToString());
                            athleteResult.Score = decimal.Parse(reader["Score"].ToString());

                            lstAthleteResult.Add(athleteResult);
                        }
                        connection.Close();
                    }
                }
                return lstAthleteResult;
            }
            catch (Exception ex)
            {
                return new List<AthleteResult>();
            }
        }

        /// <summary>
        /// Method for authenticate and authorize user
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns>User Detail</returns>
        public UserDetail GetPersonDetail(UserDetail userDetail)
        {
            try
            {
                UserDetail userData = new UserDetail();
                using (SqlConnection connection = new SqlConnection(this.conn))
                {
                    string sql = "GetPersonDetail";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = userDetail.Email;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userDetail.Password;
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            userData.UserId = long.Parse(reader["UserId"].ToString());
                            userData.FirstName = reader["FirstName"].ToString();
                            userData.LastName = reader["LastName"].ToString();
                            userData.RoleId = long.Parse(reader["RoleId"].ToString());
                            userData.Email = reader["Email"].ToString();
                            userData.Password = reader["Password"].ToString();
                        }
                        connection.Close();
                    }
                }
                return userData;
            }
            catch (Exception ex)
            {
                return new UserDetail();
            }
        }
    }
}
