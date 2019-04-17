using MySql.Data.MySqlClient;

namespace Topic.Data
{
    public class TopicContext
    {
        public string ConnectionString { get; set; }

        public TopicContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
