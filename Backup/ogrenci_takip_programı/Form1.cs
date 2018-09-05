using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ogrenci_takip_programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Program GorselYazilim.Net Tarafından Hazırlanmıştır.Bu ve Buna Benzer Takip Programlarına Sitemizden Erişebilirsiniz.Faydalı Olması Dileğiyle...","GorselYazilim.Net");
        }
    }
}
