using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        
        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            sqlbagalnti bgln = new sqlbagalnti();
            SqlCommand komut = new SqlCommand("Select*From Kullanici_Bilgi where kullanici_adi='" + txtKullaniciAdi.Text.ToString() + "'And eposta='" + txtEposta.Text.ToString() + "'", bgln.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresin = ("mrerensen6@gmail.com");
                    string sifre = ("Erensen55.");
                    string smptsrvr = "smtp.gmail.com";
                    string kime = (oku["eposta"].ToString());
                    string konu = ("şifre hatırlatma maili");
                    string yaz = ("SSayın," + oku["kullanici_adi"].ToString() + "\n" + "Bizden" + tarih + "Tarihinde Şifre Hatırlatma Talebinde Bulundunuz" + "\n" + "Parolanız:" + oku["sifre"].ToString() + "\niyi günler");
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş Olduğunuz Bilgiler Uyuşuyor. Şifreniz Mail Adresinize Gönderilmiştir");
                    this.Show();
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası", Hata.Message);
                }
            }


        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login Login = new Login();//açılacak form
            Login.Show(); //form 2 açılıyor.
            Hide(); // Login formunu kapatır
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSifremiUnuttum, "Şifremi Unuttum");
            toolTip1.SetToolTip(button1, "Geri Dönmek için tıklayınız");
            toolTip1.SetToolTip(txtKullaniciAdi, "Kullanıcı Adınızı Giriniz");
            toolTip1.SetToolTip(txtEposta, "E posta adresinizi giriniz");
        }
    }
}
