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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string komutSatiri = "insert into personeller(personel_isim,personel_soyad,personel_cins,personel_sifre,personel_dgmtrh,personel_mail,personel_telno,personel_branş,personel_maas,personel_mezun)values(@pisim,@psoyad,@cins,@psifre,@dgmtrh,@mail,@telNo,@branş,@maaş,@mezun)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@pisim", textpa.Text);
                ekle.Parameters.AddWithValue("@psoyad", textsoya.Text);
                ekle.Parameters.AddWithValue("@cins", combopci.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@psifre", textpsifr.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskedpdgmtr.Text);
                ekle.Parameters.AddWithValue("@mail", textpmai.Text);
                ekle.Parameters.AddWithValue("@telNo", textpteln.Text);
                ekle.Parameters.AddWithValue("@branş", comboBran.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@maaş", textpmaa.Text);
                ekle.Parameters.AddWithValue("@mezun", comboBox.SelectedItem.ToString());
                MessageBox.Show("Yeni Personelimiz Hayırlı Olsun Müdür Bey", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ekle.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                
            }
            finally
            { baglanti.Close(); }
        }

        public void listele()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from personeller";
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




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textpa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textsoya.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            combopci.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textpsifr.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedpdgmtr.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textpteln.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textpmai.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBran.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textpmaa.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox.SelectedItem = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string komutSatiri = "insert into duyurular(duyuru_tarihi,duyuru)values(@dyrtrh,@duyuru)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@@duyuru", richTextBox1.Text);
                ekle.Parameters.AddWithValue("@dyrtrh", maskedTextBox1.Text);
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
                string komut_satiri = "select * from duyurular";
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
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listel();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from duyurular WHERE duyuru = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", richTextBox1.Text);
                komut.ExecuteNonQuery();
                listel();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Eleman İşten Kovuldu Müdür Bey", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from personeller WHERE personel_mail = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", textpmai.Text);
                komut.ExecuteNonQuery();
                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            liste();
        }
        public void liste()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from musteri_kayıt";
                MySqlDataAdapter dataataptor = new MySqlDataAdapter(komut_satiri, baglanti);
                DataTable datatablo = new DataTable();
                dataataptor.Fill(datatablo);
                dataGridView3.DataSource = datatablo;
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşterinin Kaydı Silindi Müdür Bey", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from musteri_kayıt WHERE Musteri_id = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", label2.Text);
                komut.ExecuteNonQuery();
                liste();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelodano.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
        }
        public void list()
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
                dataGridView4.DataSource = datatablo;
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
        private void button11_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Müşterinin Siparişi Gönderilidi Müdür Bey", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from musteri_hizmet WHERE oda_no = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", labelodano.Text);
                komut.ExecuteNonQuery();
                list();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }
        public void lis()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from tbl_patron";
                MySqlDataAdapter dataataptor = new MySqlDataAdapter(komut_satiri, baglanti);
                DataTable datatablo = new DataTable();
                dataataptor.Fill(datatablo);
                dataGridView5.DataSource = datatablo;
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
        private void button9_Click(object sender, EventArgs e)
        {
            lis();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labeltrh.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patronun Siparişi Gönderildi Müdür Bey", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from tbl_patron WHERE id = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", labeltrh.Text);
                komut.ExecuteNonQuery();
                lis();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            DialogResult sonuc = new DialogResult();
            sonuc = MessageBox.Show("Çıkmak istediğine Eminmisin Müdür Bey Kaydetmediğin Veriler Silinebilir", "Kekeçoğlu Otel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Form4 c = new Form4();
                this.Hide();
                c.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "update personeller set personel_isim=@ad,personel_soyad=@soyad,personel_sifre=@sifre,personel_dgmtrh=@dgmtrh,personel_mail=@Mail,personel_telno=@TelNo,personel_branş=@Brans,personel_maas=@Maas,personel_mezun=@Mezun where personel_cins=@cins ";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@ad", textpa.Text);
                ekle.Parameters.AddWithValue("@soyad", textsoya.Text);
                ekle.Parameters.AddWithValue("@cins", combopci.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@sifre", textpsifr.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskedpdgmtr.Text);
                ekle.Parameters.AddWithValue("@mail", textpmai.Text);
                ekle.Parameters.AddWithValue("@telNo", textpteln.Text);
                ekle.Parameters.AddWithValue("@Brans", comboBran.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@maas", textpmaa.Text);
                ekle.Parameters.AddWithValue("@mezun", comboBox.SelectedItem.ToString());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellenmiştir", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }
    }
}
    

