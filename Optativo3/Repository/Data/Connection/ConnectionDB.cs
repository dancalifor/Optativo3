using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optativo3.Repository.Data.Connection
{
    public class ConnectionDB
    {
        private string connectionString;

        public ConnectionDB(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
