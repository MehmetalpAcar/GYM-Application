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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MEHMETALP\SQLEXPRESS;Initial Catalog=SporDB;Integrated Security=True"); //Veri Tabanı Bağlantımızı SSMS Linki Üzerinden Yapıyoruz.

        private void Anasayfaa_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e) //Üye Ekle Butonu ve Üye Ekle Sayfasına Yönlendiriyor.
        {
            UyeEkle uyeekle = new UyeEkle();
            uyeekle.Show();
            this.Hide();
        }

        private void GuncelleSil_Click(object sender, EventArgs e) //Güncelle/Sil Butonu ve Güncelle/Sil Sayfasına Yönlendiriyor.
        {
            GuncelleSil guncellesil = new GuncelleSil();
            guncellesil.Show();
            this.Hide();
        }

        private void UyeleriGoruntule_Click(object sender, EventArgs e) //Üye Görüntüleme Butonu ve Üye Görüntüleme Sayfasına Yönlendiriyor.
        {
            UyeGoruntuleme uyeGoruntuleme = new UyeGoruntuleme();
            uyeGoruntuleme.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e) //Uygulamadan Çıkış Yapma Butonu.
        {
            Application.Exit();
        }

        private void UyeOdeme_Click(object sender, EventArgs e) //Ödemeler Butonu ve Ödeme Sayfasına Yönlendiriyor.
        {
           Odemeler odeme = new Odemeler();
            odeme .Show();  
            this .Hide();
        }

        private void GeriButon_Click(object sender, EventArgs e) //Bir Önceki Sayfaya Dönme Butonu ve Login Sayfasına Yönlendiriyor.
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
