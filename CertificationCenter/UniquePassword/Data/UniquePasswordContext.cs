using MySql.Data.MySqlClient;

namespace UniquePassword.Data
{
    public class UniquePasswordContext
    {
        public string ConnectionString { get; set; }

        public UniquePasswordContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
