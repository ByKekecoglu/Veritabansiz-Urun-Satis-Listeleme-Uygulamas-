using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Proje
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 z = new Form1();
            this.Hide();
            z.Show();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string kad = textBox1.Text;
                string sifre = textBox2.Text;

                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutsatir = "SELECT * FROM patron WHERE Mudur_ismi=@kullanici_ad AND Mudur_sifre =@sifre";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@kullanici_ad", kad);
                komut.Parameters.AddWithValue("@sifre", sifre);
                int count = Convert.ToInt32(komut.ExecuteScalar());

                
                string countStr = count.ToString();

               


                if (count > 0)
                {
                    MessageBox.Show("Giriş Başarılı Müdür", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Form7 abc = new Form7();
                    abc.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Giriş Başarısız", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally
            { baglanti.Close(); }
        }
    }   
}
