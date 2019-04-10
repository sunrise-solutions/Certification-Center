using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Data;
using Test.Model;

namespace Test.Handlers
{
    public class GetTestByIdHandler
    {
        private readonly TestContext _context;

        public GetTestByIdHandler(TestContext context)
        {
            _context = context;
        }

        public List<TrainingTest> Handle(int testId)
        {
            List<TrainingTest> list = new List<TrainingTest>();

            using (MySqlConnection conn = _context.GetConnection())
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
    }
}
