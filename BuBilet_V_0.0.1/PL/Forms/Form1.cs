using BuBilet_V_0._0._1.PL.Sayfalar;
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
            }
        }

        /* 
           VALLA VALUE MALUE BİSİLER DENEDİM SENİN YAPTIGIN GİBİ 
           BECEREMEDİM EGER ASAGIDAKİ FONKSİYONU YAZMASAM BİLEKLERİMİ KESECEKTİM ALLAMA
           
           Bunu direkt kullaniciAdi sifre kontrol kismina ekleyecektim ama sen kullaniciID
           gonderen event ekledigin icin cakisiyo ilerde duzenlerim
        */
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

                            //  adminse seferEkle butonunu gorunur yap degilse gizle
                            if (kullaniciTuru == "admin")
                                BtnOSEAktiflestir();
                            else
                                BtnOSEGizle();
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
            BtnOtobusSeferiEkle.Visible = false;
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

        //Otobus Seferi Ekle butonunu aktiflestirir ve gizler
        public void BtnOSEAktiflestir()
        {
            BtnOtobusSeferiEkle.Visible = true;
        }
        public void BtnOSEGizle()
        {
            BtnOtobusSeferiEkle.Visible = false;
        }

        // Sidebar kontrollerini devre dışı bıraktık bu kodlar geçersiz
        private void BtnSideBarControl_Click(object sender, EventArgs e)
        {
            TmrSideBarTransition.Start();
        }

        bool sideBarExpand = true;

        // Sidebar kontrolleri devre dışı bu kodlar geçersiz
        private void TmrSideBarTransition_Tick(object sender, EventArgs e)
        {
            if (!sideBarExpand)
            {
                PnlSidebar.Width += 10;
                if (PnlSidebar.Width >= PnlSidebar.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    TmrSideBarTransition.Stop();
                }
            }
            else
            {
                PnlSidebar.Width -= 10;
                if (PnlSidebar.Width <= PnlSidebar.MinimumSize.Width)
                {
                    sideBarExpand = false;
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
                BtnOSEGizle();  //Admin cikis yapmis ise butonlar gizlenir.
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
    }
}
