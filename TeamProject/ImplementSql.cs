using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class ImplementSql
    {
        internal MySqlCommand cmd;
        internal string sql = null;
        internal void getSql(string sql)
        {
            cmd = new MySqlCommand(sql, DatabaseConnection.conn);
        }
    }
}
