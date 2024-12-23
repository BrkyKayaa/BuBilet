using BuBilet_V_0._0._1.Properties;
using Guna.UI2.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace BuBilet_V_0._0._1.PL.Sayfalar
{
    public partial class UCbiletlerim : UserControl
    {
        private int _kullaniciID;
        public int KullaniciID
        {
            get => _kullaniciID;
            set
            {
                _kullaniciID = value;
                LblKullaniciID.Text = value.ToString();
                ListOtobusBiletleri();
                ListUcakBiletleri();
            }
        }

        public UCbiletlerim()
        {
            InitializeComponent();
        }

        private void deneme()
        {
            for(int i = 0; i < 10; i++)
            {
                Guna2Panel otobusBiletleriPanelleri = new Guna2Panel
                {
                    Size = new Size(555, 60),
                    BackColor = Color.FromArgb(6, 58, 111),
                    Location = new Point(3, 3),
                    Margin = new Padding(3, 3, 3, 3),
                    Tag = false
                };

                Label pnrNumarasi = new Label
                {
                    Name = "LblpnrNumarasi",
                    Text = "PNR-BT000001".ToString(),
                    AutoSize = false,
                    Size = new Size(107, 20),
                    Location = new Point(10, 30),
                    ForeColor = Color.White,
                    Visible = true,
                };
                otobusBiletleriPanelleri.Controls.Add(pnrNumarasi);

                Label kalkisYeri = new Label
                {
                    Name = "LblkalkisYeri",
                    Text = "kalkisyeri".ToString(),
                    AutoSize = false,
                    Size = new Size(130, 13),
                    Location = new Point(126, 20),
                    ForeColor = Color.White,
                    Visible = true,
                };
                otobusBiletleriPanelleri.Controls.Add(kalkisYeri);

                Label varisYeri = new Label
                {
                    Name = "LblvarisYeri",
                    Text = "varisyeri".ToString(),
                    AutoSize = false,
                    Size = new Size(130, 13),
                    Location = new Point(333, 20),
                    ForeColor = Color.White,
                    Visible = true,
                };
                otobusBiletleriPanelleri.Controls.Add(varisYeri);

                Guna2PictureBox yonIsareti = new Guna2PictureBox
                {
                    Name = "yonIsareti",
                    Image = Resources.icons8_arrow_32,
                    Size = new Size(32, 32),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(250,13)
                };
                otobusBiletleriPanelleri.Controls.Add(yonIsareti);

                Label tarihYazisi = new Label
                {
                    Text = "Tarih:",
                    AutoSize = true,
                    Location = new Point(10, 10),
                    ForeColor = Color.White,
                    Visible = true,
                };
                otobusBiletleriPanelleri.Controls.Add(tarihYazisi);

                Label tarihBilgisi = new Label
                {
                    Name = "LblTarih",
                    Text = "20-12-2024".ToString(),
                    AutoSize = false,
                    Size = new Size(95, 20),
                    Location = new Point(50, 10),
                    ForeColor = Color.White,
                    Visible = true,
                };
                otobusBiletleriPanelleri.Controls.Add(tarihBilgisi);

                Guna2Button BtnInceleOtobus = new Guna2Button
                {
                    Name = "BtnInceleOtobus",
                    Text = "İncele",
                    Location = new Point(470, 13),
                    ForeColor = Color.White,
                    FillColor = Color.FromArgb(31, 155, 120),
                    Animated = true,
                    BorderRadius = 10,
                    Size = new Size(70, 30),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Tag = otobusBiletleriPanelleri,
                };

                Label LblKoltukNo = new Label
                {
                    Name = "LblKoltukNo",
                    Text = "KoltukNo",
                    Visible = false,
                };
                otobusBiletleriPanelleri.Controls.Add(LblKoltukNo);

                Label LblSatisTarihi = new Label
                {
                    Name = "LblSatisTarihi",
                    Text = "SatisTarihi",
                    Visible = false,
                };
                otobusBiletleriPanelleri.Controls.Add(LblSatisTarihi);

                Label LblYolcuAd = new Label
                {
                    Name = "LblYolcuAd",
                    Text = "YolcuAdı",
                    Visible = false,
                };
                otobusBiletleriPanelleri.Controls.Add(LblYolcuAd);

                Label LblYolcuSoyad = new Label
                {
                    Name = "LblYolcuSoyad",
                    Text = "YolcuSoyadı",
                    Visible = false,
                };
                otobusBiletleriPanelleri.Controls.Add(LblYolcuSoyad);

                Label LblYolcuTelefon = new Label
                {
                    Name = "LblYolcuTelefon",
                    Text = "YolcuTelefon",
                    Visible = false,
                };
                otobusBiletleriPanelleri.Controls.Add(LblYolcuTelefon);

                BtnInceleOtobus.Click += BtnInceleOtobus_Click;
                otobusBiletleriPanelleri.Controls.Add(BtnInceleOtobus);
                FlwPnlOtobusBiletleri.Controls.Add(otobusBiletleriPanelleri);
            }
        }



        private void ListOtobusBiletleri()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM list_kullanici_otobus_biletleri(@p_kullaniciid);";
                try
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p_kullaniciid", _kullaniciID);

                        using (var reader = command.ExecuteReader())
                        {
                            FlwPnlOtobusBiletleri.Controls.Clear();
                            while (reader.Read())
                            {
                                Guna2Panel otobusBiletleriPanelleri = new Guna2Panel
                                {
                                    Size = new Size(575, 60),
                                    BackColor = Color.FromArgb(6, 58, 111),
                                    Location = new Point(3, 3),
                                    Margin = new Padding(3, 3, 3, 3),
                                    Tag = false
                                };

                                Label pnrNumarasi = new Label
                                {
                                    Name = "LblpnrNumarasi",
                                    Text = reader["pnr_otobus"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(107, 20),
                                    Location = new Point(10, 30),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                otobusBiletleriPanelleri.Controls.Add(pnrNumarasi);

                                Label kalkisYeri = new Label
                                {
                                    Name = "LblkalkisYeri",
                                    Text = reader["kalkisyeri"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(130, 13),
                                    Location = new Point(126, 20),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                otobusBiletleriPanelleri.Controls.Add(kalkisYeri);

                                Label varisYeri = new Label
                                {
                                    Name = "LblvarisYeri",
                                    Text = reader["varisyeri"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(130, 13),
                                    Location = new Point(333, 20),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                otobusBiletleriPanelleri.Controls.Add(varisYeri);

                                Guna2PictureBox yonIsareti = new Guna2PictureBox
                                {
                                    Name = "yonIsareti",
                                    Image = Resources.icons8_arrow_32,
                                    Size = new Size(32, 32),
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Location = new Point(250, 13)
                                };
                                otobusBiletleriPanelleri.Controls.Add(yonIsareti);

                                Label tarihYazisi = new Label
                                {
                                    Text = "Tarih:",
                                    AutoSize = true,
                                    Location = new Point(10, 10),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                otobusBiletleriPanelleri.Controls.Add(tarihYazisi);

                                Label tarihBilgisi = new Label
                                {
                                    Name = "LblTarih",
                                    Text = reader["sefertarihi"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(95, 20),
                                    Location = new Point(50, 10),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                otobusBiletleriPanelleri.Controls.Add(tarihBilgisi);

                                Guna2Button BtnInceleOtobus = new Guna2Button
                                {
                                    Name = "BtnInceleOtobus",
                                    Text = "İncele",
                                    Location = new Point(470, 13),
                                    ForeColor = Color.White,
                                    FillColor = Color.FromArgb(31, 155, 120),
                                    Animated = true,
                                    BorderRadius = 10,
                                    Size = new Size(70, 30),
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                    Tag = otobusBiletleriPanelleri,
                                };

                                Label LblKoltukNo = new Label
                                {
                                    Name = "LblKoltukNo",
                                    Text = reader["koltukno"].ToString(),
                                    Visible = false,
                                };
                                otobusBiletleriPanelleri.Controls.Add(LblKoltukNo);

                                Label LblSatisTarihi = new Label
                                {
                                    Name = "LblSatisTarihi",
                                    Text = reader["satistarihi"].ToString(),
                                    Visible = false,
                                };
                                otobusBiletleriPanelleri.Controls.Add(LblSatisTarihi);

                                Label LblYolcuAd = new Label
                                {
                                    Name = "LblYolcuAd",
                                    Text = reader["yolcuad"].ToString(),
                                    Visible = false,
                                };
                                otobusBiletleriPanelleri.Controls.Add(LblYolcuAd);

                                Label LblYolcuSoyad = new Label
                                {
                                    Name = "LblYolcuSoyad",
                                    Text = reader["yolcusoyad"].ToString(),
                                    Visible = false,
                                };
                                otobusBiletleriPanelleri.Controls.Add(LblYolcuSoyad);

                                Label LblYolcuTelefon = new Label
                                {
                                    Name = "LblYolcuTelefon",
                                    Text = reader["yolcutelefon"].ToString(),
                                    Visible = false,
                                };
                                otobusBiletleriPanelleri.Controls.Add(LblYolcuTelefon);

                                BtnInceleOtobus.Click += BtnInceleOtobus_Click;
                                otobusBiletleriPanelleri.Controls.Add(BtnInceleOtobus);
                                FlwPnlOtobusBiletleri.Controls.Add(otobusBiletleriPanelleri);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}","Uyarı",MessageBoxButtons.OK);
                }
            }
        }

        private void ListUcakBiletleri()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM list_kullanici_ucak_biletleri(@p_kullaniciid);";
                try
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p_kullaniciid", _kullaniciID);

                        using (var reader = command.ExecuteReader())
                        {
                            FlwPnlUcakBiletleri.Controls.Clear();
                            while (reader.Read())
                            {
                                Guna2Panel ucakBiletleriPanelleri = new Guna2Panel
                                {
                                    Size = new Size(575, 60),
                                    BackColor = Color.FromArgb(6, 58, 111),
                                    Location = new Point(3, 3),
                                    Margin = new Padding(3, 3, 3, 3),
                                    Tag = false
                                };

                                Label pnrNumarasi = new Label
                                {
                                    Name = "LblpnrNumarasi",
                                    Text = reader["pnr_ucak"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(107, 20),
                                    Location = new Point(10, 30),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                ucakBiletleriPanelleri.Controls.Add(pnrNumarasi);

                                Label kalkisYeri = new Label
                                {
                                    Name = "LblkalkisYeri",
                                    Text = reader["kalkisyeri"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(130, 13),
                                    Location = new Point(126, 20),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                ucakBiletleriPanelleri.Controls.Add(kalkisYeri);

                                Label varisYeri = new Label
                                {
                                    Name = "LblvarisYeri",
                                    Text = reader["varisyeri"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(130, 13),
                                    Location = new Point(333, 20),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                ucakBiletleriPanelleri.Controls.Add(varisYeri);

                                Guna2PictureBox yonIsareti = new Guna2PictureBox
                                {
                                    Name = "yonIsareti",
                                    Image = Resources.icons8_arrow_32,
                                    Size = new Size(32, 32),
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Location = new Point(250, 13)
                                };
                                ucakBiletleriPanelleri.Controls.Add(yonIsareti);

                                Label tarihYazisi = new Label
                                {
                                    Text = "Tarih:",
                                    AutoSize = true,
                                    Location = new Point(10, 10),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                ucakBiletleriPanelleri.Controls.Add(tarihYazisi);

                                Label tarihBilgisi = new Label
                                {
                                    Name = "LblTarih",
                                    Text = reader["sefertarihi"].ToString(),
                                    AutoSize = false,
                                    Size = new Size(95, 20),
                                    Location = new Point(50, 10),
                                    ForeColor = Color.White,
                                    Visible = true,
                                };
                                ucakBiletleriPanelleri.Controls.Add(tarihBilgisi);

                                Guna2Button BtnInceleUcak = new Guna2Button
                                {
                                    Name = "BtnInceleUcak",
                                    Text = "İncele",
                                    Location = new Point(470, 13),
                                    ForeColor = Color.White,
                                    FillColor = Color.FromArgb(31, 155, 120),
                                    Animated = true,
                                    BorderRadius = 10,
                                    Size = new Size(70, 30),
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                    Tag = ucakBiletleriPanelleri,
                                };

                                Label LblKoltukNo = new Label
                                {
                                    Name = "LblKoltukNo",
                                    Text = reader["koltukno"].ToString(),
                                    Visible = false,
                                };
                                ucakBiletleriPanelleri.Controls.Add(LblKoltukNo);

                                Label LblSatisTarihi = new Label
                                {
                                    Name = "LblSatisTarihi",
                                    Text = reader["satistarihi"].ToString(),
                                    Visible = false,
                                };
                                ucakBiletleriPanelleri.Controls.Add(LblSatisTarihi);

                                Label LblYolcuAd = new Label
                                {
                                    Name = "LblYolcuAd",
                                    Text = reader["yolcuad"].ToString(),
                                    Visible = false,
                                };
                                ucakBiletleriPanelleri.Controls.Add(LblYolcuAd);

                                Label LblYolcuSoyad = new Label
                                {
                                    Name = "LblYolcuSoyad",
                                    Text = reader["yolcusoyad"].ToString(),
                                    Visible = false,
                                };
                                ucakBiletleriPanelleri.Controls.Add(LblYolcuSoyad);

                                Label LblYolcuTelefon = new Label
                                {
                                    Name = "LblYolcuTelefon",
                                    Text = reader["yolcutelefon"].ToString(),
                                    Visible = false,
                                };
                                ucakBiletleriPanelleri.Controls.Add(LblYolcuTelefon);

                                BtnInceleUcak.Click += BtnInceleUcak_Click;
                                ucakBiletleriPanelleri.Controls.Add(BtnInceleUcak);
                                FlwPnlUcakBiletleri.Controls.Add(ucakBiletleriPanelleri);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Uyarı", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnInceleUcak_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is Panel panel)
            {
                ToggleDetayPanelUcak(panel);
            }
        }

        private void BtnInceleOtobus_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is Panel panel)
            {
                ToggleDetayPanelOtobus(panel);
            }
        }

        private void ToggleDetayPanelUcak(Panel panel)
        {
            bool isExpanded = (bool)panel.Tag;
            if (!isExpanded)
            {
                panel.Size = new Size(575, 150);
                panel.Tag = !isExpanded;

                Label koltukyazisi = new Label
                {
                    Name = "koltukyazisi",
                    Text = "Koltuk No:",
                    AutoSize = true,
                    Location = new Point(10, 75),
                    ForeColor = Color.White,
                };
                panel.Controls.Add(koltukyazisi);

                Label koltukNumarasi = new Label
                {
                    Name = "LblKoltukNo",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblKoltukNo").Text,
                    Location = new Point(90, 75),
                };
                panel.Controls.Add(koltukNumarasi);

                Label yolcuAdiYazisi = new Label
                {
                    Name = "yolcuAdiYazisi",
                    Text = "Yolcu Adı:",
                    Location = new Point(10, 100),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuAdiYazisi);

                Label yolcuAdi = new Label
                {
                    Name = "LblYolcuAdi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuAd").Text,
                    Location = new Point(90, 100),
                };
                panel.Controls.Add(yolcuAdi);

                Label yolcuSoyadiYazisi = new Label
                {
                    Text = "Yolcu Soyadı:",
                    Location = new Point(10, 125),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuSoyadiYazisi);

                Label yolcuSoyadi = new Label
                {
                    Name = "LblYolcuSoyadi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuSoyad").Text,
                    Location = new Point(90, 125),
                };
                panel.Controls.Add(yolcuSoyadi);

                Label yolcuTelefonYazisi = new Label
                {
                    Text = "Yolcu Telefon:",
                    Location = new Point(250, 75),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuTelefonYazisi);

                Label LblYolcuTelefonNo = new Label
                {
                    Name = "LblYolcuTelefonNo",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuTelefon").Text,
                    AutoSize = true,
                    Location = new Point(330, 75),
                };
                panel.Controls.Add(LblYolcuTelefonNo);

                Label SatisTarihiYazisi = new Label
                {
                    Text = "Satış Tarihi:",
                    Location = new Point(250, 100),
                    AutoSize = true,
                };
                panel.Controls.Add(SatisTarihiYazisi);

                Label LblSatisTarihi = new Label
                {
                    Name = "LblSatisTarihi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblSatisTarihi").Text,
                    AutoSize = true,
                    Location = new Point(330, 100),
                };
                panel.Controls.Add(LblSatisTarihi);
            }
            else
            {
                panel.Size = new Size(575, 60);
                panel.Tag = !isExpanded;
            }
        }

        private void ToggleDetayPanelOtobus(Panel panel) 
        {
            bool isExpanded = (bool)panel.Tag;
            if (!isExpanded) 
            {
                panel.Size = new Size(575,150);
                panel.Tag = !isExpanded;

                Label koltukyazisi = new Label
                {
                    Name = "koltukyazisi",
                    Text = "Koltuk No:",
                    AutoSize = true,
                    Location = new Point(10,75),
                    ForeColor = Color.White,
                };
                panel.Controls.Add(koltukyazisi);

                Label koltukNumarasi = new Label
                {
                    Name = "LblKoltukNo",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblKoltukNo").Text,
                    Location = new Point(90,75),
                };
                panel.Controls.Add(koltukNumarasi);

                Label yolcuAdiYazisi = new Label
                {
                    Name = "yolcuAdiYazisi",
                    Text = "Yolcu Adı:",
                    Location = new Point(10, 100),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuAdiYazisi);

                Label yolcuAdi = new Label
                {
                    Name = "LblYolcuAdi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuAd").Text,
                    Location = new Point(90, 100),
                };
                panel.Controls.Add(yolcuAdi);

                Label yolcuSoyadiYazisi = new Label
                {
                    Text = "Yolcu Soyadı:",
                    Location = new Point(10, 125),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuSoyadiYazisi);

                Label yolcuSoyadi = new Label
                {
                    Name = "LblYolcuSoyadi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuSoyad").Text,
                    Location = new Point(90,125),
                };
                panel.Controls.Add(yolcuSoyadi);

                Label yolcuTelefonYazisi = new Label
                {
                    Text = "Yolcu Telefon:",
                    Location = new Point(250,75),
                    AutoSize = true,
                };
                panel.Controls.Add(yolcuTelefonYazisi);

                Label LblYolcuTelefonNo = new Label
                {
                    Name = "LblYolcuTelefonNo",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblYolcuTelefon").Text,
                    AutoSize = true,
                    Location = new Point(330, 75),
                };
                panel.Controls.Add(LblYolcuTelefonNo);

                Label SatisTarihiYazisi = new Label
                {
                    Text = "Satış Tarihi:",
                    Location = new Point(250,100),
                    AutoSize = true,
                };
                panel.Controls.Add(SatisTarihiYazisi);

                Label LblSatisTarihi = new Label
                {
                    Name = "LblSatisTarihi",
                    Text = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblSatisTarihi").Text,
                    AutoSize = true,
                    Location = new Point(330,100),
                };
                panel.Controls.Add(LblSatisTarihi);
            }
            else
            {
                panel.Size = new Size(575, 60);
                panel.Tag = !isExpanded;
            }
        }
    }
}
