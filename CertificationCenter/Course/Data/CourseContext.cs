using MySql.Data.MySqlClient;

namespace Course.Data
{
    public class CourseContext
    {
        public string ConnectionString { get; set; }

        public CourseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}