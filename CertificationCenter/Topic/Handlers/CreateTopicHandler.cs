using Mapster;
using MySql.Data.MySqlClient;
using System;
using Topic.Commands;
using Topic.Data;

namespace Topic.Handlers
{
    public class CreateTopicHandler
    {
        private readonly TopicContext _context;

        public CreateTopicHandler(TopicContext context)
        {
            _context = context;
        }

        public bool Handle(CreateTopicCommand request)
        {
            var model = request.Adapt<Model.Topic>();
            int id = FindCountInDB("select count(*) from Topics where Courses_course_id=" + model.CourseId.ToString()) + 1;
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("insert into Topics(topic_id, topic_name, count_of_questions, Courses_course_id) " +
                    "values('{0}', '{1}', '{2}', '{3}')", id, model.Name, model.CountOfQuestions,model.CourseId);
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

        private int FindCountInDB(string query)
        {
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }
        }
    }
}
