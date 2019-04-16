using Course.Data;
using Course.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Course.Handlers
{
    public class GetCourseByIdHandler
    {
        private readonly CourseContext _context;

        public GetCourseByIdHandler(CourseContext context)
        {
            _context = context;
        }

        public List<MedicalCourse> Handle(int specialistId)
        {
            List<MedicalCourse> list = new List<MedicalCourse>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Courses where course_id=" + specialistId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MedicalCourse()
                            {
                                Id = Convert.ToInt32(reader["course_id"]),
                                Name = reader["course_name"].ToString(),
                                Qualification = Convert.ToInt32(reader["qualification"])
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