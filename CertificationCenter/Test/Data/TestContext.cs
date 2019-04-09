using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Model;

namespace Test.Data
{
    public class TestContext
    {
        public string ConnectionString { get; set; }

        public TestContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TrainingTest> GetAllTrainingTests()
        {
            List<TrainingTest> list = new List<TrainingTest>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Training_Tests", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            TestId = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Specialists_specialist_id"])
                        });
                    }
                }
            }
            return list;
        }

        public List<TrainingTest> GetTrainingTestById(int testId)
        {
            List<TrainingTest> list = new List<TrainingTest>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from Training_Tests where training_id=" + testId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            TestId = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Specialists_specialist_id"])
                        });
                    }
                }
            }
            return list;
        }

        public bool CreateTrainingTest(TrainingTest test)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = string.Format("insert into Training_Tests(date, result, Specialists_specialist_id, Topics_topic_id) values('{0}', '{1}', '{2}', '{3}')", 
                        test.Date.ToString("yyyy-MM-dd HH:mm:ss"), test.Result, test.SpecialistId, test.TopicId);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
