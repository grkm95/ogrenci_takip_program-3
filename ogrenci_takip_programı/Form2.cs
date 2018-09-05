using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ogrenci_takip_programı
{
    public partial class Form2 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=veriler;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }
     
        private void veri_oku()
        {

            SqlCommand veri = new SqlCommand("select * from kimlik", baglan);
                SqlDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                listView2.Items.Clear();
                while (oku.Read())
                {
                    ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                    kayit.SubItems.Add(oku["ogrno"].ToString());
                    kayit.SubItems.Add(oku["adi"].ToString());
                    kayit.SubItems.Add(oku["sadi"].ToString());
                    kayit.SubItems.Add(oku["dyeri"].ToString());
                    kayit.SubItems.Add(oku["dtarihi"].ToString());
                    kayit.SubItems.Add(oku["sinif"].ToString());
                    kayit.SubItems.Add(oku["anneadi"].ToString());
                    kayit.SubItems.Add(oku["babaadi"].ToString());
                    kayit.SubItems.Add(oku["tel"].ToString());
                    kayit.SubItems.Add(oku["adres"].ToString());
                    listView2.Items.Add(kayit);
                }
                oku.Close();
                baglan.Close();
            
           
        }
        private void veri_kaydet()
        {
            try
            {

                SqlCommand kaydet = new SqlCommand("insert into kimlik (ogrno,adi,sadi,dyeri,dtarihi,sinif,anneadi,babaadi,tel,adres) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "')", baglan);
                baglan.Open(); //bağlantı açılıyor
                kaydet.ExecuteNonQuery();//sql de etkilenen satır sayısını döndürür.
                baglan.Close();//bağlantı kapandı
                veri_oku();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
            catch
            {
                MessageBox.Show("Lütfen Girdiğiniz Bilgileri Kontrol Ediniz...");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            veri_oku();
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            veri_kaydet();
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int a;
                a = int.Parse(listView2.SelectedItems[0].Text);
                SqlCommand sil = new SqlCommand("delete from kimlik where id =" + a + "", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                veri_oku();
            }
            catch
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Veriyi Aşağıdaki Tablodan Seçiniz...");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

        }
        
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.Show();
        }

        
    }
}
