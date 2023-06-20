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

namespace WindowsFormsApp1
{
    public partial class UyeGoruntuleme : Form
    {
        public UyeGoruntuleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MEHMETALP\SQLEXPRESS;Initial Catalog=SporDB;Integrated Security=True"); //Veri Tabanı Bağlantımızı SSMS Linki Üzerinden Yapıyoruz.
        private void uyeler()  //UyeTBL veri tabanından verileri çekiyoruz.
        {
            baglanti.Open();
            string sorgu = "select *from UyeTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            UyeDGV.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void UyeGoruntuleme_Load(object sender, EventArgs e) //Üyeleri Görüntülüyoruz.
        {
            uyeler();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e) //Uygulamadan Çıkış Yapıyoruz.
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e) ////Geri Butonu ve Anasayfaya Yönlendiriyor.
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
