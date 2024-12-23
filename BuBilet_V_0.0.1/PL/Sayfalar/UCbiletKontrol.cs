using BuBilet_V_0._0._1.PL.Sayfalar;
using Npgsql;
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
    public partial class UCbiletKontrol : UserControl
    {
        public UCbiletKontrol()
        {
            InitializeComponent();
        }

        private void BtnBileAra_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM pnr_bilgisine_gore_bilet(@p_pnr);";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p_pnr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtPNR.Text;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tarihbilgisi = reader["tarih"].ToString();
                                DateTime sadecetarih = Convert.ToDateTime(tarihbilgisi);
                                sadecetarih = sadecetarih.Date;
                                UCbiletGorunum biletGorunum = new UCbiletGorunum();
                                biletGorunum.kalkisyeri = reader["kalkisyeri"].ToString();
                                biletGorunum.varisyeri = reader["varisyeri"].ToString();
                                biletGorunum.tarih = sadecetarih.ToString();
                                biletGorunum.pnrBilgisi = reader["pnr"].ToString();
                                biletGorunum.koltukno = reader["koltukno"].ToString();
                                biletGorunum.yolcuad = reader["yolcuad_gizli"].ToString();
                                biletGorunum.yolcusoyad = reader["yolcusoyad_gizli"].ToString();
                                biletGorunum.yolcutelefon = reader["yolcutelefon_gizli"].ToString();
                                Paneller paneller = new Paneller();
                                paneller.panelEkle(PnlAnaPanel, biletGorunum);
                            }
                            else
                            {
                                MessageBox.Show("Bilet bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
