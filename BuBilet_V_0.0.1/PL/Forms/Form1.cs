using BuBilet_V_0._0._1.PL.Sayfalar;
using BuBilet_V_0._0._1.Properties;
using BuBilet_V_0._0._1.Sayfalar;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuBilet_V_0._0._1
{
    public partial class FrmBuBilet : Form
    {
        private int _kullaniciID;
        public int KullaniciID
        {
            get => _kullaniciID;
            set
            {
                _kullaniciID = value;
                // KullanıcıID'yi label'da göster
                LblKullaniciID.Text = value > 0 ? $"{value}" : "0";
                adminKontrol(value);
                if (value > 0) 
                {
                    BtnBiletlerim.Visible = true;
                }
            }
        }

        // Kullanıcı Turu Adminse bazı işlevler ekle
        public void adminKontrol(int kullaniciID)
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();

                //  kullaniciID'ye gore kullaniciTuru sec
                string query = "SELECT kullaniciTuru FROM Kullanicilar WHERE kullaniciID = @kullaniciID";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    using (NpgsqlDataReader dataReader = command.ExecuteReader())
                    {
                        if(dataReader.Read())
                        {
                            string kullaniciTuru = dataReader["kullaniciTuru"].ToString();

                            //  adminse seferEkle butonunu gorunur yap degilse gizle (Yine Admin küçük harfle yazmışın büyüğe çevirdim düzeltirsin.)
                            if (kullaniciTuru == "Admin")
                                BtnKontrollerAktiflestir();
                            else
                                BtnKontrollerGizle();
                        } 

                    }
                }
            }
        }

        public FrmBuBilet()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            this.Size = workingArea.Size;
            this.Location = workingArea.Location;

            this.StartPosition = FormStartPosition.Manual;
            BtnKontroller.Visible = false;
        }

        public void panelEkle(UserControl sayfalar)
        {
            // Gelen UserControl'ü ana panele ekle
            sayfalar.Dock = DockStyle.Fill;
            PnlAnaPanel.Controls.Clear();
            PnlAnaPanel.Controls.Add(sayfalar);
            sayfalar.BringToFront();

            // Eğer sayfanın KullaniciID özelliği varsa kullanıcıID'yi sayfaya aktar
            var propertyInfo = sayfalar.GetType().GetProperty("KullaniciID");
            if (propertyInfo != null && propertyInfo.PropertyType == typeof(int))
            {
                propertyInfo.SetValue(sayfalar, KullaniciID);
            }
        }

        // Sidebar kontrolleri için Timer Event'i
        private void BtnSideBarControl_Click(object sender, EventArgs e)
        {
            TmrSideBarTransition.Start();
        }

        bool pnlKontrollerExpand = false;

        // PnlKontroller panelinin genişlemesi
        private void TmrSideBarTransition_Tick(object sender, EventArgs e)
        {
            if (!pnlKontrollerExpand)
            {
                PnlKontroller.Height += 10;
                if (PnlKontroller.Height >= PnlKontroller.MaximumSize.Height)
                {
                    pnlKontrollerExpand = true;
                    TmrSideBarTransition.Stop();
                }
            }
            else
            {
                PnlKontroller.Height -= 10;
                if (PnlKontroller.Height <= PnlKontroller.MinimumSize.Height)
                {
                    pnlKontrollerExpand = false;
                    TmrSideBarTransition.Stop();
                }
            }
        }

        #region Buton Kontrolleri
        private void BtnOtobus_Click(object sender, EventArgs e)
        {
            UCotobusler otobusBiletleriSayfasi = new UCotobusler();
            panelEkle(otobusBiletleriSayfasi);
        }

        private void BtnUcak_Click(object sender, EventArgs e)
        {
            UCucakBiletleri ucakBiletleriSayfasi = new UCucakBiletleri();
            panelEkle(ucakBiletleriSayfasi);
        }

        private void BtnOtel_Click(object sender, EventArgs e)
        {
            UCotelRezervasyonlari otelRezervasyonlariSayfasi = new UCotelRezervasyonlari();
            panelEkle(otelRezervasyonlariSayfasi);
        }

        private void BtnBilet_Click(object sender, EventArgs e)
        {
            UCbiletKontrol biletKontrolSayfasi = new UCbiletKontrol();
            panelEkle(biletKontrolSayfasi);
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            UCgirisYap girisYap = new UCgirisYap();
            girisYap.GirisYapildi += GirisYapildi;
            panelEkle(girisYap);
        }

        // Giriş yapıldıktan sonra KullanıcıID'yi aktarmak için event
        private void GirisYapildi(int kullaniciID)
        {
            KullaniciID = kullaniciID; // Form1'de kullanıcıID'yi güncelle
            UCotobusler otobusler = new UCotobusler();
            panelEkle(otobusler); // Otobüsler sayfasına geç
        }

        private void PnlAnaPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            if(KullaniciID != 0)
            {
                KullaniciID = 0; // KullanıcıID sıfırlandı
                BtnKontrollerGizle();  //Admin cikis yapmis ise butonlar gizlenir.
                BtnBiletlerim.Visible = false;
                UCgirisYap girisYap = new UCgirisYap();
                girisYap.GirisYapildi += GirisYapildi; // Giriş eventini tekrar bağla
                panelEkle(girisYap);
            }
            else
            {
                MessageBox.Show("Zaten giriş yapmamış durumdasınız.","UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        #endregion

        private void BtnOtobusSeferiEkle_Click(object sender, EventArgs e)
        {
            UCotobusSeferiEkle UCotobusSeferiEkle = new UCotobusSeferiEkle();
            panelEkle(UCotobusSeferiEkle);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TmrSideBarTransition.Start();
        }

        private void BtnKontrollerGizle()
        {
            BtnKontroller.Visible = false;
        }

        private void BtnKontrollerAktiflestir()
        {
            BtnKontroller.Visible = true;
        }

        private void BtnOtobusEkle_Click(object sender, EventArgs e)
        {
            UCotobusEkle otobusEkle = new UCotobusEkle();
            panelEkle(otobusEkle);
        }

        private void BtnUcakSeferEkle_Click(object sender, EventArgs e)
        {
            UCucakSeferleri ucakSeferleri = new UCucakSeferleri();
            panelEkle(ucakSeferleri);
        }

        private void BtnUcakEkle_Click(object sender, EventArgs e)
        {

        }

        private void BtnBiletlerim_Click(object sender, EventArgs e)
        {
            UCbiletlerim biletlerim = new UCbiletlerim();
            panelEkle(biletlerim);
        }
    }
}
