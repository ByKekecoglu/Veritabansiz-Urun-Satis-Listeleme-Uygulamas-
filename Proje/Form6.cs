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
    public partial class patronpaneli : Form
    {
        public patronpaneli()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;Port=3306;Database=otel;Uid= root;Pwd=12345");
        private void patronpaneli_Load(object sender, EventArgs e)
        {

        }

        private void patronpaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "insert into patron(Mudur_ismi,Mudur_soyad,Mudur_dgmtrh,Mudur_Mail,Mudur_sifre,Mudur_maas,Mudur_cins)values(@isim,@soyad,@dgmtrh,@Mail,@Sifre,@Maas,@Cins)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@isim", textad.Text);
                ekle.Parameters.AddWithValue("@soyad", textsoyad.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskeddgmtrh.Text);
                ekle.Parameters.AddWithValue("@Mail", textmail.Text);
                ekle.Parameters.AddWithValue("@Sifre", textsifre.Text);
                ekle.Parameters.AddWithValue("@Maas", textmaas.Text);
                ekle.Parameters.AddWithValue("@Cins", combocins.SelectedItem.ToString());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı Patron Yeni Müdürümüz Hayırlı Olsun","Kekeçoğlu Otel",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                throw;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void listele()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komut_satiri = "select * from patron";
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

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = new DialogResult();
           sonuc=MessageBox.Show("Çıkmak istediğine Eminmisin Patron Kaydetmediğin Veriler Silinebilir","Kekeçoğlu Otel",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Asterisk);
          
            if (sonuc == DialogResult.Yes)
            {
                Form5 c = new Form5();
                this.Hide();
                c.Show();
            }

        }

        public void liste()
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




        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskeddgmtrh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textmaas.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           textsifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            combocins.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();




        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eleman İşten Kovuldu Patron","Kekeçoğlu Otel",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from patron WHERE Mudur_ismi = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", textad.Text);
                komut.ExecuteNonQuery();
                listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "insert into duyurular(duyuru_tarihi,duyuru)values(@dyrtrh,@duyuru)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@@duyuru", richTextBox1.Text);
                ekle.Parameters.AddWithValue("@dyrtrh", maskedTextBox1.Text);
                ekle.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                throw;
            }
            finally
            { baglanti.Close(); }
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listel();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void personelkayit_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string komutSatiri = "insert into personeller(personel_isim,personel_soyad,personel_cins,personel_sifre,personel_dgmtrh,personel_mail,personel_telno,personel_branş,personel_maas,personel_mezun)values(@pisim,@psoyad,@cins,@psifre,@dgmtrh,@mail,@telNo,@branş,@maaş,@mezun)";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@pisim", textpad.Text);
                ekle.Parameters.AddWithValue("@psoyad", textpsoyad.Text);
                ekle.Parameters.AddWithValue("@cins", combopcins.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@psifre", textpsifre.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskedpdgmtrh.Text);
                ekle.Parameters.AddWithValue("@mail", textpmail.Text);
                ekle.Parameters.AddWithValue("@telNo", textptelno.Text);
                ekle.Parameters.AddWithValue("@branş", comboBrans.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@maaş", textpmaas.Text);
                ekle.Parameters.AddWithValue("@mezun", comboBox1.SelectedItem.ToString());

                ekle.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
               
            }
            finally
            { baglanti.Close(); }
        }

        private void personellistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void pistenkov_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eleman İşten Kovuldu Patron", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from personeller WHERE personel_sifre = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", textpsifre.Text);
                komut.ExecuteNonQuery();
                liste();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textpad.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textpsoyad.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            combopcins.SelectedItem = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textpsifre.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            maskedpdgmtrh.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            textptelno.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            textpmail.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            comboBrans.SelectedItem = dataGridView3.CurrentRow.Cells[8].Value.ToString();
            textpmaas.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString();
            comboBox1.SelectedItem=dataGridView3.CurrentRow.Cells[10].Value.ToString();

        }

        private void mguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "update patron set Mudur_ismi=@ismi, Mudur_soyad=@soyad,Mudur_dgmtrh=@dgmtrh,Mudur_Mail=@Mail,Mudur_sifre=@Sifre,Mudur_maas=@Maas Where Mudur_cins=@Cins  ";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@ismi", textad.Text);
                ekle.Parameters.AddWithValue("@soyad", textsoyad.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskeddgmtrh.Text);
                ekle.Parameters.AddWithValue("@Mail", textmail.Text);
                ekle.Parameters.AddWithValue("@Sifre", textsifre.Text);
                ekle.Parameters.AddWithValue("@Maas", textmaas.Text);
                ekle.Parameters.AddWithValue("@Cins", combocins.SelectedItem.ToString());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellenmiştir", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                listele();
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from personeller WHERE duyuru_tarihi = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", maskedTextBox1.Text);
                komut.ExecuteNonQuery();
                listel();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }
        public void list()
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
        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            list();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşterinin Kaydı Silindi Patron", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string komutsatir = "DELETE  from musteri_kayıt WHERE Musteri_id = @isim ";
                MySqlCommand komut = new MySqlCommand(komutsatir, baglanti);
                komut.Parameters.AddWithValue("@isim", labelid.Text);
                komut.ExecuteNonQuery();
                list();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelid.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                 if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "update personeller set personel_isim=@ad,personel_soyad=@soyad,personel_sifre=@sifre,personel_dgmtrh=@dgmtrh,personel_mail=@Mail,personel_telno=@TelNo,personel_branş=@Brans,personel_maas=@Maas,personel_mezun=@Mezun where personel_cins=@cins ";
                MySqlCommand ekle = new MySqlCommand(komutSatiri, baglanti);
                ekle.Parameters.AddWithValue("@ad", textpad.Text);
                ekle.Parameters.AddWithValue("@soyad", textpsoyad.Text);
                ekle.Parameters.AddWithValue("@cins", combopcins.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@sifre", textpsifre.Text);
                ekle.Parameters.AddWithValue("@dgmtrh", maskedpdgmtrh.Text);
                ekle.Parameters.AddWithValue("@mail", textpmail.Text);
                ekle.Parameters.AddWithValue("@telNo", textptelno.Text);
                ekle.Parameters.AddWithValue("@Brans", comboBrans.SelectedItem.ToString());
                ekle.Parameters.AddWithValue("@maas", textpmaas.Text);
                ekle.Parameters.AddWithValue("@mezun", comboBox1.SelectedItem.ToString());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellenmiştir", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                listel();
            }
            catch ( Exception hata)
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
            lis();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşterinin Siparişi Gönderilidi Patron", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                lis();
                MessageBox.Show("Müşterinin Kaydı Sonlandırıldı Patron","Kekeçoğlu Otel",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                string komutSatiri = "insert into tbl_patron(istek_tarih,yemek,yemek_adet,icecek,icecek_adet,notu)values(@i_Tarih,@Yemek,@Yemek_adet,@İcicek,@İcecek_adet,@Notu)";
                MySqlCommand ekl = new MySqlCommand(komutSatiri, baglanti);
                ekl.Parameters.AddWithValue("@i_Tarih", maskedptrh.Text);
                ekl.Parameters.AddWithValue("@Yemek", combopyemek.SelectedItem);
                ekl.Parameters.AddWithValue("@Yemek_adet", numericyemek.Value);
                ekl.Parameters.AddWithValue("@İcicek", comboicecek.SelectedItem);
                ekl.Parameters.AddWithValue("@İcecek_adet", numericicecek.Value);
                ekl.Parameters.AddWithValue("@Notu", richnot.Text);
                ekl.ExecuteNonQuery();
                MessageBox.Show("İstekleriniz Müdür Bey'e İletilmiştir Patron","Kekeçoğlu Otel",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally { baglanti.Close(); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            li();
        }
        public void li()
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
                dataGridView6.DataSource = datatablo;
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
}
