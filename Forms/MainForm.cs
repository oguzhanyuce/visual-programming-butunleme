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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelAppName.Text = "Emlak\r\nYonetim\r\nUygulamasi";
            
            panel1.Height = this.Height;
        }

        private void buttonGoToPropertyTypesForm_Click(object sender, EventArgs e)
        {
            PropertyTypesForm propTypeF = new PropertyTypesForm();
            propTypeF.Show();
        }

        private void buttonGoToOwnerForm_Click(object sender, EventArgs e)
        {
            PropertyOwnerForm propOwnerF = new PropertyOwnerForm();
            propOwnerF.Show();
        }

        private void buttonGoToClientForm_Click(object sender, EventArgs e)
        {
            PropertyClientForm propClientF = new PropertyClientForm();
            propClientF.Show();
        }

        private void buttonGoToPropertyForm_Click(object sender, EventArgs e)
        {
            ThePropertyForm propertyF = new ThePropertyForm();
            propertyF.Show();

        }
    }
}
