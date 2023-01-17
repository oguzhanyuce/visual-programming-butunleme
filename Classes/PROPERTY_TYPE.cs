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
   class PROPERTY_TYPE

    {
        FUNC func = new FUNC();
        public Boolean insertType(string name,string description)
        {
            
            MySqlCommand command = new MySqlCommand("INSERT INTO `property_type`(`ad`, `Tanimlama`) VALUES (@nm,@dscr)");

            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@dscr", MySqlDbType.VarChar).Value = description;
          

             return func.ExecQuery(command);

        }

        public Boolean updateType(int id, string name, string description)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `property_type` SET `ad`=@nm,`Tanimlama`=@dscr WHERE `id`=@id");

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@dscr", MySqlDbType.VarChar).Value = description;

            return func.ExecQuery(command);

        }

        public Boolean deleteType(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `property_type` WHERE `id`=@id");

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            

            return func.ExecQuery(command);

        }



        public DataTable getAllTypes()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `property_type`");
            return func.getData(command);
        }
        
    }
}
