using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
using System.Net;
using System.Net.Mail;


namespace ConsoleApp1
{
    public partial class Kayit : Form
    {
        
        static string connectionString = "Data Source=DESKTOP-S657VTM\\SQLEXPRESS;Initial Catalog=GorselPrj;Integrated Security=True";
        SqlConnection connect = new SqlConnection(connectionString);
        public Kayit()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        string onaykodu;
        
        

        private void button2_Click(object sender, EventArgs e)
        {

            Login Login = new Login();//açılacak form
            Login.Show(); //form 2 açılıyor.
            this.Hide(); // Login formunu kapatır
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            btnOnay.Visible = false;
            lblOnayKodu.Visible = false;
            txtOnay.Visible = false;
            onaykodu = rnd.Next(100) + rnd.Next(100).ToString();


            toolTip1.SetToolTip(btnKayıtOl, "Kayıt Olmak için tıklayınız");
            toolTip1.SetToolTip(btnOnay, "Onaylamak için tıklayınız");
            toolTip1.SetToolTip(button2, "Geri dönmek için tıklayınız");
            toolTip1.SetToolTip(txtEposta, "E postanızı yazınız");
            toolTip1.SetToolTip(txtKullaniciAdiKayıtOl, "Kullanıcı adınızı giriniz");
            toolTip1.SetToolTip(txtOnay, "Onay kodunuzu yazınız");
            toolTip1.SetToolTip(txtSifreKayıtOl, "Şifrenizi Yazınız");

        }

        private void btnKayıtOl_Click(object sender, EventArgs e)

        {

            // textbox dolu boş kontrol
            if (string.IsNullOrEmpty(txtKullaniciAdiKayıtOl.Text) || string.IsNullOrEmpty(txtSifreKayıtOl.Text) || string.IsNullOrEmpty(txtEposta.Text))
            {
                MessageBox.Show("Alanlar boş geçilemez.");
                return;
            }
            //mail doğrulama

            MailMessage ePosta = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mrerensen6@gmail.com", "Erensen55.");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            ePosta.To.Add(txtEposta.Text);
            ePosta.From = new MailAddress("mrerensen6@gmail.com");
            ePosta.Subject = "Doğrulama Kodu";
            ePosta.Body = onaykodu;
            istemci.Send(ePosta);
            MessageBox.Show("doğrulama kodu mail atıldı .");

            btnKayıtOl.Visible = false;
                btnOnay.Visible = true;
                lblOnayKodu.Visible = true;
                txtOnay.Visible = true;
            
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into Kullanici_Bilgi (kullanici_adi,sifre,eposta) values(@kullanici_adi,@sifre,@eposta)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@kullanici_Adi", txtKullaniciAdiKayıtOl.Text);

                komut.Parameters.AddWithValue("@sifre", txtSifreKayıtOl.Text);

                komut.Parameters.AddWithValue("@eposta", txtEposta.Text);
                komut.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Kayıt Eklendi");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi" + hata.Message);
            }

                    Login Login = new Login();//açılacak form
                    Login.Show(); //form 2 açılıyor.
            this.Hide();
        }

        private void Kayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

