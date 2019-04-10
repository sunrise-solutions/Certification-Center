using Mapster;
using MySql.Data.MySqlClient;
using Test.Commands;
using Test.Data;
using Test.Model;

namespace Test.Handlers
{
    public class CreateTestHandler
    {
        private readonly TestContext _context;

        public CreateTestHandler(TestContext context)
        {
            _context = context;
        }

        public bool Handle(CreateTestCommand request)
        {
            var test = request.Adapt<TrainingTest>();
            try
            {
                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();
                    string query = string.Format("insert into Training_Tests(date, result, Specialists_specialist_id, Topics_topic_id) values('{0}', '{1}', '{2}', '{3}')",
                        test.Date.ToString("yyyy-MM-dd HH:mm:ss"), test.Result, test.SpecialistId, test.TopicId);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.CloseAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
