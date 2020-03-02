using System;
using Karluks.API.Infrastructure.Interface;
using MySql.Data.MySqlClient;

namespace Karluks.API.Infrastructure.Data
{
    public class Connection : IConnection
    {
        private MySqlConnection mySqlConnection;
        public Connection(string connectionString, log4net.ILog log)
        {

        }

        public async MySqlConnection Conn()
        {
            mySqlConnection=
        }
    }
}
