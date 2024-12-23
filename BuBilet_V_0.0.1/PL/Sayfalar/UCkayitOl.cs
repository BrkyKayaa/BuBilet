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

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir seferi güncellemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using(var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        connection.Open();

                        string query = "CALL kayit_ol_kullanicilar(@p_kullaniciad, @p_kullanicisoyad, @p_eposta, @p_kullanicisifre, @p_kullanicitel);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_kullaniciad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtKullaniciAd.Text;
                            command.Parameters.AddWithValue("@p_kullanicisoyad", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtKullaniciSoyad.Text;
                            command.Parameters.AddWithValue("@p_eposta", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtEposta.Text;
                            command.Parameters.AddWithValue("@p_kullanicisifre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtSifre.Text;
                            command.Parameters.AddWithValue("@p_kullanicitel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtTelefon.Text;
                            command.ExecuteNonQuery();
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
}
