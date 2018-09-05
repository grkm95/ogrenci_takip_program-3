using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ogrenci_takip_programı
{
    public partial class Form2 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = ogrenci.mdb");
        public Form2()
        {
            InitializeComponent();
        }
     
        private void veri_oku()
        {
         
                OleDbCommand veri = new OleDbCommand("select * from kimlik", baglan);
                OleDbDataReader oku = null;
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
        private void veri_kaydet()
        {
            try
            {

                OleDbCommand kaydet = new OleDbCommand("insert into kimlik (ogrno,adi,sadi,dyeri,dtarihi,sinif,anneadi,babaadi,tel,adres) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "')", baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                veri_oku();
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
                a = int.Parse(listView1.SelectedItems[0].Text);
                OleDbCommand sil = new OleDbCommand("delete from kimlik where ogrno =" + a + "", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                veri_oku();
            }
            catch
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kaydı Aşağıdan Seçiniz...");
            }
        }
    }
}
