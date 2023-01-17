using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace visualprogrammingfinalemlak.Classes
{
     public class DB_CONNECTION
    {

       public MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=emlakuygulamasi");
       public  MySqlCommand cmd;
       public MySqlDataAdapter adapter;
       public DataTable dt;
        public MySqlDataReader dr;
        public MySqlConnection getConnection;




        public MySqlConnection GetConnection()
        {
         
          {
                return connection;
          }
        }

        public void openConnection()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                return;
            }
            
            connection.Open();
        }
        public void closeConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
