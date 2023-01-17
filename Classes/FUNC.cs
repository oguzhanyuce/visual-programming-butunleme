using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace visualprogrammingfinalemlak.Classes
{
    
    class FUNC
        
    {

        DB_CONNECTION connection = new DB_CONNECTION();
        //eklem{

        

        public Boolean ExecQuery(MySqlCommand command)
            
            
        {
            command.Connection = connection.getConnection;

            connection.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
                return false;

            }
            }
            //güncellemek
            //silmek
            //verilerialmak
            
            public DataTable getData(MySqlCommand command)
                
            {

            command.Connection=connection.getConnection;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);


             DataTable table = new DataTable();

            adapter.Fill(table);
          


            return table;
        }
        /* public object listele(string tablo)
             {
         try
         {


             connection.connection.Open();
             DataTable dt = new DataTable();
             // baglantı.adapter = new MySqlDataAdapter("SELECT username,password FROM users WHERE username="+username+" AND password='"+password+"'",baglantı.connection);
             //baglantı.cmd.Parameters.AddWithValue("@un",username);
             // baglantı.cmd.Parameters.AddWithValue("@pass", password);
             // baglantı.cmd.ExecuteNonQuery();
             MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM "+tablo+" ", connection.connection);
             // baglantı.adapter = new MySqlDataAdapter(Convert.ToString(baglantı.cmd),baglantı.connection);
             adapter.Fill(dt);
             return dt;
         }
         catch (Exception)
         {

             throw;
         }
     }*/
    }
}

