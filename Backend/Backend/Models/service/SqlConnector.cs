using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BackEnd.Models
{
    public class SqlConnector : IDisposable
    {
        public MySqlConnection Connection;

        public SqlConnector()
        {
            Connection = new MySqlConnection("host=127.0.0.1;port=3306;user id=root;password=19950116;database=freshtomatoes;");
        }

        public SqlConnector(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
