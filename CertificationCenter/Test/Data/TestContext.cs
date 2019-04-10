using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Model;

namespace Test.Data
{
    public class TestContext
    {
        public string ConnectionString { get; set; }

        public TestContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
