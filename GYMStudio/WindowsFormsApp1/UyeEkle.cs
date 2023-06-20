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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MEHMETALP\SQLEXPRESS;Initial Catalog=SporDB;Integrated Security=True"); //Veri Tabanı Bağlantımızı SSMS Linki Üzerinden Yapıyoruz.


        private void guna2Button2_Click(object sender, EventArgs e) //Sıfırla Butonu ve Girilen Bilgileri Sıfırlamamızı Sağlıyor.
        {
            AdSoyadTB.Text = "";
            TelefonTB.Text = "";
            TutarTB.Text = "";
            YasTB.Text = "";
            CinsiyetCB.Text = "";
            RandevuCB.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e) //Geri Butonu ve AnaSayfaya Yönlendiriyor.
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void EkleButon_Click(object sender, EventArgs e) //Üye Ekle butonumuz ve İf-Else bloğuyla Eksik Bilgi Kontrolü Yapıp Try-Catch Bloğuyla ÜyeTBL Veri Tabanına Üyeyi Ekliyoruz.
        {
            if (AdSoyadTB.Text == "" || TelefonTB.Text == "" || TutarTB.Text == "" || YasTB.Text == "")
            {
                MessageBox.Show("Eksik Bilgi.");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "insert into UyeTBL values('" + AdSoyadTB.Text + "','" + TelefonTB.Text + "','" + CinsiyetCB.SelectedItem.ToString() + "','" + YasTB.Text + "','" + TutarTB.Text + "','" + RandevuCB.SelectedItem.ToString() + "')";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Eklendi.");
                    baglanti.Close();
                    AdSoyadTB.Text = "";
                    TelefonTB.Text = "";
                    TutarTB.Text = "";
                    YasTB.Text = "";
                    CinsiyetCB.Text = "";
                    RandevuCB.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) //Uygulamadan Çıkış Yapıyoruz.
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void AdSoyadTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
