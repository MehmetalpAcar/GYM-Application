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
    public partial class GuncelleSil : Form
    {
        public GuncelleSil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MEHMETALP\SQLEXPRESS;Initial Catalog=SporDB;Integrated Security=True"); //Veri Tabanı Bağlantımızı SSMS Linki Üzerinden Yapıyoruz.

        private void uyeler()
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        int key = 0;
        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(UyeDGV.SelectedRows[0].Cells[0].Value.ToString());
            AdSoyadTB.Text = UyeDGV.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTB.Text = UyeDGV.SelectedRows[0].Cells[2].Value.ToString();
            CinsiyetCB.Text = UyeDGV.SelectedRows[0].Cells[3].Value.ToString();
            YasTB.Text = UyeDGV.SelectedRows[0].Cells[4].Value.ToString();
            TutarTB.Text = UyeDGV.SelectedRows[0].Cells[5].Value.ToString();
            RandevuCB.Text = UyeDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e) //Sıfırla Butonu ve Girilen Bilgileri Sıfırlamamızı Sağlıyor.
        {
            AdSoyadTB.Text = "";
            TelefonTB.Text = "";
            CinsiyetCB.Text = "";
            YasTB.Text = "";
            TutarTB.Text = "";
            RandevuCB.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e) //Geri Butonu ve Anasayfaya Yönlendiriyor.
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Sil_Click(object sender, EventArgs e) //Sil Butonu ve Silme İşlemini Gerçekleştirmemizi Sağlıyor.
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz.");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "delete from UyeTBL where UyeID=" + key + ";";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Silindi.");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Guncelle_Click(object sender, EventArgs e) //Güncelle Butonu ve Güncelleme İşlemini Gerçekleştirmemizi Sağlıyor.
        {
            if (key == 0 || AdSoyadTB.Text == "" || TelefonTB.Text == "" || CinsiyetCB.Text == "" || YasTB.Text == "" || TutarTB.Text == "" || RandevuCB.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "update UyeTBL set UyeAdSoyad='" + AdSoyadTB.Text + "',UyeTelefon='" + TelefonTB.Text + "',UyeCinsiyet='" + CinsiyetCB.Text + "',UyeYas='" + YasTB.Text + "',UyeOdeme='" + TutarTB.Text + "' ,UyeRandevu='" + RandevuCB.Text + "' where UyeID=" + key + ";";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Güncellendi.");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e) //Uygulamadan Çıkış Yapıyoruz.
        {
            Application.Exit();
        }
    }
}
