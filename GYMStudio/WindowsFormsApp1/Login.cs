using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Init_Data();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e) //Sıfırla Butonu
        {
            KullaniciTB.Text = "";
            SifreTB.Text = ""; 
        }

        private void guna2Button1_Click(object sender, EventArgs e) //Giriş Butonu
        {
            if(KullaniciTB.Text=="" || SifreTB.Text == "")
            {
                MessageBox.Show("Eksik Bilgi.");
            }
            else if(KullaniciTB.Text=="Admin" && SifreTB.Text == "12345")
            {
                Save_Data();
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }
        }

        private void Init_Data()     //Text Box'lara girilen bilgilerin veri tabanında nereyle eşleşeceğini belirleyen metod.
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if(Properties.Settings.Default.Remember == true)
                {
                    KullaniciTB.Text=Properties.Settings.Default.UserName;
                    SifreTB.Text = Properties.Settings.Default.Password;
                    CheckBox.Checked = true;
                }
                else
                {
                    KullaniciTB.Text = Properties.Settings.Default.UserName;
                }
            }
        }

        private void Save_Data()  // Beni Hatırla butonu açık olursa bilgileri kaydedecek, kapalıysa bilgileri kaydetmeyecek olan metod.
        {
            if (CheckBox.Checked)
            {
                Properties.Settings.Default.UserName = KullaniciTB.Text;
                Properties.Settings.Default.Password = SifreTB.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void KullaniciTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
