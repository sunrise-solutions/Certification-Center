using Mapster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Topic.Commands;
using Topic.Data;

namespace Topic.Handlers
{
    public class UpdateTopicHandler
    {
        private readonly TopicContext _context;

        public UpdateTopicHandler(TopicContext context)
        {
            _context = context;
        }

        public bool Handle(int topicId, CreateTopicCommand request)
        {
            var model = request.Adapt<Model.Topic>();
            
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("update Topics set topic_name='{1}', count_of_questions={2},"+
                    "Courses_course_id={3} where topic_id={0}", 
                    topicId,
                    model.Name, 
                    model.CountOfQuestions, 
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
