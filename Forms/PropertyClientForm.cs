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
using System.Data;

namespace visualprogrammingfinalemlak.Forms
{
    public partial class PropertyClientForm : Form
    {
        public PropertyClientForm()
        {
            InitializeComponent();
        }

        Classes.PERSON person = new Classes.PERSON();

        private void PropertyClientForm_Load(object sender, EventArgs e)
        {
            LoadDatagridviewClients();

            //satıcıların sayısını göster
            displayClientsCount();
        }


        //yeni müşteri ekle
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

                if (person.insertPerson("property_client", person))
                {
                    MessageBox.Show("Yeni Müşteri Eklendi", "Müşteri Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridviewClients();
                    displayClientsCount();
                }
                else
                {
                    MessageBox.Show("Müşteri Eklenemedi", "Müşteri Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Müşteri Ad Soyad Telefon Giriniz", "Müşteri Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (verifTextBoxes())
                {
                    if (person.updatePerson("property_client", new Classes.PERSON(id, fname, lname, phone, email, address)))
                    {
                        MessageBox.Show("Müşteri Bilgisi Duzenlendi", "Müşteri Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatagridviewClients();
                        displayClientsCount();
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Bilgisi Duzenlenemedi", "Müşteri Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri Ad Soyad Telefon Giriniz", "Müşteri Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                //MessageBox.Show("Müşteri Id Hatali", "Müşteri Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Müşteri Bilgisi Duzenlendi", "Müşteri Duzenle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDatagridviewClients();
                displayClientsCount();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if (person.deletePerson("property_client", id))
                {
                    MessageBox.Show("Müşteri Silindi", "Müşteri Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridviewClients();
                    displayClientsCount();

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
                    MessageBox.Show("Müşteri Silinemedi", "Müşteri Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                //MessageBox.Show("Müşteri Id Hatali", "Müşteri Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Müşteri Silindi", "Müşteri Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDatagridviewClients();
                displayClientsCount();
            }
        }

       

        private void dataGridViewClients_Click(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridViewClients.CurrentRow.Cells[0].Value.ToString();
            textBoxFName.Text = dataGridViewClients.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridViewClients.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewClients.CurrentRow.Cells[3].Value.ToString();
            textBoxEmail.Text = dataGridViewClients.CurrentRow.Cells[4].Value.ToString();
            textBoxAddres.Text = dataGridViewClients.CurrentRow.Cells[5].Value.ToString();
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

        public void LoadDatagridviewClients()
        {


            dataGridViewClients.DataSource = person.getAllPersons("property_client");
        }

        public void displayClientsCount()
        {

            string clientsCount = person.getAllPersons("property_client").Rows.Count.ToString();
            labelCount.Text = clientsCount + "Müşteri(ler)";
        }
    }
}
