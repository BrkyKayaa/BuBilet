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
    }
}
