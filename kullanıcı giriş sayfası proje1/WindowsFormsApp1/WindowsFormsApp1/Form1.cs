using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış işlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=vt.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kad,sifre from kullanici where kad=@kad and sifre=@sifre", baglanti);

            sorgu.Parameters.AddWithValue("@kad", textBox1.Text);
            sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();


            if (dr.Read())
            {
                    if (guvenlikk == Convert.ToInt32(textBox3.Text))
                    {
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik kodunu yanlış girdiniz tekrar deneyin");
                    }
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Kullanıcı adı veya parola hatalı lütfen tekrar deneyiniz.");
            }

              }
            catch
            {
                MessageBox.Show("Hatalı giriş yaptınız lütfen kullanıcı adı veya parola ile giriş yapınız.");
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        int guvenlikk;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            guvenlikk=r.Next(1000,9998);
            label4.Text = guvenlikk.ToString();




        }
    }
}
