using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Test.Data;
using Test.Model;

namespace Test.Handlers
{
    public class GetAllTestsHandler
    {
        private readonly TestContext _context;

        public GetAllTestsHandler(TestContext context)
        {
            _context = context;
        }

        public List<TrainingTest> Handle()
        {
            List<TrainingTest> list = new List<TrainingTest>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Training_Tests", conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TrainingTest()
                            {
                                Id = Convert.ToInt32(reader["training_id"]),
                                Date = Convert.ToDateTime(reader["date"]),
                                Result = Convert.ToInt32(reader["result"]),
                                SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                                TopicId = Convert.ToInt32(reader["Specialists_specialist_id"])
                            });
                        }
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    conn.CloseAsync();
                }

            }
            return list;
        }
    }
}
