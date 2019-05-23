using Course.Commands;
using Course.Data;
using Course.Model;
using Mapster;
using MySql.Data.MySqlClient;
using System;

namespace Course.Handlers
{
    public class UpdateCourseHandler
    {
        private readonly CourseContext _context;

        public UpdateCourseHandler(CourseContext context)
        {
            _context = context;
        }

        public bool Handle(int courseId, CreateCourseCommand request)
        {
            var model = request.Adapt<Model.MedicalCourse>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update courses set course_name='{1}', qualification='{2}' where course_id={0}",
                    courseId.ToString(),
                    model.Name,
                    model.Qualification);

                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return false;

                }
                finally
                {
                    conn.CloseAsync();
                }
            }

            return true;
        }
    }
}
