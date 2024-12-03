using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuBilet_V_0._0._1.Sayfalar
{
    public partial class UCotobusler : UserControl
    {
        public UCotobusler()
        {
            InitializeComponent();
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
            for (int i = 0; i < 10; i++) 
            {
                Guna2Panel otobusPanelleri = new Guna2Panel
                {
                    Name = "otobusPaneli" + i,
                    Size = new Size(664, 50),
                    BackColor = Color.FromArgb(6, 58, 111),
                    Location = new Point(3, 3),
                    Margin = new Padding(3, 3, 3, 3),
                    Tag = false
                };

                Label seferBilgileri = new Label
                {
                    Text = "Sefer " + i,
                    Location = new Point(10,10),
                    ForeColor = Color.White,
                };

                Guna2Button BtnIncele = new Guna2Button
                {
                    Name = "BtnIncele" + i,
                    Text = "İncele",
                    Location = new Point(545,10),
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

                otobusPanelleri.Controls.Add(seferBilgileri);
                otobusPanelleri.Controls.Add(BtnIncele);

                FlwPnlBiletler.Controls.Add(otobusPanelleri);
            }
        }

        // İncele butonu için event
        private void BtnIncele_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is Panel panel)
            {
                TogglePanel(panel);
            }
        }


        // İncele butonuna basıldığında bilet paneli genişler ve koltukları oluşturur.
        private void TogglePanel(Panel panel)
        {
            bool isExpanded = (bool)panel.Tag;

            if (!isExpanded)
            {
                
                panel.Size = new Size(664, 220);

               
                Panel koltukPaneli = new Panel
                {
                    Name = "koltukPaneli",
                    Size = new Size(600, 150),
                    Location = new Point(20, 50),
                    BackColor = Color.FromArgb(230, 230, 245),
                };

                
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 11; col++)
                    {
                        Guna2Button Btnkoltuk = new Guna2Button
                        {
                            Size = new Size(40, 40),
                            BorderColor = Color.Black,
                            Animated = true,
                            BorderRadius = 5,
                        };

                        if(row == 0)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 3}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 5);
                        }
                        else if(row == 1)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 2}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 5);
                        }
                        else if(row == 2)
                        {
                            Btnkoltuk.Text = $"{col * 3 + 1}";
                            Btnkoltuk.Location = new Point(col * 45 + 10, row * 45 + 20);
                        }

                        Btnkoltuk.Click += Btnkoltuk_Click;

                        koltukPaneli.Controls.Add(Btnkoltuk);
                    }
                }

                panel.Controls.Add(koltukPaneli);
            }
            else
            {
                
                panel.Size = new Size(664, 50);

                var koltukPaneli = panel.Controls["koltukPaneli"];
                if (koltukPaneli != null)
                {
                    panel.Controls.Remove(koltukPaneli);
                    koltukPaneli.Dispose();
                }
            }

            panel.Tag = !isExpanded;
        }

        Label bilgi;
        private void Btnkoltuk_Click(object sender, EventArgs e) 
        {
            // seçilen koltuğa göre bilet işlemleri
            if(sender is Guna2Button button)
            {

                if (bilgi is null)
                {
                    bilgi = new Label
                    {
                        Text = "Bilgi" + " " + button.Text,
                        Location = new Point(100, 100),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                }
                else
                {
                    bilgi.Text = "Bilgi" + " " + button.Text;
                }
                
                 


                
                this.Controls.Add(bilgi);
            }

        }
    }
}
