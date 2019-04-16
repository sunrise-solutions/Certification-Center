using Course.Commands;
using Course.Data;
using Course.Model;
using Mapster;
using MySql.Data.MySqlClient;

namespace Course.Handlers
{
    public class CreateCourseHandler
    {
        private readonly CourseContext _context;

        public CreateCourseHandler(CourseContext context)
        {
            _context = context;
        }

        public bool Handle(CreateCourseCommand request)
        {
            var model = request.Adapt<MedicalCourse>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("insert into Courses(course_name, qualification) values('{0}', '{1}')",
                    model.Name, model.Qualification);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
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