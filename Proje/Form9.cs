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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public void listele()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from duyurular";
                MySqlDataAdapter dataataptor = new MySqlDataAdapter(komut_satiri, baglanti);
                DataTable datatablo = new DataTable();
                dataataptor.Fill(datatablo);
                dataGridView1.DataSource = datatablo;
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
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string komutSatiri = "insert into musteri_hizmet(İstek_Tarihi,İcecek,icecek_sayisi,Yemek,yemek_sayisi,Not_ekstrahizmet,oda_no)values(@İtarihi,@icecek,@iceceksayi,@yemek,@yemeksayi,@Not,@odano)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@İtarihi", maskedTextBox2.Text);
                ekle.Parameters.AddWithValue("@yemek", comboyemek.SelectedItem);
                ekle.Parameters.AddWithValue("@yemeksayi", yemeksy.Value);
                ekle.Parameters.AddWithValue("@icecek", comboicecek.SelectedItem);
                ekle.Parameters.AddWithValue("@iceceksayi", iceceksy.Value);
                ekle.Parameters.AddWithValue("@odano", comboodaNo.SelectedItem);
                ekle.Parameters.AddWithValue("@Not", richTextBox2.Text);
                ekle.ExecuteNonQuery();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally
            { baglanti.Close(); }
        }
        public void listel()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from musteri_hizmet";
                MySqlDataAdapter dataataptor = new MySqlDataAdapter(komut_satiri, baglanti);
                DataTable datatablo = new DataTable();
                dataataptor.Fill(datatablo);
                dataGridView2.DataSource = datatablo;
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
        private void button3_Click(object sender, EventArgs e)
        {
            listel();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult sonuc = new DialogResult();
            sonuc = MessageBox.Show("Çıkmak istediğine Eminmisin Sevgili Müşterimiz Kaydetmediğin Veriler Silinebilir", "Kekeçoğlu Otel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Form2 c = new Form2();
                this.Hide();
                c.Show();
            }
        }
    }
}
