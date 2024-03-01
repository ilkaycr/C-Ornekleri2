using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _27.Ders_Sql_falan_fişman
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server = .\\SQLEXPRESS;Database = ornProje;Integrated Security =True");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SqlConnection nesne_adi = new SqlConnection("Data Source = Sunucu adı veya ıp si;Initial Catalog = veritabani_adı;Integrated Security =True");
            SqlConnection baglanti = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = ornProje;Integrated Security =True");
            SqlConnection baglanti1 = new SqlConnection("Data Source = 193.124.242.252;Initial Catalog = ornekDB;userid =iacar;password=123");
            SqlConnection baglanti2 = new SqlConnection("Server = .\\SQLEXPRESS;Database = ornProje;Integrated Security =True");

            SqlConnection baglanti3 = new SqlConnection();
            baglanti3.ConnectionString = "Data Source = .\\SQLEXPRESS;Initial Catalog = ornProje;Integrated Security =True";

            // SqlCommand nesne_adi = new SqlCommand(sorgu,baglanti1);
            SqlCommand komut = new SqlCommand("select * from tblProje", baglanti2);

            SqlDataReader oku = komut.ExecuteReader();

            if (baglanti2.State == ConnectionState.Closed)
                baglanti2.Open();


             // baglanti2.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string oad, omem, omail, onum;
            oad   = textBox1.Text;
            omem  = textBox2.Text;
            omail = textBox3.Text;
            onum  = textBox4.Text;

            SqlCommand cmd = new SqlCommand("insert into tblProje(oAdi,oMem,oEposta,oNumara) values('"+oad+"','"+omem+"','"+omail+"','"+onum+"') ", con);

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            con.Open();
            cmd = new SqlCommand("select * from tblProje", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr[1]);
                listBox2.Items.Add(dr[2]);
                listBox3.Items.Add(dr[3]);
                listBox4.Items.Add(dr[4]);

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string istOgr = textBox5.Text;
            cmd = new SqlCommand("delete from tblProje where oNumara = '"+istOgr+"' ",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string oad, omem, omail, onum;
            oad = textBox1.Text;
            omem = textBox2.Text;
            omail = textBox3.Text;
            onum = textBox4.Text;
            string istOgr = textBox5.Text;

            cmd = new SqlCommand("update tblProje set oAdi='"+oad+"',oMem='"+omem+"',oEposta='"+omail+"',oNumara='"+onum+"' where oNumara = '" + istOgr + "' ", con);

            cmd.ExecuteNonQuery();
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            con.Close();
        }
    }
}
