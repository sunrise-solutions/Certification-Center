using CertificationTest.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CertificationTest.Handlers
{
    public class GetCertificationTestByIdHandler
    {
        private readonly CertificationTestContext _context;

        public GetCertificationTestByIdHandler(CertificationTestContext context)
        {
            _context = context;
        }

        public List<Model.CertificationTest> Handle(int testId)
        {
            List<Model.CertificationTest> list = new List<Model.CertificationTest>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Certification_Tests where certification_id=" + testId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.CertificationTest()
                            {
                                Id = Convert.ToInt32(reader["certification_id"]),
                                Date = Convert.ToDateTime(reader["date"]),
                                Result = Convert.ToInt32(reader["result"]),
                                SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                                CourseId = Convert.ToInt32(reader["Courses_course_id"])
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
