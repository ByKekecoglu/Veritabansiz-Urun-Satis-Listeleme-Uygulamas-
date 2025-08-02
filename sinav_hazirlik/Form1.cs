using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace sinav_hazirlik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList urunler = new ArrayList();
        ArrayList satislar = new ArrayList();
        int index;
        class urun
        {
            public string adi { get; set; }
            public string adet { get; set; }
            public string fiyat { get; set; }
        }
        class satis
        {
            public string adi { get; set; }
            public string adet { get; set; }
            public string fiyat { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            urun u = new urun();
            u.adi = uAdiTxt.Text;
            u.adet = uAdetTxt.Text;
            u.fiyat = uFiyatTxt.Text;
            urunler.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satis s = new satis();
            s.adi = sAdiTxt.Text;
            s.adet = sAdetUp.Value.ToString();
            s.fiyat = sFiyatTxt.Text;
            satislar.Add(s);
            urun u = new urun();
            u.adi = sAdiTxt.Text;
            u.adet = (Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)- Convert.ToInt32(sAdetUp.Value)).ToString();
            u.fiyat = (Convert.ToInt32(sFiyatTxt.Text)/Convert.ToInt32(sAdetUp.Value)).ToString();
            urunler.RemoveAt(index);
            urunler.Insert(index, u);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = urunler;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = urunler;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = satislar;
        }

        private void sAdetUp_ValueChanged(object sender, EventArgs e)
        {
            sFiyatTxt.Text = (Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) * Convert.ToInt32(sAdetUp.Value)).ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            sAdiTxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sFiyatTxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
