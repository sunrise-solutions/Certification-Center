using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Test.Data;

namespace Topic.Handlers
{
    public class DeleteTestHandler
    {
        private readonly TestContext _context;

        public DeleteTestHandler(TestContext context)
        {
            _context = context;
        }

        public bool Handle(int testId)
        {
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("delete from Training_Tests where (training_id) = ({0})", testId);
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
    }
}