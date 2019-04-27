using Mapster;
using MySql.Data.MySqlClient;
using System;
using UniquePassword.Commands;
using UniquePassword.Data;
using UniquePassword.Model;

namespace UniquePassword.Handlers
{
    public class CreateUniquePasswordHandler
    {
        private readonly UniquePasswordContext _context;

        public CreateUniquePasswordHandler(UniquePasswordContext context)
        {
            _context = context;
        }

        public bool Handle(CreateUniquePasswordCommand request)
        {



            // ! Add password generator



            var password = request.Adapt<EverydayUniquePassword>();
            string tempHash = Hash.FindHash(password.PasswordHash);
            password.PasswordHash = tempHash;
            password.Date = DateTime.Now;
            try
            {
                using (MySqlConnection conn = _context.GetConnection())
                {
                    conn.Open();
                    string query = string.Format("insert into Everyday_Unique_Passwords(date, password_hash) values('{0}', '{1}')",
                        password.Date.ToString("yyyy-MM-dd HH:mm:ss"), password.PasswordHash);
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
