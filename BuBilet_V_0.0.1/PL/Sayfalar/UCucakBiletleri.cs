using BuBilet_V_0._0._1.Properties;
using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using Label = System.Windows.Forms.Label;
using Npgsql;

namespace BuBilet_V_0._0._1.Sayfalar
{
    public partial class UCucakBiletleri : UserControl
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

        public UCucakBiletleri()
        {
            InitializeComponent();
            DtpckTarih.MinDate = DateTime.Now;
        }

        private void PnlUcakBiletleriAna_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnUcakAra_Click(object sender, EventArgs e)
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
                    string query = "SELECT * FROM ListUcakSeferler(@p_hedefTarih::DATE, @p_kalkisYeri, @p_varisYeri);";
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
                                    Guna2Panel ucakPanelleri = new Guna2Panel
                                    {
                                        Name = "ucakPaneli",
                                        Size = new Size(685, 200),
                                        BackColor = Color.FromArgb(6, 58, 111),
                                        Location = new Point(3, 3),
                                        Margin = new Padding(3, 3, 3, 3),
                                        Tag = false
                                    };

                                    Label seferNumarasi = new Label
                                    {
                                        Name = "seferNumarasi",
                                        Text = reader["ucakseferno"].ToString(),
                                        AutoSize = false,
                                        Size = new Size(0, 0),
                                        Location = new Point(10, 10),
                                        ForeColor = Color.White,
                                        Visible = true,
                                    };
                                    ucakPanelleri.Controls.Add(seferNumarasi);

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
                                    ucakPanelleri.Controls.Add(seferBilgisi);

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
                                    ucakPanelleri.Controls.Add(LblKalkisYeri);

                                    Guna2PictureBox yonIsareti = new Guna2PictureBox
                                    {
                                        Image = Resources.icons8_arrow_32__2_,
                                        Size = new Size(32, 32),
                                        Location = new Point(245, 3),
                                        SizeMode = PictureBoxSizeMode.Zoom
                                    };
                                    ucakPanelleri.Controls.Add(yonIsareti);

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
                                    ucakPanelleri.Controls.Add(LblVarisYeri);

                                    Label LblYolcuAdi = new Label
                                    {
                                        Name = "LblYolcuAdi",
                                        Text = "Yolcu Adı:",
                                        AutoSize = false,
                                        Size = new Size(121, 23),
                                        Location = new Point(20, 60),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White,
                                    };
                                    ucakPanelleri.Controls.Add(LblYolcuAdi);


                                    Label LblYolcuSoyadi = new Label
                                    {
                                        Name = "LblYolcuSoyadi",
                                        Text = "Yolcu Soyadı:",
                                        AutoSize = false,
                                        Size = new Size(121, 23),
                                        Location = new Point(20, 100),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White,
                                    };
                                    ucakPanelleri.Controls.Add(LblYolcuSoyadi);


                                    Label LblYolcuTelefon = new Label
                                    {
                                        Name = "LblYolcuTelefon",
                                        Text = "Yolcu Telefon:",
                                        AutoSize = false,
                                        Size = new Size(121, 23),
                                        Location = new Point(20, 140),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        ForeColor = Color.White,
                                    };
                                    ucakPanelleri.Controls.Add(LblYolcuTelefon);



                                    Guna2TextBox TxtYolcuAdi = new Guna2TextBox
                                    {
                                        Name = "TxtYolcuAdi",
                                        PlaceholderForeColor = Color.Black,
                                        PlaceholderText = "Adınız",
                                        FillColor = Color.FromArgb(244, 245, 245),
                                        Size = new Size(150, 20),
                                        Location = new Point(141, 60),
                                        ForeColor = Color.Black,
                                        Animated = true,
                                    };
                                    ucakPanelleri.Controls.Add(TxtYolcuAdi);


                                    Guna2TextBox TxtYolcuSoyadi = new Guna2TextBox
                                    {
                                        Name = "TxtYolcuSoyadi",
                                        PlaceholderForeColor = Color.Black,
                                        PlaceholderText = "Soyadınız",
                                        FillColor = Color.FromArgb(244, 245, 245),
                                        Size = new Size(150, 20),
                                        Location = new Point(141, 100),
                                        ForeColor = Color.Black,
                                        Animated = true,
                                    };
                                    ucakPanelleri.Controls.Add(TxtYolcuSoyadi);


                                    Guna2TextBox TxtYolcuTelefon = new Guna2TextBox
                                    {
                                        Name = "TxtYolcuTelefon",
                                        PlaceholderForeColor = Color.Black,
                                        PlaceholderText = "Telefonunuz",
                                        FillColor = Color.FromArgb(244, 245, 245),
                                        Size = new Size(150, 20),
                                        Location = new Point(141, 140),
                                        ForeColor = Color.Black,
                                        Animated = true,
                                    };
                                    ucakPanelleri.Controls.Add(TxtYolcuTelefon);

                                    Guna2Button BtnBiletAl = new Guna2Button
                                    {
                                        Name = "BtnBiletAl",
                                        Text = "Bilet Al",
                                        Size = new Size(100, 40),
                                        Location = new Point(540, 130),
                                        BorderRadius = 17,
                                        Animated = true,
                                        ForeColor = Color.White,
                                        BackColor = Color.FromArgb(6, 58, 111),
                                        FillColor = Color.FromArgb(31, 155, 120),
                                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                        Tag = ucakPanelleri,
                                    };
                                    ucakPanelleri.Controls.Add(BtnBiletAl);
                                    BtnBiletAl.Click += BtnBiletAl_Click;

                                    FlwPnlBiletler.Controls.Add(ucakPanelleri);
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

        private void BtnBiletAl_Click(object sender, EventArgs e)
        {
            if(KullaniciID < 1) 
            {
                MessageBox.Show("Bilet almak için giriş yapmalısınız.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (sender is Guna2Button button && button.Tag is Guna2Panel ucakPanelleri)
                {
                    var seferBilgileriLabel = ucakPanelleri.Controls
                                                  .OfType<Label>()
                                                  .FirstOrDefault(lbl => lbl.Name.StartsWith("seferNumarasi"));
                    string seferNo = seferBilgileriLabel != null ? seferBilgileriLabel.Text : string.Empty;

                    var yolcuAd = ucakPanelleri.Controls
                                                  .OfType<Guna2TextBox>()
                                                  .FirstOrDefault(txt => txt.Name.StartsWith("TxtYolcuAdi"));
                    var yolcuSoyad = ucakPanelleri.Controls
                                                  .OfType<Guna2TextBox>()
                                                  .FirstOrDefault(txt => txt.Name.StartsWith("TxtYolcuSoyadi"));
                    var yolcuTelefon = ucakPanelleri.Controls
                                                  .OfType<Guna2TextBox>()
                                                  .FirstOrDefault(txt => txt.Name.StartsWith("TxtYolcuTelefon"));

                    MessageBox.Show($"Sefer No: {seferNo}");

                    if (MessageBox.Show("Bir bilet almak üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using(var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                        {
                            try
                            {
                                connection.Open();

                                string query = "SELECT insert_bilet_ucak_function(@p_kullaniciid, @p_ucakseferno, @p_satistarihi, @p_yolcuad, @p_yolcusoyad, @p_yolcutelefon);";

                                using (var command = new NpgsqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@p_kullaniciid", NpgsqlTypes.NpgsqlDbType.Integer).Value = KullaniciID;
                                    command.Parameters.AddWithValue("@p_ucakseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = seferNo;
                                    command.Parameters.AddWithValue("@p_satistarihi", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = DateTime.Now;
                                    command.Parameters.AddWithValue("@p_yolcuad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuAd.Text;
                                    command.Parameters.AddWithValue("@p_yolcusoyad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuSoyad.Text;
                                    command.Parameters.AddWithValue("@p_yolcutelefon", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuTelefon.Text;

                                    var result = command.ExecuteScalar();
                                    MessageBox.Show($"Sonuç: {result}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            // Prosedüre ulaşamıyor? Veritabanında çalıştırıyor ancak burada çalışmıyor çözemedim... Fonksiyon yazıp o şekilde çalıştıracağım.
                            // Prosedür sorununu çözdüm. prosedürde p_satistarihi değerini DATE tanımlamama rağmen DATE beklemiyor TIMESTAMP bekliyor,
                            // eğer satistarihi değerini TIMESTAMP yaparsam düzeliyor ama o kadar yordu ki bulana kadar uğraşmayacağım teşekkürler.
                            //try
                            //{
                            //    connection.Notice += (connSender, args) =>
                            //    {
                            //        MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    };
                            //    connection.Open();

                            //    string query = "CALL insert_bilet_ucak(@p_kullaniciid, @p_ucakseferno, @p_satistarihi, @p_yolcuad, @p_yolcusoyad, @p_yolcutelefon)";

                            //    using (var command = new NpgsqlCommand(query, connection))
                            //    {
                            //        command.Parameters.AddWithValue("@p_kullaniciid", NpgsqlTypes.NpgsqlDbType.Integer).Value = KullaniciID;
                            //        command.Parameters.AddWithValue("@p_ucakseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = seferNo;
                            //        command.Parameters.AddWithValue("@p_satistarihi", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Now.Date;
                            //        command.Parameters.AddWithValue("@p_yolcuad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuAd.Text;
                            //        command.Parameters.AddWithValue("@p_yolcusoyad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuSoyad.Text;
                            //        command.Parameters.AddWithValue("@p_yolcutelefon", NpgsqlTypes.NpgsqlDbType.Varchar).Value = yolcuTelefon.Text;

                            //        command.ExecuteNonQuery();
                            //    }

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                    }
                }
            }
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            string nereden = CmbxNereden.Text;
            CmbxNereden.Text = CmbxNereye.Text;
            CmbxNereye.Text = nereden;
        }

        // Veritabanından ucakseferno'suna göre alınmış koltukların numarasını çeken fonksiyon
    }
}
