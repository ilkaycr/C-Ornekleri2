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

namespace _25.Ders_uygulamalı_örnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adi, no, sinif, bölüm;
            adi   = textBox1.Text;
            no    = textBox2.Text;
            sinif = textBox3.Text;
            bölüm = textBox4.Text;

            StreamWriter yaz = new StreamWriter(@"c:\ogrenci.txt", true);
            yaz.WriteLine(adi + ";" + no + ";" + sinif + ";" + bölüm);
            yaz.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label10.Text = "KAYIT EDİLDİ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            StreamReader oku = new StreamReader(@"c:\ogrenci.txt");
            string okunan;
            string[] satir;
            while ((okunan = oku.ReadLine()) != null) 
            {
                satir = okunan.Split(';');
                listBox1.Items.Add(satir[0]);
                listBox2.Items.Add(satir[1]);
                listBox3.Items.Add(satir[2]);
                listBox4.Items.Add(satir[3]);
            }
            oku.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int fcs = 0;
            StreamReader sr = new StreamReader(@"c:\sayac.txt");
            fcs = Convert.ToInt32(sr.ReadLine());
            fcs++;
            label11.Text = "Formun yüklenme sayısı : " + fcs.ToString();
            sr.Close();

            StreamWriter sw = new StreamWriter(@"c:\sayac.txt", false);
            sw.WriteLine(fcs);
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string arananogrenci = textBox5.Text;
            StreamReader oku = new StreamReader(@"c:\ogrenci.txt");
            StreamWriter yaz = new StreamWriter(@"c:\ogrenciYedek.txt",false);
            string[] satir;
            string okunan;
            while ((okunan = oku.ReadLine()) != null)
            {
                satir = okunan.Split(';');
                if (arananogrenci == satir[1])
                {
                    string adi, no, sinif, bölüm;
                    adi   = textBox1.Text;
                    no    = textBox2.Text;
                    sinif = textBox3.Text;
                    bölüm = textBox4.Text;

                    yaz.WriteLine(adi + ";" + no + ";" + sinif + ";" + bölüm);
                }
                else
                    yaz.WriteLine(okunan);
            }
            oku.Close();
            yaz.Close();
            File.Delete(@"c:\ogrenci.txt");
            File.Move(@"c:\ogrenciYedek.txt", @"c:\ogrenci.txt");
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label10.Text = "Güncelleme İşlemi yapıldı";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string arananogrenci = textBox5.Text;
            StreamReader oku = new StreamReader(@"c:\ogrenci.txt");
            StreamWriter yaz = new StreamWriter(@"c:\ogrenciYedek.txt", false);
            string[] satir;
            string okunan;
            while ((okunan = oku.ReadLine()) != null)
            {
                satir = okunan.Split(';');
                if (arananogrenci != satir[1])
                    yaz.WriteLine(okunan);
            }
            oku.Close();
            yaz.Close();
            File.Delete(@"c:\ogrenci.txt");
            File.Move(@"c:\ogrenciYedek.txt", @"c:\ogrenci.txt");
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label10.Text = "Silme İşlemi yapıldı";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string arananogrenci = textBox5.Text;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            StreamReader oku = new StreamReader(@"c:\ogrenci.txt");
            string okunan;
            string[] satir;
            while ((okunan = oku.ReadLine()) != null)
            {
                satir = okunan.Split(';');
                if (arananogrenci == satir[1])
                {
                    listBox1.Items.Add(satir[0]);
                    listBox2.Items.Add(satir[1]);
                    listBox3.Items.Add(satir[2]);
                    listBox4.Items.Add(satir[3]);
                }
            }
            oku.Close();
        }

    }
}
