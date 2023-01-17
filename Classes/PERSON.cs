using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace visualprogrammingfinalemlak.Classes
{
    class PERSON
    {
        //satıcılar için gerekli sınıfları burada kullanacağız.

        FUNC func = new FUNC();
        private int id;
        private string fname;
        private string lname;
        private string phone;
        private string email;
        private string address;


        public PERSON() { }
        public PERSON(int ID,string FNAME, string LNAME, string PHONE, string EMAIL, string ADDRESS)
        {
            this.id = ID;
            this.fname = FNAME;
            this.lname = LNAME;
            this.phone = PHONE;
            this.email = EMAIL;
            this.address = ADDRESS;
        }
        

        public DataTable getAllPersons(string ownerORclient)
        {
            string tableName = ownerORclient;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `"+ tableName +"`");
            return func.getData(command);
        }
        public Boolean insertPerson(string ownerORclient,PERSON person)
        {
            string tableName = ownerORclient;

            MySqlCommand command = new MySqlCommand("INSERT INTO `"+ tableName +"`(`first_name`, `last_name`, `phone`, `email`, `address`) VALUES (@fn,@ln,@phn,@mail,@adrs)");

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = person.fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = person.lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = person.phone;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = person.email;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = person.address;
            


            return func.ExecQuery(command);

        }
        public Boolean updatePerson(string ownerORclient, PERSON person)
        {
            string tableName = ownerORclient;

            MySqlCommand command = new MySqlCommand("UPDATE `" + tableName + "` SET `first_name`=@fn,`last_name`=@ln,`phone`=@phn,`email`=@mail,`address`=@adrs WHERE `id`=@id");

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = person.id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = person.fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = person.lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = person.phone;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = person.email;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = person.address;



            return func.ExecQuery(command);

        }


        //seçilen kişiyi sil
        public Boolean deletePerson(string ownerORclient, int id)
        {
            string tableName = ownerORclient;

            MySqlCommand command = new MySqlCommand("DELETE FROM `" + tableName + "` WHERE `id`=@id");

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            return func.ExecQuery(command);
        }
    }
}
