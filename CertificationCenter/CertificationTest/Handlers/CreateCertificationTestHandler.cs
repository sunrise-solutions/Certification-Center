using CertificationTest.Commands;
using CertificationTest.Data;
using Mapster;
using MySql.Data.MySqlClient;

namespace CertificationTest.Handlers
{
    public class CreateCertificationTestHandler
    {
        private readonly CertificationTestContext _context;

        public CreateCertificationTestHandler(CertificationTestContext context)
        {
            _context = context;
        }

        public bool Handle(CreateCertificationTestCommand request)
        {
            var model = request.Adapt<Model.CertificationTest>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("insert into Certification_Tests(date, result, Specialists_specialist_id, Courses_course_id) " +
                    "values('{0}', '{1}', '{2}', '{3}' )",
                    model.Date.ToString("yyyy-MM-dd HH:mm:ss"), model.Result, model.SpecialistId, model.CourseId);
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
