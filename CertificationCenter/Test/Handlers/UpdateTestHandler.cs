using MySql.Data.MySqlClient;
using Test.Data;
using Test.Model;
using Test.Commands;
using Mapster;

namespace Test.Handlers
{
    public class UpdateTestHandler
    {
        private readonly TestContext _context;

        public UpdateTestHandler(TestContext context)
        {
            _context = context;
        }

        public bool Handle(int testId, CreateTestCommand request)
        {
            var model = request.Adapt<Model.TrainingTest>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update Tests set date = {1}, result= {2} specialist_id = {3}" +
                    "topic_id = {4} where health_facility_id={0}",
                    testId.ToString(),
                    model.Date,
                    model.Result,
                    model.SpecialistId,
                    model.TopicId);

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
