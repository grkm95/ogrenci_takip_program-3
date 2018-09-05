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
    public partial class Form3 : Form
    {
        int ort;
        string  sonuc;
        SqlConnection baglan = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=veriler;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }
        
        private void sil()
        {
            try
            {
                int a;
                a = int.Parse(listView2.SelectedItems[0].Text);
                SqlCommand sil = new SqlCommand("delete from dersler where id =" + a + "", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                dveri_oku();
            }
            catch
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Dersi Aşağıdaki Tablodan Seçiniz...");
            }
        }
        private void veri_kaydet()
        {
            try
            {
                
                    ort = (int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text) + int.Parse(textBox7.Text) + int.Parse(textBox8.Text)) / 5;
                    if (ort > 45)
                    {
                        sonuc = "Geçti";
                        textBox10.Text = sonuc;

                    }
                    else
                    {

                        sonuc = "Kaldı";
                        textBox10.Text = sonuc;
                        
                    }
                SqlCommand kaydet = new SqlCommand("insert into dersler (dersadi,oadi,osadi,yazili1,yazili2,yazili3,sozlu1,sozlu2,ort,sonuc,ogrno) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + ort + "','" + sonuc + "','" + label11.Text + "')", baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                dveri_oku();

            }
            catch
            {
                MessageBox.Show("Lütfen Bilgilerinizi Kontrol Ediniz...");
            }
        }
        private void veri_oku()
        {

            SqlCommand veri = new SqlCommand("select * from kimlik3", baglan);
            SqlDataReader oku = null;
            baglan.Open();
            oku = veri.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["ogrno"].ToString());
                kayit.SubItems.Add(oku["adi"].ToString());
                kayit.SubItems.Add(oku["sadi"].ToString());
                kayit.SubItems.Add(oku["dyeri"].ToString());
                kayit.SubItems.Add(oku["dtarihi"].ToString());
                kayit.SubItems.Add(oku["sinif"].ToString());
                kayit.SubItems.Add(oku["anneadi"].ToString());
                kayit.SubItems.Add(oku["babaadi"].ToString());
                kayit.SubItems.Add(oku["tel"].ToString());
                kayit.SubItems.Add(oku["adres"].ToString());
                listView1.Items.Add(kayit);
            }
            oku.Close();
            baglan.Close();


        }
        private void dveri_oku()
        {

            SqlCommand veri = new SqlCommand("select * from dersler where ogrno =" + label11.Text, baglan);
            SqlDataReader oku = null;
            baglan.Open();
            oku = veri.ExecuteReader();
            listView2.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["ogrno"].ToString());
                kayit.SubItems.Add(oku["dersadi"].ToString());
                kayit.SubItems.Add(oku["oadi"].ToString());
                kayit.SubItems.Add(oku["osadi"].ToString());
                kayit.SubItems.Add(oku["yazili1"].ToString());
                kayit.SubItems.Add(oku["yazili2"].ToString());
                kayit.SubItems.Add(oku["yazili3"].ToString());
                kayit.SubItems.Add(oku["sozlu1"].ToString());
                kayit.SubItems.Add(oku["sozlu2"].ToString());
                kayit.SubItems.Add(oku["ort"].ToString());
                kayit.SubItems.Add(oku["sonuc"].ToString());
                


                listView2.Items.Add(kayit);
            }
            oku.Close();
            baglan.Close();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand ara = new SqlCommand("Select * from kimlik3 where ogrno like '%" + textBox12.Text + "%'", baglan);
            SqlDataReader oku = ara.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem();
                kayit.Text = oku["ogrno"].ToString();
                kayit.SubItems.Add(oku["adi"].ToString());
                kayit.SubItems.Add(oku["sadi"].ToString());
                kayit.SubItems.Add(oku["dyeri"].ToString());
                kayit.SubItems.Add(oku["dtarihi"].ToString());
                kayit.SubItems.Add(oku["sinif"].ToString());
                kayit.SubItems.Add(oku["anneadi"].ToString());
                kayit.SubItems.Add(oku["babaadi"].ToString());
                kayit.SubItems.Add(oku["tel"].ToString());
                kayit.SubItems.Add(oku["adres"].ToString());
                listView1.Items.Add(kayit);
            }
            oku.Close();
            baglan.Close();
            textBox12.Clear();
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

        private void Form3_Load(object sender, EventArgs e)
        {
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label11.Text = listView1.SelectedItems[0].SubItems[0].Text;
                dveri_oku();
                button3.Enabled = true;
            }
            catch { 
            
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        { 
        }
        

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label12.Text = listView2.SelectedItems[0].SubItems[0].Text;
                textBox1.Text = listView2.SelectedItems[0].SubItems[2].Text;
                textBox2.Text = listView2.SelectedItems[0].SubItems[3].Text;
                textBox3.Text = listView2.SelectedItems[0].SubItems[4].Text;
                textBox4.Text = listView2.SelectedItems[0].SubItems[5].Text;
                textBox5.Text = listView2.SelectedItems[0].SubItems[6].Text;
                textBox6.Text = listView2.SelectedItems[0].SubItems[7].Text;
                textBox7.Text = listView2.SelectedItems[0].SubItems[8].Text;
                textBox8.Text = listView2.SelectedItems[0].SubItems[9].Text;
                textBox9.Text = listView2.SelectedItems[0].SubItems[10].Text;
                textBox10.Text = listView2.SelectedItems[0].SubItems[11].Text;
               
            }

            catch { 
            
            }
        }

    
        private void button3_Click_1(object sender, EventArgs e)
        {
            veri_kaydet();
            button3.Enabled = false;
            textBox12.Clear();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                    ort = (int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text) + int.Parse(textBox7.Text) + int.Parse(textBox8.Text)) / 5;
                    if (ort > 45)
                    {
                        sonuc = "Geçti";
                        textBox10.Text = sonuc;

                    }
                    else
                    {

                        sonuc = "Kaldı";
                        textBox10.Text = sonuc;
                    }
                   textBox9.Text = ort.ToString();
                SqlCommand guncelle = new SqlCommand("update dersler set dersadi='" + textBox1.Text + "',oadi='" + textBox2.Text + "',osadi='" + textBox3.Text + "',yazili1='" + textBox4.Text + "',yazili2='" + textBox5.Text + "',yazili3='" + textBox6.Text + "',sozlu1='" + textBox7.Text + "',sozlu2='" + textBox8.Text + "',ort='" + ort + "' where id=" + label12.Text + "", baglan);
                baglan.Open();
                guncelle.ExecuteNonQuery();
                baglan.Close();
                dveri_oku();
            }
            catch {

                MessageBox.Show("Lütfen Güncellemek İstediğiniz Dersi Aşağıdaki Tablodan Seçiniz...");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            sil();
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = new Form1();
            form1.Show();
        }

           }
}
