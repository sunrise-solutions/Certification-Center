using Mapster;
using MySql.Data.MySqlClient;
using Question.Commands;
using Question.Data;
using System;

namespace Question.Handlers
{
    public class DeleteQuestionHandler
    {
        private readonly QuestionContext _context;

        public DeleteQuestionHandler(QuestionContext context)
        {
            _context = context;
        }

        public bool Handle(int questionId, int topicId, int courseId)
        {
            try
            {
                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();
                    string query = string.Format("delete from Questions where (question_id, Topics_topic_id, Topics_Courses_course_id) = ({0}, {1}, {2})", questionId, topicId, courseId);
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