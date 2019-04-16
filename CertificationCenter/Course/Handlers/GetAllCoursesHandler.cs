using Course.Data;
using Course.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Handlers
{
    public class GetAllCoursesHandler
    {
        private readonly CourseContext _context;

        public GetAllCoursesHandler(CourseContext context)
        {
            _context = context;
        }

        public List<MedicalCourse> Handle()
        {
            List<MedicalCourse> list = new List<MedicalCourse>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Courses", conn);

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
