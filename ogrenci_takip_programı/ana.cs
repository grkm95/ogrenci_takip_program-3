using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient; //SQL İÇİN GEREKLİ OLAN KÜTÜPHANE

namespace ogrenci_takip_programı
{
    public partial class ana : Form
    {
        public ana()
        {
            InitializeComponent();
        }
        //SQL BAĞLANTI KOMUTU
        SqlConnection bag = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=veriler;Integrated Security=True");
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text; //kullanıcı adı girdisi
            string kSifre = textBox2.Text;//kullanıcı şifre girdisi
            SqlCommand kmt = new SqlCommand("select count (*) from kGiris where kAdi=@kAdi and kSifre=@kSifre", bag); //kullanıcı adı ve şifre sorgulama
            kmt.Parameters.AddWithValue("@kAdi", kAdi);
            kmt.Parameters.AddWithValue("@kSifre", kSifre);
            bag.Open(); //bağlantı açıldı
            int sonuc = int.Parse(kmt.ExecuteScalar().ToString());
            bag.Close(); //bağlantı kapandı
            if (sonuc == 0) // eşlemeler yanlışsa tekrar girdi yapılacak
            {
                MessageBox.Show("Bilgilerinizi kontrol ediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else// doğruysa diğer form a geçiş yapacak.
            {
                this.Hide();//bu formu sakla
                Form1 frm1 = new Form1();
                frm1.Show();//form1 göster
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ana_Load(object sender, EventArgs e)
        {

        }
    }
}