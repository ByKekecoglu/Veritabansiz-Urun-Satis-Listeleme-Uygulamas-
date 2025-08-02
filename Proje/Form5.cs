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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            this.Hide();
            n.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textpatronkad.Text =="admin"&&textpatronsıfre.Text== "12345")
            {
                MessageBox.Show("Giriş Başarılı Patron", "Kekeçoğlu Otel", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                patronpaneli b = new patronpaneli();
                this.Hide();
                b.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(textpatronkad.Text))
            {
                MessageBox.Show("Kullanıcı Adınızı Boş Bırakmayınız", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrEmpty(textpatronsıfre.Text))
            {
                MessageBox.Show("Şifrenizi Boş Bırakmayınız", "Kekeçoğlu Otel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
