using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using UniquePassword.Data;
using UniquePassword.Model;

namespace UniquePassword.Handlers
{
    public class GetUniquePasswordByDateHandler
    {
        private readonly UniquePasswordContext _context;

        public GetUniquePasswordByDateHandler(UniquePasswordContext context)
        {
            _context = context;
        }

        public List<EverydayUniquePassword> Handle(DateTime date)
        {
            List<EverydayUniquePassword> list = new List<EverydayUniquePassword>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Everyday_Unique_Passwords where date=" + date.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EverydayUniquePassword()
                            {
                                Date = Convert.ToDateTime(reader["date"]),
                                PasswordHash = reader["password_hash"].ToString(),
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
