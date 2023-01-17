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

namespace visualprogrammingfinalemlak.Forms
{
    public partial class OwnersListForm : Form
    {
        public OwnersListForm()
        {
            InitializeComponent();
        }

        private void OwnersListForm_Load(object sender, EventArgs e)
        {
            Classes.FUNC func = new Classes.FUNC();
            MySqlCommand command = new MySqlCommand("SELECT `id`, `first_name`, `last_name` FROM `property_owner`");
            dataGridView1.DataSource = func.getData(command);


            dataGridView1.ClearSelection();
        }

        //bu formu iki kere tıklayınca kapat
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
