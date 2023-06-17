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
    public partial class KullaniciSayfasi : Form
    {
        private string connectionString = "Data Source=DESKTOP-S657VTM\\SQLEXPRESS;Initial Catalog=GorselPrj;Integrated Security=True";
        public int ID;
        public KullaniciSayfasi()
        {
            InitializeComponent();
        }

     

        private void KullaniciSayfasi_Load(object sender, EventArgs e)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"select  top 10 kullanici_adi,Skor from skor order by skor desc ";
                var kullaniciSkorlari = connection.Query<KullaniciModel>(sql).ToList();
                foreach (var kullaniciSkor in kullaniciSkorlari)

                {
                    listView1.Items.Add(new ListViewItem(new string[] { kullaniciSkor.kullanici_adi,kullaniciSkor.skor.ToString()}));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oyun Oyun = new Oyun();
            Oyun.Show(); 
            Hide(); 
        }
       
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
