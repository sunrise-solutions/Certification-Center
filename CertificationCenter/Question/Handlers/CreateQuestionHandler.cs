using Mapster;
using MySql.Data.MySqlClient;
using Question.Commands;
using Question.Data;
using System;

namespace Question.Handlers
{
    public class CreateQuestionHandler
    {
        private readonly QuestionContext _context;

        public CreateQuestionHandler(QuestionContext context)
        {
            _context = context;
        }

        public bool Handle(CreateQuestionCommand request)
        {
            var question = request.Adapt<Model.Question>();
            int id = FindCountInDB("select count(*) from Questions where Topics_topic_id=" + question.TopicId.ToString()) + 1;
            try
            {
                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();
                    string query = string.Format("insert into Questions(question_id, question, answer_1, is_answer_1_true, answer_2, is_answer_2_true, answer_3, is_answer_3_true, answer_4, is_answer_4_true, answer_5, is_answer_5_true, Topics_topic_id) " +
                        "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                        id, question.Description, question.Answer1, IsOneOrZero(question.IsAnswer1True), 
                        question.Answer2, IsOneOrZero(question.IsAnswer2True), question.Answer3, IsOneOrZero(question.IsAnswer3True),
                        question.Answer4, IsOneOrZero(question.IsAnswer4True), question.Answer5, IsOneOrZero(question.IsAnswer5True), question.TopicId);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.CloseAsync();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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

        private int IsOneOrZero(bool check)
        {
            return check ? 1 : 0;
        }
    }
}
