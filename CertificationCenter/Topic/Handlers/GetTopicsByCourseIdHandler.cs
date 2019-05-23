using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Topic.Data;

namespace Topic.Handlers
{
    public class GetTopicsByCourseIdHandler
    {
        private readonly TopicContext _context;

        public GetTopicsByCourseIdHandler(TopicContext context)
        {
            _context = context;
        }

        public List<Model.Topic> Handle(int courseId)
        {
            List<Model.Topic> list = new List<Model.Topic>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Topics where Courses_course_id = " + courseId.ToString();
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
            return list;
        }
    }
}