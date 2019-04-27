using CertificationTest.Commands;
using CertificationTest.Data;
using Mapster;
using MySql.Data.MySqlClient;

namespace CertificationTest.Handlers
{
    public class UpdateCertificationTestHandler
    {
        private readonly CertificationTestContext _context;

        public UpdateCertificationTestHandler(CertificationTestContext context)
        {
            _context = context;
        }

        public bool Handle(int certificationTestId, CreateCertificationTestCommand request)
        {
            var model = request.Adapt<Model.CertificationTest>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update Certification_Tests set date = {1}, result = {2}, Specialists_specialist_id = {3}, Courses_course_id = {4}" +
                    "where certification_id={0}",
                    certificationTestId.ToString(),
                    model.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    model.Result,
                    model.SpecialistId,
                    model.CourseId);

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
