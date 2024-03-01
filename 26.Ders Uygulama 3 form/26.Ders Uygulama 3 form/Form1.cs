using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _26.Ders_Uygulama_3_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adi, no, sinif, bölüm;
            adi   = textBox1.Text;
            no    = textBox2.Text;
            sinif = textBox3.Text;
            bölüm = textBox4.Text;

            StreamWriter yaz = new StreamWriter(@"c:\CDos\Personel.txt", true);
            yaz.WriteLine(adi + ";" + no + ";" + sinif + ";" + bölüm);
            yaz.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            //label10.Text = "KAYIT EDİLDİ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
