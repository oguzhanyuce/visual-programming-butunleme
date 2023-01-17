using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualprogrammingfinalemlak
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Forms.LoginForm loginF = new Forms.LoginForm();
            
            if(loginF.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Forms.MainForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
