using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebFinancas.DataLayer
{
    public class DAL
    {
        private static string server = "localhost";
        private static string database = "finances";
        private static string user = "root";
        private static string password = "root";
        private static string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password}";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        //Execute command select
        public DataTable ReturnDataTable(string sql)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapterdata = new MySqlDataAdapter(command);
            adapterdata.Fill(datatable);
            return datatable;
        }

        //Execute command insert,update and delete
        public void ExecuteCommandSql(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
