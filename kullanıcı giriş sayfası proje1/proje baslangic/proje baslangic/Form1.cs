using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proje_baslangic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış işlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=vt.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kad,sifre from kullanici where kad=@ad and sifre=@sifre", baglanti);

            sorgu.Parameters.AddWithValue("@kad", textBox1.Text);
            sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
            OleDbDataReader dr;
            dr= sorgu.ExecuteReader();





        }
    }
}
