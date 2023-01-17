using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace visualprogrammingfinalemlak.Forms
{
    public partial class DovizKurlari : Form
    {
        public DovizKurlari()
        {
            InitializeComponent();
        }
        WebClient c = new WebClient(); //json apilerin yüklenmesini sağlayan sınıfımız

        public class jsonData
        {
            public string buying { get; set; }

            public string selling { get; set; }

            public string latest { get; set; }

            public string change_rate { get; set; }
        }
        public void DovizGoster()
        {
            string doviz = c.DownloadString("https://kur.doviz.com/");
            JArray dovizDizi = JArray.Parse(doviz);
            jsonData dolarNesne = JsonConvert.DeserializeObject<jsonData>(dovizDizi[0].ToString());
            jsonData euroNesne = JsonConvert.DeserializeObject<jsonData>(dovizDizi[1].ToString());
            lblDolar.Text = Math.Round(Decimal.Parse(dolarNesne.buying.Replace(".", ",")), 4).ToString();
            lblDolarOran.Text = "%" + Math.Round(Decimal.Parse(dolarNesne.change_rate.Replace(".", ",")), 4).ToString();
            decimal dolarOran = Math.Round(Decimal.Parse(dolarNesne.change_rate.Replace(".", ",")), 4);
           /* if (dolarOran > 0)
            {
                pbDolar.Image = DurumResim.Images[0];
            }
            else
            {
                pbDolar.Image = DurumResim.Images[1];
            }*/
            decimal euroOran = Math.Round(Decimal.Parse(euroNesne.change_rate.Replace(".", ",")), 4);
           /* if (euroOran>0)
            {
                pbEuro.Image = DurumResim.Images[1];
            }
            else
            {
                pbEuro.Image = DurumResim.Images[1];
            }*/
            lblEuro.Text = Math.Round(Decimal.Parse(euroNesne.buying.Replace(".", ",")), 4).ToString();
            lblEuroOran.Text = "%" + Math.Round(Decimal.Parse(euroNesne.change_rate.Replace(".", ",")), 4).ToString();
        }

        public void AltinGoster()
        {
            string altin = c.DownloadString("https://altin.doviz.com/");
            JArray altinDizi = JArray.Parse(altin);
            jsonData altinNesne = JsonConvert.DeserializeObject<jsonData>(altinDizi[1].ToString());
            decimal altinOran = Math.Round(Decimal.Parse(altinNesne.change_rate.Replace(".", ",")), 4);
            /*if(altinOran > 0)
            {
                pbAltin.Image = DurumResim.Images[0];
            }
            else
            {
                pbAltin.Image = DurumResim.Images[1];
            }*/
            lblAltin.Text = Math.Round(Decimal.Parse(altinNesne.buying.Replace(".", ",")), 4).ToString();
            lblAltinOran.Text = "%" + Math.Round(Decimal.Parse(altinNesne.change_rate.Replace(".", ",")), 4).ToString();
        }

        public void BistGoster()
        {
            string borsa = c.DownloadString("https://borsa.doviz.com/");
            jsonData borsaNesne = JsonConvert.DeserializeObject<jsonData>(borsa);
            decimal BistOran = Math.Round(Decimal.Parse(borsaNesne.change_rate.Replace(".", ",")), 4);
            /*if (BistOran > 0)
            {
                pbBist.Image = DurumResim.Images[0];
            }
            else
            {
                pbBist.Image = DurumResim.Images[1];
            }*/
            lblBist.Text = string.Format("{0:0,0,0}", Convert.ToDecimal(borsaNesne.latest.Replace(".", ",")));
            lblBistOran.Text = "%" + Math.Round(Decimal.Parse(borsaNesne.change_rate.Replace(".", ",")), 4).ToString();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DovizKurlari_Load(object sender, EventArgs e)
        {
            DovizGoster();
            AltinGoster();
            BistGoster();
        }
    }
}
