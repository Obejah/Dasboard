using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DashboardScrumWindowsFormApp
{
    internal class CRUDRepository
    {
        public void CreateConnection()
        {
            string connString = "Server=localhost;Database=mydatabase;Uid=myusername;Pwd=mypassword";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection to MySQL database is open!");
            }

        }

    }
}
