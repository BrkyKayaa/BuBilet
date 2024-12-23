using BuBilet_V_0._0._1.Properties;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuBilet_V_0._0._1.Sayfalar
{

    public partial class UCotobusler : UserControl
    {

        private int _kullaniciID;
        public int KullaniciID
        {
            get => _kullaniciID;
            set
            {
                _kullaniciID = value;
                LblKullaniciID.Text = value.ToString();
            }
        }

        public UCotobusler()
        {
            InitializeComponent();
            PnlOtobuslerAnaPanel.Controls.Add(LblKullaniciID);
            PnlOtobuslerAnaPanel.Controls.Add(PnlSearch);
            PnlOtobuslerAnaPanel.Controls.Add(FlwPnlBiletler);
            DtpckTarih.MinDate = DateTime.Now;
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            string temp = CmbxNereden.Text;
            CmbxNereden.Text = CmbxNereye.Text;
            CmbxNereye.Text = temp;
        }

        private void FlwPnlBiletler_Paint(object sender, PaintEventArgs e)
        {

        }

        // Biletlerin olduğu panellerin oluşturulması
        private void BtnOtobusAra_Click(object sender, EventArgs e)
        {
            if (CmbxNereden.Text == "" || CmbxNereye.Text == "")
            {
                MessageBox.Show("Lütfen kalkış ve varış yerini seçiniz.");
            }
            else
            {
                // PostgreSQL fonksiyonuna gidecek değerleri çekiyoruz.
                DateTime hedefTarih = DtpckTarih.Value.Date;
                String kalkisYeri = CmbxNereden.Text;
                String varisYeri = CmbxNereye.Text;

                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM ListOtobusSeferler(@p_hedefTarih::DATE, @p_kalkisYeri, @p_varisYeri);";
                    try
                    {
                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@p_hedefTarih", hedefTarih);
                            command.Parameters.AddWithValue("@p_kalkisYeri", kalkisYeri);
                            command.Parameters.AddWithValue("@p_varisYeri", varisYeri);

                            using (var reader = command.ExecuteReader())
                            {
                                // Eğer gelecek veri varsa önceki verileri temizle.
                                FlwPnlBiletler.Controls.Clear();




                                while (reader.Read())
                                {
                                    Guna2Panel otobusPanelleri = new Guna2Panel
                                    {
                                        Size = new Size(685, 50),
                                        BackColor = Color.FromArgb(6, 58, 111),
                                        Location = new Point(3, 3),
                                        Margin = new Padding(3, 3, 3, 3),
                                        Tag = false
                                    };

                                    Label seferNumarasi = new Label
                                    {
                                        Name = "LblSeferNumarasi",
                                        Text = reader["seferNo"].ToString(),
                                        AutoSize = false,
                                        Size = new Size(0, 0),
                                        Location = new Point(10, 10),
                                        ForeColor = Color.White,
                                        Visible = true,
                                    };
                                    otobusPanelleri.Controls.Add(seferNumarasi);

                                    Label seferBilgisi = new Label
                                    {
                                        Name = "seferBilgisi",
                                        Text = "Sefer Bilgisi: ",
                                        AutoSize = false,
                                        Size = new Size(115, 25),
                                        Location = new Point(20, 10),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White
                                    };
                                    otobusPanelleri.Controls.Add(seferBilgisi);

                                    Label LblKalkisYeri = new Label
                                    {
                                        Name = "LblKalkisYeri",
                                        Text = CmbxNereden.Text,
                                        AutoSize = false,
                                        Size = new Size(100, 29),
                                        Location = new Point(135, 10),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White,
                                    };
                                    otobusPanelleri.Controls.Add(LblKalkisYeri);

                                    Guna2PictureBox yonIsareti = new Guna2PictureBox
                                    {
                                        Image = Resources.icons8_arrow_32__2_,
                                        Size = new Size(32, 32),
                                        Location = new Point(245, 3),
                                        SizeMode = PictureBoxSizeMode.Zoom
                                    };
                                    otobusPanelleri.Controls.Add(yonIsareti);

                                    Label LblVarisYeri = new Label
                                    {
                                        Name = "LblVarisYeri",
                                        Text = CmbxNereye.Text,
                                        AutoSize = false,
                                        Size = new Size(100, 29),
                                        Location = new Point(340, 10),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White
                                    };
                                    otobusPanelleri.Controls.Add(LblVarisYeri);


                                    Guna2Button BtnIncele = new Guna2Button
                                    {
                                        Name = "BtnIncele",
                                        Text = "İncele",
                                        Location = new Point(510, 10),
                                        ForeColor = Color.White,
                                        BackColor = otobusPanelleri.BackColor,
                                        FillColor = Color.FromArgb(31, 155, 120),
                                        Animated = true,
                                        BorderRadius = 10,
                                        Size = new Size(115, 25),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        Tag = otobusPanelleri,
                                    };

                                    BtnIncele.CustomizableEdges = new CustomizableEdges
                                    {
                                        BottomLeft = true,
                                        BottomRight = true,
                                        TopLeft = true,
                                        TopRight = true
                                    };
                                    BtnIncele.Click += BtnIncele_Click;
                                    otobusPanelleri.Controls.Add(BtnIncele);

                                    FlwPnlBiletler.Controls.Add(otobusPanelleri);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                    }


                }
            }

        }

        // İncele butonu için event
        private void BtnIncele_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is Panel panel)
            {
                ToggleKoltukPanel(panel);
            }
        }

        // İncele butonuna basıldığında bilet paneli genişler ve koltukları oluşturur.
        private void ToggleKoltukPanel(Panel panel)
        {
            bool isExpanded = (bool)panel.Tag;

            if (!isExpanded)
            {

                panel.Size = new Size(685, 390);


                Panel koltukPaneli = new Panel
                {
                    Name = "koltukPaneli",
                    Size = new Size(600, 150),
                    Location = new Point(20, 50),
                    BackColor = Color.FromArgb(230, 230, 245),
                };

                Panel yolcuBilgiPaneli = new Panel
                {
                    Name = "yolcuBilgiPaneli",
                    Size = new Size(600, 150),
                    Location = new Point(20, 210),
                    BackColor = Color.FromArgb(6, 58, 111)
                };

                Label LblYolcuAdi = new Label
                {
                    Name = "LblYolcuAdi",
                    Text = "Yolcu Adı:",
                    AutoSize = false,
                    Size = new Size(121, 23),
                    Location = new Point(0, 10),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                };
                yolcuBilgiPaneli.Controls.Add(LblYolcuAdi);


                Label LblYolcuSoyadi = new Label
                {
                    Name = "LblYolcuSoyadi",
                    Text = "Yolcu Soyadı:",
                    AutoSize = false,
                    Size = new Size(121, 23),
                    Location = new Point(0, 50),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                };
                yolcuBilgiPaneli.Controls.Add(LblYolcuSoyadi);


                Label LblYolcuTelefon = new Label
                {
                    Name = "LblYolcuTelefon",
                    Text = "Yolcu Telefon:",
                    AutoSize = false,
                    Size = new Size(121, 23),
                    Location = new Point(0, 90),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                };
                yolcuBilgiPaneli.Controls.Add(LblYolcuTelefon);

                Label LblYolcuKoltuk = new Label
                {
                    Name = "LblYolcuKoltuk",
                    Text = "Koltuk No:",
                    AutoSize = false,
                    Size = new Size(90, 23),
                    Location = new Point(320, 10),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                };
                yolcuBilgiPaneli.Controls.Add(LblYolcuKoltuk);


                Guna2TextBox TxtYolcuAdi = new Guna2TextBox
                {
                    Name = "TxtYolcuAdi",
                    PlaceholderForeColor = Color.Black,
                    PlaceholderText = "Adınız",
                    FillColor = Color.FromArgb(244, 245, 245),
                    Size = new Size(150, 20),
                    Location = new Point(121, 10),
                    ForeColor = Color.Black,
                    Animated = true,
                };
                yolcuBilgiPaneli.Controls.Add(TxtYolcuAdi);


                Guna2TextBox TxtYolcuSoyadi = new Guna2TextBox
                {
                    Name = "TxtYolcuSoyadi",
                    PlaceholderForeColor = Color.Black,
                    PlaceholderText = "Soyadınız",
                    FillColor = Color.FromArgb(244, 245, 245),
                    Size = new Size(150, 20),
                    Location = new Point(121, 50),
                    ForeColor = Color.Black,
                    Animated = true,
                };
                yolcuBilgiPaneli.Controls.Add(TxtYolcuSoyadi);


                Guna2TextBox TxtYolcuTelefon = new Guna2TextBox
                {
                    Name = "TxtYolcuTelefon",
                    PlaceholderForeColor = Color.Black,
                    PlaceholderText = "Telefonunuz",
                    FillColor = Color.FromArgb(244, 245, 245),
                    Size = new Size(150, 20),
                    Location = new Point(121, 90),
                    ForeColor = Color.Black,
                    Animated = true,
                };
                yolcuBilgiPaneli.Controls.Add(TxtYolcuTelefon);


                Guna2TextBox TxtYolcuKoltuk = new Guna2TextBox
                {
                    Name = "TxtYolcuKoltuk",
                    PlaceholderForeColor = Color.Black,
                    PlaceholderText = "Koltuk No",
                    FillColor = Color.FromArgb(244, 245, 245),
                    Size = new Size(150, 20),
                    Location = new Point(420, 10),
                    ForeColor = Color.Black,
                    Animated = true,
                    Enabled = false,
                };
                yolcuBilgiPaneli.Controls.Add(TxtYolcuKoltuk);


                Guna2Button BtnBiletAl = new Guna2Button
                {
                    Name = "BtnBiletAl",
                    Text = "Bilet Al",
                    Size = new Size(100, 40),
                    Location = new Point(420, 70),
                    BorderRadius = 17,
                    Animated = true,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(6, 58, 111),
                    FillColor = Color.FromArgb(31, 155, 120),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Tag = panel,
                };
                yolcuBilgiPaneli.Controls.Add(BtnBiletAl);
                BtnBiletAl.Click += BtnBiletAl_Click;

                var otobusseferno = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblSeferNumarasi");
                List<int> disabledKoltukNumbers = GetDisabledKoltuk(otobusseferno.Text.ToString());

                for (int col = 0; col < 11; col++)
                {
                    for (int row = 2; row >= 0; row--)
                    {
                        Guna2Button Btnkoltuk = new Guna2Button
                        {
                            Size = new Size(40, 40),
                            BorderColor = Color.Black,
                            Animated = true,
                            BorderRadius = 5,
                            Tag = panel
                        };

                        if (row == 0)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 3}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 5);
                        }
                        else if (row == 1)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 2}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 5);
                        }
                        else if (row == 2)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 1}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 20);
                        }

                        // Koltuk Başka birisi tarafından alınmışsa devre dışı bırakır.
                        if (disabledKoltukNumbers.Contains(Convert.ToInt32(Btnkoltuk.Text)))
                        {
                            Btnkoltuk.Enabled = false;
                            Btnkoltuk.FillColor = Color.Gray;
                        }

                        Btnkoltuk.Click += Btnkoltuk_Click;

                        koltukPaneli.Controls.Add(Btnkoltuk);
                    }
                }

                panel.Controls.Add(koltukPaneli);
                //yolcuBilgiPaneli.Controls.Add(seferBilgisi);
                panel.Controls.Add(yolcuBilgiPaneli);
            }
            else
            {

                panel.Size = new Size(685, 50);

                var koltukPaneli = panel.Controls["koltukPaneli"];
                if (koltukPaneli != null)
                {
                    panel.Controls.Remove(koltukPaneli);
                    koltukPaneli.Dispose();
                }
            }

            panel.Tag = !isExpanded;
        }

        private void Btnkoltuk_Click(object sender, EventArgs e)
        {
            // Seçilen koltuğa göre bilet işlemleri
            if (sender is Guna2Button button && button.Tag is Panel panel)
            {
                // Panel içindeki TxtYolcuKoltuk kontrolünü bulur
                var txtYolcuKoltuk = panel.Controls.OfType<Panel>()
                                                   .FirstOrDefault(p => p.Name == "yolcuBilgiPaneli")?
                                                   .Controls.OfType<Guna2TextBox>()
                                                   .FirstOrDefault(t => t.Name == "TxtYolcuKoltuk");
                var otobusseferno = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LblSeferNumarasi");
                var satistarihi = DateTime.Now.Date;

                if (txtYolcuKoltuk != null)
                {
                    txtYolcuKoltuk.Text = button.Text;
                }
            }
        }

        //Bilet Al butonu için event
        private void BtnBiletAl_Click(object sender, EventArgs e)
        {
            int kullaniciID;
            if (Int32.TryParse(LblKullaniciID.Text, out kullaniciID))
            {
                if (kullaniciID > 0)
                {
                    if (sender is Guna2Button button && button.Tag is Panel otobusPaneli)
                    {
                        var seferBilgileriLabel = otobusPaneli.Controls
                                                      .OfType<Label>()
                                                      .FirstOrDefault(lbl => lbl.Name.StartsWith("LblSeferNumarasi"));
                        string seferNo = seferBilgileriLabel != null ? seferBilgileriLabel.Text : string.Empty;

                        var yolcuBilgiPaneli = otobusPaneli.Controls
                                                   .OfType<Panel>()
                                                   .FirstOrDefault(p => p.Name == "yolcuBilgiPaneli");

                        if (yolcuBilgiPaneli != null)
                        {
                            var txtYolcuKoltuk = yolcuBilgiPaneli.Controls
                                                                 .OfType<Guna2TextBox>()
                                                                 .FirstOrDefault(txt => txt.Name == "TxtYolcuKoltuk");
                            int koltukNo = txtYolcuKoltuk != null && int.TryParse(txtYolcuKoltuk.Text, out int result) ? result : -1;

                            var yolcuad = yolcuBilgiPaneli.Controls.OfType<Guna2TextBox>().FirstOrDefault(txt => txt.Name == "TxtYolcuAdi").Text;
                            var yolcusoyad = yolcuBilgiPaneli.Controls.OfType<Guna2TextBox>().FirstOrDefault(txt => txt.Name == "TxtYolcuSoyadi").Text;
                            var yolcutelefon = yolcuBilgiPaneli.Controls.OfType<Guna2TextBox>().FirstOrDefault(txt => txt.Name == "TxtYolcuTelefon").Text;


                            //MessageBox.Show($"Sefer No: {seferNo}, Koltuk No: {koltukNo}");
                            if (koltukNo > 0)
                            {
                                if(yolcuad != "" && yolcusoyad != "" && yolcutelefon != "")
                                {
                                    if (MessageBox.Show("Bir bilet almak üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                                        {
                                            try
                                            {
                                                connection.Notice += (connSender, args) =>
                                                {
                                                    MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                };
                                                connection.Open();

                                                string query = "CALL insert_biletler_otobus(@p_kullaniciid, @p_otobusseferno, @p_koltukno, @p_satistarihi, @p_yolcuad, @p_yolcusoyad, @p_yolcutelefon);";

                                                using (var command = new NpgsqlCommand(query, connection))
                                                {
                                                    command.Parameters.AddWithValue("@p_kullaniciid", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(LblKullaniciID.Text);
                                                    command.Parameters.AddWithValue("@p_otobusseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = seferNo;
                                                    command.Parameters.AddWithValue("@p_koltukno", NpgsqlTypes.NpgsqlDbType.Integer).Value = koltukNo;
                                                    command.Parameters.AddWithValue("@p_satistarihi", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = DateTime.Now;
                                                    command.Parameters.AddWithValue("@p_yolcuad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuad;
                                                    command.Parameters.AddWithValue("@p_yolcusoyad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcusoyad;
                                                    command.Parameters.AddWithValue("@p_yolcutelefon", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcutelefon;

                                                    command.ExecuteNonQuery();
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Yolcu bilgileri kısmı boş bırakılamaz lütfen doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Bilet almak için öncelikle giriş yapmalısın!","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Bilet alabilmek için giriş yapmalısınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Veritabanından otobusseferno'suna göre alınmış koltukların numarasını çeken fonksiyon
        private List<int> GetDisabledKoltuk(string otobusseferno)
        {
            List<int> disabledKoltukNumbers = new List<int>();

            string query = "SELECT koltukno FROM biletler_otobus WHERE otobusseferno = @p_otobusseferno ORDER BY koltukno ASC;";

            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@p_otobusseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = otobusseferno;

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            disabledKoltukNumbers.Add(dr.GetInt32(0));
                        }
                    }
                }
            }
            return disabledKoltukNumbers;
        }
    }
}
