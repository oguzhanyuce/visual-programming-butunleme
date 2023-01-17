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
    public partial class ThePropertyForm : Form
    {
        public ThePropertyForm()
        {
            InitializeComponent();
        }

        Classes.THE_PROPERTY property = new Classes.THE_PROPERTY();

        private void ThePropertyForm_Load(object sender, EventArgs e)
        {
             // combobox emlak tipi gosterme
            Classes.PROPERTY_TYPE pType = new Classes.PROPERTY_TYPE();
            comboBoxType.DataSource = pType.getAllTypes();
            comboBoxType.DisplayMember = "name";
            //comboBoxType.ValueMember = "id";
        }

        //yeni emlak ekleme
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(comboBoxType.SelectedValue.ToString());
                int owner = Convert.ToInt32(textBoxOwner.Text);
                int size = Convert.ToInt32(textBoxSize.Text);
                string price = textBoxPrice.Text;
                string address = textBoxAddress.Text;
                string comment = textBoxComment.Text;
                int bedrooms = (int)numericUpDownBedrooms.Value;
                int bathrooms = (int)numericUpDownBathrooms.Value;
                int age = (int)numericUpDownAge.Value;

                Boolean hasBalcony = checkBoxBalcony.Checked;
                Boolean hasBackyard = checkBoxBackyard.Checked;
                Boolean hasGarage = checkBoxGarage.Checked;
                Boolean hasPool = checkBoxPool.Checked;
                Boolean hasFireplace = checkBoxFireplace.Checked;

                //  MessageBox.Show(" *Balcony - " + hasBalcony + " *Backyard - " + hasBackyard + " *Garage - " + hasGarage + " *Pool - " + hasPool + " *Fireplace - " + hasFireplace);
                if (verifTextBoxes())
                {
                    if (property.insertProperty(new Classes.THE_PROPERTY(0, type, owner, size, age, bedrooms, bathrooms, address, price, comment, hasBalcony, hasBackyard, hasGarage, hasFireplace, hasPool)))
                    {
                        MessageBox.Show("Yeni Emlak Eklendi", "Emlak Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yeni Emlak Eklenemedi", "Emlak Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Gerekli Yerleri Doldurunuz(size-    address -   price   )", "Emlak Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Emlak Eklenirken Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        //secilen emlağı düzenle
        private void buttonEdit_Click(object sender, EventArgs e)
        {
          
        }

        // secilen emlağı sil
        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        // tüm emlakları yeni formda göster
        private void buttonShowAllProperties_Click(object sender, EventArgs e)
        {

        }

        // seçilen emlak resimlerini yeni formda göster
        private void buttonShowPropertyImages_Click(object sender, EventArgs e)
        {

        }

        //emlağı idsine göre ara
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // emlak id getir
            int id = Convert.ToInt32(textBoxID.Text);
            // emlak datasını id ye göre getir
            DataTable propertyData = property.getPropertyById(id);

            //emlak bilgilerini göster
            textBoxOwner.Text = propertyData.Rows[0]["ownerid"].ToString();
            textBoxSize.Text = propertyData.Rows[0]["square_feet"].ToString();
            textBoxPrice.Text = propertyData.Rows[0]["price"].ToString();
            textBoxAddress.Text = propertyData.Rows[0]["address"].ToString();
            textBoxComment.Text = propertyData.Rows[0]["comment"].ToString();
            comboBoxType.SelectedValue = propertyData.Rows[0]["type"];
            numericUpDownAge.Value = Convert.ToDecimal (propertyData.Rows[0]["age"]);
            numericUpDownBedrooms.Value = Convert.ToDecimal(propertyData.Rows[0]["bedrooms"]);
            numericUpDownBathrooms.Value = Convert.ToDecimal(propertyData.Rows[0]["bathrooms"]);
            checkBoxBalcony.Checked = (bool)propertyData.Rows[0]["balcony"];
            checkBoxBackyard.Checked = (bool)propertyData.Rows[0]["backyard"];
            checkBoxGarage.Checked = (bool)propertyData.Rows[0]["garage"];
            checkBoxFireplace.Checked = (bool)propertyData.Rows[0]["fireplace"];
            checkBoxPool.Checked = (bool)propertyData.Rows[0]["pool"];
        }

        // yeni form aç satıcıyı seç
        private void buttonSelectOwner_Click(object sender, EventArgs e)
        {
            OwnersListForm ownersForm = new OwnersListForm();
            ownersForm.ShowDialog();

            textBoxOwner.Text = ownersForm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        public bool verifTextBoxes()
        {
            string size = textBoxSize.Text.Trim();
            string price = textBoxPrice.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            if (size.Equals("") || price.Equals("") || address.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
