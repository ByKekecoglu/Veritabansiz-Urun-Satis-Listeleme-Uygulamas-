using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 v = new Form1();
            this.Hide();
            v.Show();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
                string komutsatir = "SELECT * FROM musteri_kayıt WHERE Musteri_ad=@kullanici_ad AND Musteri_giris_sifre=@sifre";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@kullanici_ad", kad);
                komut.Parameters.AddWithValue("@sifre", sifre);
                int count = Convert.ToInt32(komut.ExecuteScalar());


                string countStr = count.ToString();




                if (count > 0)
                {
                    MessageBox.Show("Giriş Başarılı Sevgili Müşterimiz", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Form9 abc = new Form9();
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

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
