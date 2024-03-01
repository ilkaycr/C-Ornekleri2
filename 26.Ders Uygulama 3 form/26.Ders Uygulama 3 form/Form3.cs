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
    public partial class Form3 : Form
    {
        string arananTel;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bul = false;
            arananTel = Microsoft.VisualBasic.Interaction.InputBox("Güncellenecek Akademisyenin Telefon Numarasını Giriniz.", "Güncellenecek Akademisyen", "", 100, 100);
            StreamReader sr = new StreamReader(@"c:\CDos\Personel.txt", Encoding.Default);
            string[] satir;
            string okunan;
            while ((okunan = sr.ReadLine()) != null)
            {
                satir = okunan.Split(';');
                if (arananTel == satir[2])
                {
                    bul = true;
                    textBox1.Text = satir[0];
                    textBox2.Text = satir[1];
                    textBox3.Text = satir[2];
                    textBox4.Text = satir[3];
                }
            }
            if (bul == false)
                MessageBox.Show("Girilen Telefon Numarasına Uygun Akademisyen Bulunmamaktadır.");
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty & textBox2.Text != string.Empty & textBox3.Text != string.Empty & textBox4.Text != string.Empty)
            {
                StreamReader oku = new StreamReader(@"c:\CDos\Personel.txt", Encoding.Default);
                StreamWriter yaz = new StreamWriter(@"c:\CDos\PersonelYedek.txt", false, Encoding.Default);
                string[] satir;
                string okunan;
                while ((okunan = oku.ReadLine()) != null)
                {
                    satir = okunan.Split(';');
                    if (arananTel == satir[2])
                    {
                        string ad, bölüm, tel, saat;
                        ad = textBox1.Text;
                        bölüm = textBox2.Text;
                        tel = textBox3.Text;
                        saat = textBox4.Text;

                        yaz.WriteLine(ad + ";" + bölüm + ";" + tel + ";" + saat);
                    }
                    else
                        yaz.WriteLine(okunan);
                }
                oku.Close();
                yaz.Close();
                File.Delete(@"c:\CDos\Personel.txt");
                File.Move(@"c:\CDos\PersonelYedek.txt", @"c:\CDos\Personel.txt");

                MessageBox.Show("Güncellendi");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
