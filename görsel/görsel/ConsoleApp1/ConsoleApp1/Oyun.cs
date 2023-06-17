using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ConsoleApp1
{
    public partial class Oyun : Form
    {
        public Oyun()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=DESKTOP-S657VTM\\SQLEXPRESS;Initial Catalog=GorselPrj;Integrated Security=True";

        
        private List<Label> labels = new List<Label>();
        private int score = 0;
        bool d1 = true, d2 = false, d3 = false, d4 = false, bitti = false,d5=false;
        private void Oyun_Load(object sender, EventArgs e)
        {
            
            // in den sonra sadece label olanlar gelsin diye 
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.BackColor = System.Drawing.Color.Transparent;
                ControlExtension.Draggable(label, true);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Label label in this.Controls.OfType<Label>())
            {//çakışma varsa doğru 
                if (pictureBox1.Bounds.IntersectsWith(label.Bounds))
                {
                    if (pictureBox1.Tag.ToString() == label.Text)
                    {
                        label.Text = null;
                        label.Visible = false;
                        score += 5;
                        label7.Text = score.ToString();
                        MessageBox.Show("Doğru Eşleştirme");
                    }
                    else if (!string.IsNullOrEmpty(label.Text))
                    {
                        label.Location = new Point(12,384);
                        label.Text = null;
                        label.Visible = false;



                        MessageBox.Show("Hatalı Eşleştirme");
                    }
                }
                //çakışma varsa doğru 
                if (pictureBox2.Bounds.IntersectsWith(label.Bounds))
                {
                    if (pictureBox2.Tag.ToString() == label.Text)
                    {
                        label.Text = null;
                        label.Visible = false;
                        score += 5;
                        label7.Text = score.ToString();
                        MessageBox.Show("Doğru Eşleştirme");

                    }
                    else if (!string.IsNullOrEmpty(label.Text))

                    {
                        label.Text = null;
                        label.Visible = false;
                        MessageBox.Show("Hatalı Eşleştirme");

                    }
                }
                //çakışma varsa doğru 
                if (pictureBox3.Bounds.IntersectsWith(label.Bounds))
                {
                    if (pictureBox3.Tag.ToString() == label.Text)
                    {
                        label.Text = null;
                        label.Visible = false;
                        score += 5;
                        label7.Text = score.ToString();
                        MessageBox.Show("Doğru Eşleştirme");

                    }
                    else if (!string.IsNullOrEmpty(label.Text))

                    {
                        label.Text = null;
                        label.Visible = false;
                        MessageBox.Show("Hatalı Eşleştirme");

                    }
                }
                //çakışma varsa doğru 
                if (pictureBox4.Bounds.IntersectsWith(label.Bounds))
                {
                    if (pictureBox4.Tag.ToString() == label.Text)
                    {
                        label.Text = null;
                        label.Visible = false;
                        score += 5;
                        label7.Text = score.ToString();
                        MessageBox.Show("Doğru Eşleştirme");

                    }
                    else if (!string.IsNullOrEmpty(label.Text))

                    {
                        label.Text = null;
                        label.Visible = false;
                        MessageBox.Show("Hatalı Eşleştirme");

                    }
                }
                //çakışma varsa doğru 
                
            }

            if (string.IsNullOrEmpty(label1.Text) && string.IsNullOrEmpty(label2.Text) && string.IsNullOrEmpty(label3.Text) && string.IsNullOrEmpty(label4.Text)  && d1)
            {
                // ilk mekan
                this.pictureBox1.Image = Properties.Resources.donut;
                pictureBox1.Tag = "Donut";
                this.pictureBox2.Image = Properties.Resources.dünya_küresi;
                pictureBox2.Tag = "DünyaKüresi";
                this.pictureBox3.Image = Properties.Resources.gözlük;
                pictureBox3.Tag = "Gözlük";
                this.pictureBox4.Image = Properties.Resources.kalem;
                pictureBox4.Tag = "Kalem";
                
                d1 = false;
                d2 = true;
            }
            else if ( string.IsNullOrEmpty(label5.Text) && string.IsNullOrEmpty(label8.Text) && string.IsNullOrEmpty(label9.Text) && string.IsNullOrEmpty(label10.Text)  && d2)
            {

                this.pictureBox1.Image = Properties.Resources.karpuz;
                pictureBox1.Tag = "Karpuz";
                this.pictureBox2.Image = Properties.Resources.kaşık;
                pictureBox2.Tag = "Kaşık";
                this.pictureBox3.Image = Properties.Resources.kitap;
                pictureBox3.Tag = "Kitap";
                this.pictureBox4.Image = Properties.Resources.kulaklık;
                pictureBox4.Tag = "Kulaklık";
                
                d2 = false;
                d3 = true;
            }

            else if ( string.IsNullOrEmpty(label11.Text) && string.IsNullOrEmpty(label12.Text) && string.IsNullOrEmpty(label13.Text) && string.IsNullOrEmpty(label14.Text) &&  d3)
            {
                this.pictureBox1.Image = Properties.Resources.kumbara;
                pictureBox1.Tag = "Kumbara";
                this.pictureBox2.Image = Properties.Resources.parfüm;
                pictureBox2.Tag = "Parfüm";
                this.pictureBox3.Image = Properties.Resources.piza;
                pictureBox3.Tag = "Pizza";
                this.pictureBox4.Image = Properties.Resources.silgi;
                pictureBox4.Tag = "Silgi";
                
                d3 = false;
                d4 = true;
            }
            else if (string.IsNullOrEmpty(label15.Text) && string.IsNullOrEmpty(label16.Text) && string.IsNullOrEmpty(label17.Text) && string.IsNullOrEmpty(label18.Text) && d4)
            {
                this.pictureBox1.Image = Properties.Resources.şapka;
                pictureBox1.Tag = "Şapka";
                this.pictureBox2.Image = Properties.Resources.tatlı;
                pictureBox2.Tag = "Tatlı";
                this.pictureBox3.Image = Properties.Resources.terlik;
                pictureBox3.Tag = "Terlik";
                this.pictureBox4.Image = Properties.Resources.tuzluk;
                pictureBox4.Tag = "Tuzluk";


                d4 = false;
                d5 = true;
            }
            else if ( string.IsNullOrEmpty(label19.Text) && string.IsNullOrEmpty(label20.Text) && string.IsNullOrEmpty(label21.Text) && string.IsNullOrEmpty(label22.Text) && d5)
            {
                d5 = false;

            }
            else if (bitti)
            {
                return; // durmuyo diye böyle bişi yaptık
            }
            else if (!d1 && !d2 && !d3 && !d4 && !d5)
            {
                timer1.Enabled = false;
                timer1.Stop();
                bitti = true;
                MessageBox.Show("Tebrikler");
                using (var connection = new SqlConnection(connectionString))
                    {
                            var sqlinsert = @"insert into Skor (kullanici_adi,skor) values (@kullanici_adi,@skor)";
                            connection.Execute(sqlinsert, new
                            {
                                Kullaniciadi = Login.kullaniciadi,
                                Skor = label7.Text
                            });                       
                    }
                //DESKTOP-S657VTM\SQLEXPRESS
            }
        }
    }
}

