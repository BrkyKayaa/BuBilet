using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuBilet_V_0._0._1.PL.Sayfalar
{
    public partial class UCkayitOl : UserControl
    {
        public UCkayitOl()
        {
            InitializeComponent();
        }

        private void UCkayitOl_Load(object sender, EventArgs e)
        {

        }

        private void LblAlanlariTemizle_Click(object sender, EventArgs e)
        {
            TxtKullaniciAd.Text = string.Empty;
            TxtKullaniciSoyad.Text = string.Empty;
            TxtEposta.Text = string.Empty;
            TxtSifre.Text = string.Empty;
            TxtTelefon.Text = string.Empty;
        }
    }
}
