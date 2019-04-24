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

        public bool Handle(int questionId, int topicId)
        {
            try
            {
                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();
                    string query = string.Format("delete from Questions where (question_id, Topics_topic_id) = ({0}, {1})", questionId, topicId);
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