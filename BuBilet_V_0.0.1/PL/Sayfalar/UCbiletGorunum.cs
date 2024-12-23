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
    public partial class UCbiletGorunum : UserControl
    {

        #region Getter Setter
        private string _pnrBilgisi;
        public string pnrBilgisi
        {
            get => _pnrBilgisi;
            set
            {
                _pnrBilgisi = value;
                LblPnr.Text = value.ToString();
            }
        }

        private string _koltukno;
        public string koltukno
        {
            get => _koltukno;
            set
            {
                _koltukno = value;
                LblKoltuk.Text = value.ToString();
            }
        }

        private string _yolcuad;
        public string yolcuad
        {
            get => _yolcuad;
            set
            {
                _yolcuad = value;
                LblYolcuAdı.Text = value.ToString();
            }
        }

        private string _yolcusoyad;
        public string yolcusoyad
        {
            get => _yolcusoyad;
            set
            {
                _yolcusoyad = value;
                LblYolcuSoyad.Text = value.ToString();
            }
        }

        private string _yolcutelefon;
        public string yolcutelefon
        {
            get => _yolcutelefon;
            set
            {
                _yolcutelefon = value;
                LblYolcuTel.Text = value.ToString();
            }
        }

        private string _kalkisyeri;
        public string kalkisyeri
        {
            get => _kalkisyeri;
            set
            {
                _kalkisyeri = value;
                LblKalkisYeri.Text = value.ToString();
            }
        }

        private string _varisyeri;
        public string varisyeri
        {
            get => _varisyeri;
            set
            {
                _varisyeri = value;
                LblVarisYeri.Text = value.ToString();
            }
        }

        private string _tarih;
        public string tarih
        {
            get => _tarih;
            set
            {
                _tarih = value;
                LblTarih.Text = value.ToString();
            }
        }

        #endregion
        public UCbiletGorunum()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
