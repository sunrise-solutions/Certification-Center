using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Topic.Data;

namespace Topic.Handlers
{
    public class GetTopicByIdHandler
    {
        private readonly TopicContext _context;

        public GetTopicByIdHandler(TopicContext context)
        {
            _context = context;
        }

        public Model.Topic Handle(int topicId)
        {
            List<Model.Topic> list = new List<Model.Topic>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Topics where topic_id=" + topicId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Model.Topic()
                            {
                                Id = Convert.ToInt32(reader["topic_id"]),
                                Name = reader["topic_name"].ToString(),
                                CountOfQuestions = Convert.ToInt32(reader["count_of_questions"]),
                                CourseId = Convert.ToInt32(reader["Courses_course_id"])
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
            return list[0];
        }
    }
}
