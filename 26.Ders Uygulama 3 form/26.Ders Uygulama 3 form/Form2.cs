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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            StreamReader bak = new StreamReader(@"c:\CDos\Personel.txt");
            string bakilan;
            string[] satir;
            while (( bakilan = bak.ReadLine()) != null)
            {
                satir = bakilan.Split(';') ;
                listBox1.Items.Add(satir[0]);
                listBox2.Items.Add(satir[1]);
                listBox3.Items.Add(satir[2]);
                listBox4.Items.Add(satir[3]);
            }
            bak.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
