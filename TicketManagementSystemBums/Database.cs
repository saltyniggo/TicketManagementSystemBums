using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TicketManagementSystemBums
{
    public class Database
    {
        private static string host = "localhost:5433";
        private static string username = "postgres";
        private static string password = "password123";
        private static string databaseName = "postgres";

        public static string Host
        {
            get { return host; }
            set { host = value; }
        }
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }
        public static string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }


        public static async Task<string> CreateConnString()
        {
            NpgsqlConnectionStringBuilder connStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Host,
                Username = Username,
                Password = Password,
                Database = DatabaseName
            };

            string connString = connStringBuilder.ConnectionString;
            return connString;
        }
    }
}
