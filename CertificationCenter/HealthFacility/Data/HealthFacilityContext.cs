using MySql.Data.MySqlClient;

namespace HealthFacility.Data
{
    public class HealthFacilityContext
    {
        public string ConnectionString { get; set; }

        public HealthFacilityContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
