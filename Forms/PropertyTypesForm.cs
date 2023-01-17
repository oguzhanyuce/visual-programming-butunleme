using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace visualprogrammingfinalemlak.Forms
{
    public partial class PropertyTypesForm : Form
    {
        Classes.FUNC islem = new Classes.FUNC();
        Classes.DB_CONNECTION baglantı = new Classes.DB_CONNECTION();
        public PropertyTypesForm()
        {
            InitializeComponent();
        }

        Classes.PROPERTY_TYPE pType = new Classes.PROPERTY_TYPE();
        private void PropertyTypesForm_Load(object sender, EventArgs e)
        {
            LoadListboxData();

            displayTypesCount();
        }


        //yeni işlem ekle
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string description = textBoxDescription.Text;
            


            if (name.Trim().Equals(""))
            {
                if (pType.insertType(name, description)) 
                    

                {
                    
                    MessageBox.Show("Eklendi","Ekle",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadListboxData();
                    displayTypesCount();
                }
               else
                {
                    MessageBox.Show("Eklenemedi", "Ekle",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("İlk olarak adı giriniz", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        
        private void listBoxTypes_Click(object sender, EventArgs e)
        {
        /*    string kayıt = (listBoxTypes.Items[listBoxTypes.SelectedIndex]).ToString();
            kayıt.Split(' ');
            textBoxID.Text =
            textBoxName.Text =
            //textBoxDescription.Text =*/
           
        }

        //seçileni düzenle
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string name = textBoxName.Text;
                string description = textBoxDescription.Text;

                if (!name.Trim().Equals(""))
                {
                    if (pType.updateType(id, name, description))


                    {
                        MessageBox.Show("Güncellendi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadListboxData();
                        displayTypesCount();


                    }
                    else
                    {
                        MessageBox.Show("Güncellenemedi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("İlk olarak adı giriniz", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch
            {
                MessageBox.Show("Hiç Bir Şey Seçilmedi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
       

        //seçileni sil 
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);


                if (MessageBox.Show("Silmeye Devam etmek istiyor musun?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (pType.deleteType(id))


                    {
                        MessageBox.Show("Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadListboxData();
                        displayTypesCount();

                        textBoxID.Text = "";
                        textBoxName.Text = "";
                        textBoxDescription.Text ="";


                    }
                    else
                    {
                        MessageBox.Show("Silinemedi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            catch 
            {
                MessageBox.Show("Hiç Bir Şey Seçilmedi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


          
        }
        public void LoadListboxData()
        {
            baglantı.connection.Open();
            string sql = "SELECT * FROM property_type";
            baglantı.cmd = new MySqlCommand(sql, baglantı.connection);
            baglantı.dr = baglantı.cmd.ExecuteReader();
            while (baglantı.dr.Read())
            {
                listBoxTypes.Items.Add(baglantı.dr[0].ToString()+" ad "+baglantı.dr[1].ToString()+" tanı "+baglantı.dr[2].ToString());
            }
            baglantı.dr.Close();

            listBoxTypes.SelectedItem = null;
        }
        public void displayTypesCount()
        {
            labelCount.Text = listBoxTypes.Items.Count + "Bilgi(ler)";
        }
    }
}
