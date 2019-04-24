//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using Topic.Data;

//namespace Topic.Handlers
//{
//    public class DeleteTopicHandler
//    {
//        private readonly TopicContext _context;

//        public DeleteTopicHandler(TopicContext context)
//        {
//            _context = context;
//        }

//        public bool Handle(int topicId, int courseId)
//        {
//            using (MySqlConnection conn = _context.GetConnection())
//            {
//                conn.Open();
//                string query = string.Format("delete from Topics, Questions where (topic_id, course_id) in (" + topicId.ToString() + "";
//                MySqlCommand cmd = new MySqlCommand(query, conn);
//                try
//                {
//                    cmd.ExecuteNonQuery();
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    conn.CloseAsync();
//                }
//            }

//            return true;
//        }
//    }
//}
