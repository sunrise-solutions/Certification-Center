using MySql.Data.MySqlClient;

namespace CertificationTest.Data
{
    public class CertificationTestContext
    {
        public string ConnectionString { get; set; }

        public CertificationTestContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
