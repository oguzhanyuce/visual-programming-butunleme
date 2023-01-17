using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace visualprogrammingfinalemlak.Forms
{

    public partial class PropertyOwnerForm : Form
    {
        public PropertyOwnerForm()
        {
            InitializeComponent();
        }

        Classes.PERSON person = new Classes.PERSON();

        private void PropertyOwnerForm_Load(object sender, EventArgs e)
        {

            LoadDatagridviewOwners();

            //satıcıların sayısını göster
            displayOwnersCount();
        }

        // YENİ  SATICI EKLE
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            string fname = textBoxFName.Text;
            string lname = textBoxLName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddres.Text;

            person = new Classes.PERSON(id, fname, lname, phone, email, address);

            if (verifTextBoxes())
            {

                if (person.insertPerson("property_owner", person))
                {
                    MessageBox.Show("Yeni Satıcı Eklendi", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridviewOwners();
                    displayOwnersCount();
                }
                else
                {
                    MessageBox.Show("Satıcı Eklenemedi", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Satıcı Ad Soyad Telefon Giriniz", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool verifTextBoxes()
        {
            string fname = textBoxFName.Text.Trim();
            string lname = textBoxLName.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            if (fname.Equals("") || lname.Equals("") || phone.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
            string fname = textBoxFName.Text;
            string lname = textBoxLName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddres.Text;
            try
            {
               int id = Convert.ToInt32(textBoxID.Text);

                if(verifTextBoxes())
                {
                    if(person.updatePerson("property_owner",new Classes.PERSON(id,fname,lname,phone,email,address)))
                    {
                        MessageBox.Show("Satıcı Bilgisi Duzenlendi", "Satici Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatagridviewOwners();
                        displayOwnersCount();
                    }
                    else
                    {
                        MessageBox.Show("Satıcı Bilgisi Duzenlenemedi", "Satici Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Satıcı Ad Soyad Telefon Giriniz", "Satici Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                    MessageBox.Show("Satici Id Hatali","Satici Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //Seçtiğimizi sileceğiz
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if(person.deletePerson("property_owner", id))
                {
                    MessageBox.Show("Satıcı Silindi", "Satici Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridviewOwners();
                    displayOwnersCount();

                    // textboxu sil
                    textBoxID.Text = "";
                    textBoxFName.Text = "";
                    textBoxLName.Text = "";
                    textBoxPhone.Text = "";
                    textBoxEmail.Text = "";
                    textBoxAddres.Text = "";
                }
                else
                {
                    MessageBox.Show("Satıcı Silinemedi", "Satici Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Satici Id Hatali", "Satici Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


        public void LoadDatagridviewOwners()
        {
            
            person = new Classes.PERSON();
            dataGridViewOwners.DataSource = person.getAllPersons("property_owner");
        }

        public void displayOwnersCount()
        {
            person = new Classes.PERSON();
            string ownersCount = person.getAllPersons("property_owner").Rows.Count.ToString();
            labelCount.Text = ownersCount + "Satıcı(lar)";
        }
        private void dataGridViewOwners_Click(object sender, EventArgs e)
        {

            textBoxID.Text = dataGridViewOwners.CurrentRow.Cells[0].Value.ToString();
            textBoxFName.Text = dataGridViewOwners.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridViewOwners.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewOwners.CurrentRow.Cells[3].Value.ToString();
            textBoxEmail.Text = dataGridViewOwners.CurrentRow.Cells[4].Value.ToString();
            textBoxAddres.Text = dataGridViewOwners.CurrentRow.Cells[5].Value.ToString();

        }

        
    }
}