using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
        }
        sqlbagalnti bgln = new sqlbagalnti();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-S657VTM\\SQLEXPRESS;Initial Catalog=GorselPrj;Integrated Security=True");
        
        DataSet daset = new DataSet();


        private void button1_Click(object sender, EventArgs e)
        {
            //GÖRÜNTÜLE - listele
            SqlDataAdapter ad = new SqlDataAdapter("select *from Kullanici_Bilgi", bgln.baglanti());
            ad.Fill(daset, "Kullanici_Bilgi");
            dataGridView1.DataSource = daset.Tables["Kullanici_Bilgi"];
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            // güncelle
            SqlCommand komut = new SqlCommand("update Kullanici_Bilgi set sifre=@sifre, eposta=@eposta where kullanici_adi=@kullanici_adi", bgln.baglanti());

            komut.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            komut.Parameters.AddWithValue("@eposta", textBox3.Text);
            komut.ExecuteNonQuery();
            daset.Tables["Kullanici_Bilgi"].Clear();

            SqlDataAdapter ad = new SqlDataAdapter("select *from Kullanici_Bilgi", bgln.baglanti());
            ad.Fill(daset, "Kullanici_Bilgi");
            dataGridView1.DataSource = daset.Tables["Kullanici_Bilgi"];

            MessageBox.Show("Güncelleme Başarılı");



            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //EKLE BUTONU - kaydet
            try
            {
                SqlCommand komut = new SqlCommand("insert into Kullanici_Bilgi(kullanici_adi,sifre,eposta) values(@kullanici_adi,@sifre,@eposta)", bgln.baglanti());


                komut.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                komut.Parameters.AddWithValue("@eposta", textBox3.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Kayıt Başarılı");

                //textboxları temizleme
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("HATA" + hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil
            SqlCommand komut = new SqlCommand("delete from Kullanici_Bilgi where kullanici_adi='" + dataGridView1.CurrentRow.Cells["kullanici_adi"].Value.ToString() + "'", bgln.baglanti());
            komut.ExecuteNonQuery();
            daset.Tables["Kullanici_Bilgi"].Clear();

            SqlDataAdapter ad = new SqlDataAdapter("select *from Kullanici_Bilgi", bgln.baglanti());
            ad.Fill(daset, "Kullanici_Bilgi");
            dataGridView1.DataSource = daset.Tables["Kullanici_Bilgi"];

            MessageBox.Show("Kayıt Silindi");

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["kullanici_adi"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["eposta"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Close();
        }
    }
}
