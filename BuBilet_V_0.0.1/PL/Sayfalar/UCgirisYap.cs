﻿using BuBilet_V_0._0._1.PL.Sayfalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BuBilet_V_0._0._1.Sayfalar
{
    public partial class UCgirisYap : UserControl
    {
        public int KullaniciID { get; set; }

        public event Action<int> GirisYapildi;

        public UCgirisYap()
        {
            InitializeComponent();
            PnlGirisYapAnaPanel.Controls.Add(PnlHesapBilgileri);
        }

        bool pnlKayitOlExpanded = false;

        private void TxtKullaniciAdi_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void TxtSifre_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void TmrHesapPanel_Tick(object sender, EventArgs e)
        {
            if (!pnlKayitOlExpanded) 
            {
                PnlKayıtOl.Width += 10;
                if(PnlKayıtOl.Width >= PnlKayıtOl.MaximumSize.Width)
                {
                    pnlKayitOlExpanded = true;
                    TmrHesapPanel.Stop();                }
            }
            else
            {
                PnlKayıtOl.Width -= 10;
                if(PnlKayıtOl.Width <= PnlKayıtOl.MinimumSize.Width)
                {
                    pnlKayitOlExpanded = false;
                    TmrHesapPanel.Stop();
                }
            }
        }

        private void PnlKayıtOl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnHesapYok_Click_1(object sender, EventArgs e)
        {
            TmrHesapPanel.Start();
        }

        public void panelEkle(UserControl sayfalar)
        {
            sayfalar.Dock = DockStyle.Fill;
            PnlHesapBilgileri.Controls.Clear();
            PnlHesapBilgileri.Controls.Add(sayfalar);
            sayfalar.BringToFront();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            UCkayitOl kayitSayfasi = new UCkayitOl();
            panelEkle(kayitSayfasi);
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

            // Veritabanı bağlantısı oluşturma kısmı
            using (var conn = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Sorgu: Girdiği bilgilere göre kullanıcıyı ve tüm sütunları seçecek
                    string query = "SELECT * FROM kullanicilar WHERE kullaniciad = @p1 AND kullanicisifre = @p2;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                        cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);

                        // Sorguyu çalıştır ve sonucu oku
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Eğer kullanıcı bulunduysa kullaniciID değerini al ve sakla
                                int kullaniciID = reader.GetInt32(reader.GetOrdinal("kullaniciid"));

                                MessageBox.Show("Giriş Başarılı");

                                // Giriş yapıldığında kullanıcıID'yi Form1'e ilet
                                GirisYapildi?.Invoke(kullaniciID);
                            }
                            else
                            {
                                // Kullanıcı girişi hatalı ise
                                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void UCgirisYap_Load(object sender, EventArgs e)
        {

        }
    }
}
