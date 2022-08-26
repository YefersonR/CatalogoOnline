using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DBConnection
    {
        private SqlConnection ConnectionString;
        
        
        public void OpenConnection()
        {
            ConnectionString = new SqlConnection("Server=DESKTOP-R7UJB59;Database=CatalogoOnline;Trusted_Connection=True");
            ConnectionString.Open();
        }
        public SqlCommand CreateCommand()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionString;
            return command;
        }
        public void CloseConnection()
        {
            ConnectionString.Close();
        }
    }
}
