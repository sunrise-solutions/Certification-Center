using MySql.Data.MySqlClient;
using Question.Data;
using System;
using System.Collections.Generic;

namespace Question.Handlers
{
    public class GetQuestionsByTopicHandler
    {
        private readonly QuestionContext _context;

        public GetQuestionsByTopicHandler(QuestionContext context)
        {
            _context = context;
        }

        public List<Model.Question> Handle(int topicId)
        {
            List<Model.Question> list = new List<Model.Question>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Questions where Topics_topic_id=" + topicId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Model.Question()
                        {
                            Id = Convert.ToInt32(reader["question_id"]),
                            Description = reader["question"].ToString(),
                            Answer1 = reader["answer_1"].ToString(),
                            IsAnswer1True = IsTrueOrFalse(Convert.ToInt32(reader["is_answer_1_true"])),
                            Answer2 = reader["answer_2"].ToString(),
                            IsAnswer2True = IsTrueOrFalse(Convert.ToInt32(reader["is_answer_2_true"])),
                            Answer3 = reader["answer_3"].ToString(),
                            IsAnswer3True = IsTrueOrFalse(Convert.ToInt32(reader["is_answer_3_true"])),
                            Answer4 = reader["answer_4"].ToString(),
                            IsAnswer4True = IsTrueOrFalse(Convert.ToInt32(reader["is_answer_4_true"])),
                            Answer5 = reader["answer_5"].ToString(),
                            IsAnswer5True = IsTrueOrFalse(Convert.ToInt32(reader["is_answer_5_true"])),
                            TopicId = Convert.ToInt32(reader["Topics_topic_id"])
                        });
                    }
                }
            }
            return list;
        }

        private bool IsTrueOrFalse(int check)
        {
            return check == 1;
        }
    }
}
