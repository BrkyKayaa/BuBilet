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
    public partial class UCotelRezervasyonlari : UserControl
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

        public UCotelRezervasyonlari()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnOtelAra_Click(object sender, EventArgs e)
        {
            if(CmbxAdres.Text == "")
            {
                MessageBox.Show("Lütfen gitmek istediğiniz ili seçiniz");
            }
            else
            {

                for(int i = 0; i < 10; i++)
                {
                    Panel otelPanelleri = new Panel()
                    {

                    };
                }


            }
        }
    }
}
