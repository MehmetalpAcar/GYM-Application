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
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MEHMETALP\SQLEXPRESS;Initial Catalog=SporDB;Integrated Security=True"); //Veri Tabanı Bağlantımızı SSMS Linki Üzerinden Yapıyoruz.

        private void FillName() //ÜyeTBL veri tabanımızdaki UyeAdSoyad tablomuzdan isimleri çekip ComboBox butonumuzda gösteriyoruz.
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select UyeAdSoyad from UyeTBL", baglanti);
            SqlDataReader reader;
            reader = komut.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UyeAdSoyad", typeof(string));
            dataTable.Load(reader);
            AdSoyadCB.ValueMember = "UyeAdSoyad";
            AdSoyadCB.DataSource = dataTable;
            baglanti.Close();
        }
        private void uyeler() //OdemeTBL tablomuzla Data Grid View oluşturuyoruz.
        {
            baglanti.Open();
            string sorgu = "select *from OdemeTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            OdemeDGV.DataSource = dataSet.Tables[0];
            baglanti.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e) //Uygulamadan Çıkış Yapıyoruz.
        {
            Application.Exit();
        }

        private void Sifirla_Click(object sender, EventArgs e) //Sıfırla Butonu ve Girilen Bilgileri Sıfırlamamızı Sağlıyor.
        {
            AdSoyadCB.Text = "";
            TutarTB.Text = "";
        }

        private void Geri_Click(object sender, EventArgs e) //Geri Butonu ve Anasayfaya Yönlendiriyor.
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Odemeler_Load(object sender, EventArgs e) //Üyeleri Görüntülüyoruz.
        {
            FillName();
            uyeler();
        }

        private void TarihCB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Odeme_Click(object sender, EventArgs e) //Üye Ekle butonumuz ve İf-Else bloğuyla Eksik Bilgi Kontrolü Yapıp Ödeme İşlemini Gerçekleştiriyoruz.
        {
            if(AdSoyadCB.Text=="" || TutarTB.Text == "")
            {
                MessageBox.Show("Eksik Bilgi.");
            }
            else
            {
                string odemeperiyodu = TarihCB.Value.Month.ToString()+TarihCB.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from OdemeTBl where OdemeUye='" + AdSoyadCB.SelectedValue.ToString() + "' and OdemeAy='" + odemeperiyodu + "'", baglanti);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Zaten Ödeme Yapıldı.");
                }
                else
                {
                    string sorgu = "insert into OdemeTBL values ('" + odemeperiyodu + "','" + AdSoyadCB.SelectedValue.ToString() + "'," + TutarTB.Text + ")";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Başarıyla Ödendi.");
                }
                baglanti.Close();
                uyeler();
            }
        }
    }
}
