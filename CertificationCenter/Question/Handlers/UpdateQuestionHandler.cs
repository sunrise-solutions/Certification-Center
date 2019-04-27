using Question.Commands;
using Question.Data;
using Question.Model;
using Mapster;
using MySql.Data.MySqlClient;
using System;

namespace Question.Handlers
{
    public class UpdateQuestionHandler
    {
        private readonly QuestionContext _context;

        public UpdateQuestionHandler(QuestionContext context)
        {
            _context = context;
        }

        public bool Handle(int questionId, CreateQuestionCommand request)
        {
            var model = request.Adapt<Model.Question>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update questions set question='{1}', Answer_1='{2}', Is_Answer_1_True={3},"+
                    "Answer_2='{4}', Is_Answer_2_True={5}, Answer_3='{6}', Is_Answer_3_True={7}," +
                    "Answer_4='{8}', Is_Answer_4_True={9}, Answer_5='{10}', Is_Answer_5_True={11}," +
                    "topics_topic_id={12}, topics_courses_course_id={13} where question_id={0}",
                    questionId.ToString(),
                    model.Description,
                    model.Answer1,
                    IsOneOrZero(model.IsAnswer1True),
                    model.Answer2,
                    IsOneOrZero(model.IsAnswer2True),
                    model.Answer3,
                    IsOneOrZero(model.IsAnswer3True),
                    model.Answer4,
                    IsOneOrZero(model.IsAnswer4True),
                    model.Answer5,
                    IsOneOrZero(model.IsAnswer5True),
                    model.TopicId,
                    model.CourseId);

                

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

        private int IsOneOrZero(bool check)
        {
            return check ? 1 : 0;
        }
    }
}
