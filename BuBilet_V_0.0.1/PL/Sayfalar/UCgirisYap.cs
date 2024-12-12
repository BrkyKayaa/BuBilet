using BuBilet_V_0._0._1.PL.Sayfalar;
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
        public UCgirisYap()
        {
            InitializeComponent();
        }

        bool pnlKayitOlExpanded = false;

        private void UCgirisYap_Load(object sender, EventArgs e)
        {

        }

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

        NpgsqlConnection baglan = new NpgsqlConnection("Server=localhost;port=5432;Database=VTYS-proje;User Id=postgres;Password=admin123;");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

            using (baglan)
            {
                try
                {
                    baglan.Open();

                    string query = "SELECT COUNT(*) FROM kullanicilar WHERE kullaniciad = @p1 AND kullanicisifre = @p2;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query,baglan))
                    {
                        cmd.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                        cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if(result == 1)
                        {
                            MessageBox.Show("Başarılı");
                        }
                        else
                        {
                            MessageBox.Show("Başarısız");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
                finally
                {
                    baglan.Close();
                }
            }
        }
    }
}
