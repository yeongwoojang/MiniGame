using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class DatabaseConnection
    {
        static internal MySqlConnection conn = null;
        internal string connectionString = null;
        internal MySqlConnection GetConnection(string connectionString)  //데이터베이스 연결
        {
            this.connectionString = connectionString;
            if (conn == null) conn = new MySqlConnection(this.connectionString);
            return conn;
        }
        internal void disPose()
        {
            conn.Dispose();

        }

    }
}
