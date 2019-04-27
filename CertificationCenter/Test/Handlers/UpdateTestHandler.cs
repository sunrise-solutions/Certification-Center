using MySql.Data.MySqlClient;
using Test.Data;
using Test.Model;
using Test.Commands;
using Mapster;
using System;

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

                string query = string.Format("update training_tests set date = '{1}', result= {2}, specialists_specialist_id = {3}, " +
                    "topics_topic_id = {4}, topics_courses_course_id={5} where training_id={0}",
                    testId.ToString(),
                    model.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    model.Result,
                    model.SpecialistId,
                    model.TopicId,
                    model.CourseId
                    );

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
