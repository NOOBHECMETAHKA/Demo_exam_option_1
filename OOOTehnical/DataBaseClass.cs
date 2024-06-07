using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOOTehnical
{
    public class DataBaseClass
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UL9Q5UH\\MISHASQL;Initial Catalog=TehnicalService;User ID=sa;Password=123");

        public DataTable read(string command)
        {
            DataTable dataTable = new DataTable();
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            dataTable.Load(cmd.ExecuteReader());
            conn.Close();
            return dataTable;
        }

        public void execute(string command)
        { 
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool checkAuth(string login, string password)
        {
            DataTable dataTable = new DataTable();
            conn.Open();

            string command = "select * from [dbo].[user] where [login] = '{0}' and [password] = '{1}'";
            command = string.Format(command, login, password);

            SqlCommand cmd = new SqlCommand(command, conn);
            dataTable.Load(cmd.ExecuteReader());

            DataBaseClass dataBaseClass = new DataBaseClass();
            DataTable dt = new DataTable();

            dt = dataBaseClass.read(command);

            conn.Close();

            return dt.Rows.Count > 0;
        }
    }
}
