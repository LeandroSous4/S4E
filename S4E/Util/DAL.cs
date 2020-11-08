using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace S4E.Util
{
    public class DAL
    {
        private const string _strCon = @"Data Source=localhost;Initial Catalog=S4E; Integrated Security = true;";
        SqlConnection connection = null;

        public DAL()
        {
            connection = new SqlConnection(_strCon);
            connection.Open();
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dataTable);
            
            return dataTable;
        }

        public void ExecutarSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
    
}
