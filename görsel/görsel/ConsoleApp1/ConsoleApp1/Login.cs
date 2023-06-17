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
using Dapper;

namespace ConsoleApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            RememberMe();
        }
        // beni hatırla özelliği

        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        private void RememberMe()
        {
            if (Properties.Settings.Default.KullaniciAdi != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                    txtSifre.Text = Properties.Settings.Default.Sifre;
                    Remember.Checked = true;
                }
                else
                {
                    txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;

                }

            }
        }
        private void Save_remember()
        {
            if (Remember.Checked)
            {
                Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.Text;
                Properties.Settings.Default.Sifre = txtSifre.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.KullaniciAdi = null;
                Properties.Settings.Default.Sifre = null;
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }




        public static string kullaniciadi;

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            con = new SqlConnection("Data Source=DESKTOP-S657VTM\\SQLEXPRESS;Initial Catalog=GorselPrj;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Kullanici_Bilgi where kullanici_adi='" + txtKullaniciAdi.Text +
                "'And sifre='" + txtSifre.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Save_remember();
                kullaniciadi = txtKullaniciAdi.Text;
                MessageBox.Show("Giriş Başarılı");
                KullaniciSayfasi KullaniciSayfasi = new KullaniciSayfasi();
                KullaniciSayfasi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şfire");
            }
            con.Close();

        }
        
        private void lnklblKayıtOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayit kayit = new Kayit();//açılacak form
            kayit.Show(); //form 2 açılıyor.
            Hide(); // Login formunu kapatır
        }

        private void Remember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lnklblSifreUnuttm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum SifremiUnuttum = new SifremiUnuttum();//açılacak form
            SifremiUnuttum.Show(); 
            Hide(); 
        }

        private void btnIletisim_Click(object sender, EventArgs e)
        {
            Iletisim Iletisim = new Iletisim();//açılacak form
            Iletisim.Show();
            Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtKullaniciAdi, "Kullacı Adınızı Giriniz");
            toolTip1.SetToolTip(txtSifre, "Şifrenizi Giriniz");
            toolTip1.SetToolTip(btnGiris, "Giriş Yapmak için tıklayınız");
            toolTip1.SetToolTip(lnklblKayıtOl, "Kayıt olmak için tıklayınız");
            toolTip1.SetToolTip(lnklblSifreUnuttm, "Şifrenizi unuttuysanız tıklayın");
            toolTip1.SetToolTip(btnIletisim, "İletişim sayfasını açmak için tıklayınız");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admingiris admngrs = new Admingiris();
            admngrs.Show();
            this.Hide();
        }
    }
}
