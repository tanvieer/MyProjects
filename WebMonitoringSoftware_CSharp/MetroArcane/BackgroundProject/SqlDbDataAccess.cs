using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProject
{
    class SqlDbDataAccess
    {
        const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\cHashProject\\Database\\Arcane_WebsiteMgt.mdf;Integrated Security=True;Connect Timeout=30";



        public SqlCommand GetCommand(String query)
        {
            var connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}
