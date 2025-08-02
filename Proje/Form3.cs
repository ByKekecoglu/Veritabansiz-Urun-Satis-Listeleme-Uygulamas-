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
namespace Proje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.Show();
        }
      
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        Dictionary<string, decimal> vipOdaFiyatlari = new Dictionary<string, decimal>()
{
    { "1 vip", 1000 },
    { "2 vip", 1000 },
    { "3 vip", 1000 },
    { "4 vip", 1000 },
    { "5 vip", 1000 },
    { "6 vip", 1000 }
};

        Dictionary<string, decimal> kisiBasiOdaFiyatlari = new Dictionary<string, decimal>()
{
    { "1", 450 },
    { "2", 450 },
    { "3", 450 },
    { "4", 450 },
    { "5", 450 },
    { "6", 450 },
    { "7", 450 },
    { "8", 450 },
    { "9", 450 },
    { "10", 450 }
};

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenOda = comboBox1.SelectedItem.ToString();
            decimal fiyat = 0;

            if (secilenOda.EndsWith("vip"))
            {
                if (vipOdaFiyatlari.ContainsKey(secilenOda))
                {
                    fiyat = vipOdaFiyatlari[secilenOda];
                }
            }
            else
            {
                if (kisiBasiOdaFiyatlari.ContainsKey(secilenOda))
                {
                    fiyat = kisiBasiOdaFiyatlari[secilenOda];
                }
            }

            numericUpDown2.Enabled = true;
            numerickisisayı.Enabled = true;

            int kisiSayisi = (int)numerickisisayı.Value;
            int geceSayisi = (int)numericUpDown2.Value;
            decimal toplamFiyat = (fiyat * kisiSayisi * geceSayisi) + 400;

            labelfiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C");
        }





        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult sonuc;
            sonuc = MessageBox.Show(" İşlemi Tamamlamak İstediğinize Eminmisiniz?", "Kekeçoğlu Otel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");

                try
                {
                    baglanti.Open();
                    string komutSatiri = "insert into musteri_kayıt(Musteri_ad,Musteri_soyad,Musteri_tel_no,Musteri_mail,Musteri_odaNo,Musteri_gecelik,Musteri_fiyat,Musteri_giris_sifre,Musteri_gelecegi_tarih,Musteri_kisi_sayisi)values(@Ad,@Soyad,@TelNo,@Mail,@OdaNo,@Gecelik,@Fiyat,@GirisSifre,@GelecegiTarih,@KisiSayisi)";
                    MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                    ekle.Parameters.AddWithValue("@Ad", textad.Text);
                    ekle.Parameters.AddWithValue("@Soyad", textsoyad.Text);
                    ekle.Parameters.AddWithValue("@Fiyat", labelfiyat.Text);
                    ekle.Parameters.AddWithValue("@Mail", textmail.Text);
                    ekle.Parameters.AddWithValue("@TelNo", texttelno.Text);
                    ekle.Parameters.AddWithValue("@GirisSifre", textgirissifre.Text);
                    ekle.Parameters.AddWithValue("@GelecegiTarih", maskedtarih.Text);
                    ekle.Parameters.AddWithValue("@KisiSayisi", numerickisisayı.Value);
                    ekle.Parameters.AddWithValue("@Gecelik", numericUpDown2.Value);
                    ekle.Parameters.AddWithValue("@OdaNo", comboBox1.SelectedItem);
                    ekle.Parameters.AddWithValue("@GelecegiT", maskedtarih.Text);
                    ekle.ExecuteNonQuery();

                    Form8 a = new Form8();
                    this.Hide();
                    a.Show();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());

                }
                finally
                {
                    baglanti.Close();
                }

            }
        }

           

       

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("6");
            comboBox1.Items.Add("7");
            comboBox1.Items.Add("8");
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("1 vip");
            comboBox1.Items.Add("2 vip");
            comboBox1.Items.Add("3 vip");
            comboBox1.Items.Add("4 vip");
            comboBox1.Items.Add("5 vip");
            comboBox1.Items.Add("6 vip");

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
