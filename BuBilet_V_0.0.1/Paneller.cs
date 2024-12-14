using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace BuBilet_V_0._0._1
{
    internal class Paneller
    {
        public Form parentForm = new Form();

        public void panelEkle(Panel anaPanel, UserControl sayfalar, int kullaniciID)
        {
            if (sayfalar is UserControl control)
            {
                var propertyInfo = sayfalar.GetType().GetProperty("KullaniciID");
                if (propertyInfo != null && propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(sayfalar, kullaniciID);
                }
            }
            sayfalar.Dock = DockStyle.Fill;
            anaPanel.Controls.Clear();
            anaPanel.Controls.Add(sayfalar);
            sayfalar.BringToFront();
        }
        public void panelEkle(Panel anaPanel, UserControl sayfalar)
        {
            sayfalar.Dock = DockStyle.Fill;
            anaPanel.Controls.Clear();
            anaPanel.Controls.Add(sayfalar);
            sayfalar.BringToFront();
        }
    }
}
