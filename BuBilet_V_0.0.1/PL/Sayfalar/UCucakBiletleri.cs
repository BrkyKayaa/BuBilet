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
                FlwPnlBiletler.Controls.Clear();
                for (int i = 0; i < 10; i++)
                {
                    Guna2Panel ucakPanelleri = new Guna2Panel
                    {
                        Name = "ucakPaneli" + i,
                        Size = new Size(664, 200),
                        BackColor = Color.FromArgb(6, 58, 111),
                        Location = new Point(3, 3),
                        Margin = new Padding(3, 3, 3, 3),
                        Tag = false
                    };

                    Label seferNumarasi = new Label
                    {
                        Name = "seferBilgileri",
                        Text = "Sefer " + i,
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

        private void BtnBiletAl_Click(object sender, EventArgs e)
        {

            if (sender is Guna2Button button && button.Tag is Guna2Panel ucakPanelleri)
            {
                var seferBilgileriLabel = ucakPanelleri.Controls
                                              .OfType<Label>()
                                              .FirstOrDefault(lbl => lbl.Name.StartsWith("seferBilgileri"));
                string seferNo = seferBilgileriLabel != null ? seferBilgileriLabel.Text : string.Empty;


                    MessageBox.Show($"Sefer No: {seferNo}");
                }
            }
        }
}
