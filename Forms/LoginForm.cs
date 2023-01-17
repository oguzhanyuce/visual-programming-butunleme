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
    public partial class LoginForm : Form
    {
        Classes.DB_CONNECTION baglantı = new Classes.DB_CONNECTION();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (checkfields());
            {
                try
                {


                    baglantı.connection.Open();
                    DataTable dt = new DataTable();
                    // baglantı.adapter = new MySqlDataAdapter("SELECT username,password FROM users WHERE username="+username+" AND password='"+password+"'",baglantı.connection);
                    //baglantı.cmd.Parameters.AddWithValue("@un",username);
                    // baglantı.cmd.Parameters.AddWithValue("@pass", password);
                    // baglantı.cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT username,password FROM users WHERE username='"+username+"' AND password='"+password+"'", baglantı.connection);
               // baglantı.adapter = new MySqlDataAdapter(Convert.ToString(baglantı.cmd),baglantı.connection);
                    adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    labelErrorMessage.Visible = true;

                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(""+ex);
                    throw;
                }
            }

        }

        // şifre ve kullanıcı adı boşsa kontrol et
        public Boolean checkfields()
        {

            labelPasswordAstri.Visible = false;
            labelUsernameAstri.Visible=false;
            
            if (textBoxUsername.Text.Trim().Equals("") && textBoxPassword.Text.Trim().Equals(""))
            {
                labelUsernameAstri.Visible = true;
                labelPasswordAstri.Visible = true;
                return false;
            }


            else if (textBoxUsername.Text.Trim().Equals(""))
            {
                labelUsernameAstri.Visible = true;
                return false;

            }
            else if (textBoxPassword.Text.Trim().Equals(""))
            {
                labelPasswordAstri.Visible = true;
                return false;
            }           
            else


            {
                return true;
            }
        }

      
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;
        }
    }

    }

