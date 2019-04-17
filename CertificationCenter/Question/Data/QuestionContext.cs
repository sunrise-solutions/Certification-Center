using MySql.Data.MySqlClient;

namespace Question.Data
{
    public class QuestionContext
    {
        public string ConnectionString { get; set; }

        public QuestionContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
