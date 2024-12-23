using Npgsql;
using Npgsql.PostgresTypes;
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
    public partial class UCotobusEkle : UserControl
    {
        public UCotobusEkle()
        {
            InitializeComponent();
            otobusListele();
            surucuListele();
            DtgvOtobusler.ColumnHeadersHeight = 20;
            DtgvSuruculer.ColumnHeadersHeight = 20;
        }

        private int _kullaniciID;
        public int KullaniciID
        {
            get => _kullaniciID;
            set
            {
                _kullaniciID = value;
                // KullanıcıID'yi label'da göster
                LblKullaniciID.Text = value > 0 ? $"{value}" : "0";
            }
        }

        private void otobusListele()
        {
            using(var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM otobusler;";
                    using (var da = new NpgsqlDataAdapter(query, connection)) 
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DtgvOtobusler.DataSource = dt;
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void surucuListele()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM suruculer;";
                    using (var da = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DtgvSuruculer.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DtgvOtobusler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOtobusID.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOtobusSurucuID.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtPlaka.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtMarka.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtModel.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtKoltukSayisi.Text = DtgvOtobusler.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void DtgvSuruculer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtSuruculerSurucuID.Text = DtgvSuruculer.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOtobusSurucuID.Text = DtgvSuruculer.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtSurucuAd.Text = DtgvSuruculer.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurucuSoyad.Text = DtgvSuruculer.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSurucuTel.Text = DtgvSuruculer.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        #region CRUD işlemleri
        private void BtnOtobusEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir otobüs eklemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        connection.Open();

                        string query = "CALL otobus_ekle_procedure(@p_surucuid, @p_plaka, @p_marka, @p_model, @p_toplamkoltuksayisi);";
                        
                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            if (string.IsNullOrWhiteSpace(TxtOtobusSurucuID.Text))
                            {
                                command.Parameters.AddWithValue("@p_surucuid", DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@p_surucuid", int.Parse(TxtOtobusSurucuID.Text));
                            }
                                
                            command.Parameters.AddWithValue("@p_plaka", TxtPlaka.Text);
                            command.Parameters.AddWithValue("@p_marka", TxtMarka.Text);
                            command.Parameters.AddWithValue("@p_model", TxtModel.Text);
                            command.Parameters.AddWithValue("@p_toplamkoltuksayisi", int.Parse(TxtKoltukSayisi.Text));

                            command.ExecuteNonQuery();
                            otobusListele();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
        }

        private void BtnOtobusGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir otobüsü güncellemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        connection.Open();

                        string query = "CALL otobus_guncelle_procedure(@p_otobusid, @p_surucuid, @p_plaka, @p_marka, @p_model, @p_toplamkoltuksayisi);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {

                            if (string.IsNullOrWhiteSpace(TxtOtobusSurucuID.Text))
                            {
                                command.Parameters.AddWithValue("@p_surucuid", DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@p_surucuid", int.Parse(TxtOtobusSurucuID.Text));
                            }
                            command.Parameters.AddWithValue("@p_otobusid",TxtOtobusID.Text);
                            command.Parameters.AddWithValue("@p_plaka", TxtPlaka.Text);
                            command.Parameters.AddWithValue("@p_marka", TxtMarka.Text);
                            command.Parameters.AddWithValue("@p_model", TxtModel.Text);
                            command.Parameters.AddWithValue("@p_toplamkoltuksayisi", int.Parse(TxtKoltukSayisi.Text));

                            command.ExecuteNonQuery();
                            otobusListele();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {

            }
        }

        private void BtnOtobusSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir otobüsü silmek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL otobus_sil_procedure(@p_otobusid);";

                        using(var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@p_otobusid",TxtOtobusID.Text);
                            command.ExecuteNonQuery();
                            otobusListele();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
        }

        private void BtnSurucuEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir sürücü eklemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        connection.Open();

                        string query = "CALL surucu_ekle_procedure(@p_surucuad, @p_surucusoyad, @p_surucutel);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_surucuad", TxtSurucuAd.Text);
                            command.Parameters.AddWithValue("@p_surucusoyad", TxtSurucuSoyad.Text);
                            command.Parameters.AddWithValue("@p_surucutel", TxtSurucuTel.Text);

                            command.ExecuteNonQuery();
                            surucuListele();
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
        }

        private void BtnSurucuGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir sürücü eklemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL surucu_guncelle_procedure(@p_surucuid, @p_surucuad, @p_surucusoyad, @p_surucutel);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_surucuid", int.Parse(TxtSuruculerSurucuID.Text));
                            command.Parameters.AddWithValue("@p_surucuad", TxtSurucuAd.Text);
                            command.Parameters.AddWithValue("@p_surucusoyad", TxtSurucuSoyad.Text);
                            command.Parameters.AddWithValue("@p_surucutel", TxtSurucuTel.Text);

                            command.ExecuteNonQuery();
                            surucuListele();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
        }

        private void BtnSurucuSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir sürücü eklemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        connection.Open();

                        string query = "CALL surucu_sil_procedure(@p_surucuid);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_surucuid", int.Parse(TxtOtobusSurucuID.Text));
                            command.ExecuteNonQuery();
                            surucuListele();
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
        }

        #endregion

        #region Temizleme satırları
        private void LblTemizleOtobus_Click(object sender, EventArgs e)
        {
            TxtKoltukSayisi.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            TxtOtobusID.Text = string.Empty;
            TxtOtobusSurucuID.Text = string.Empty;
            TxtPlaka.Text = string.Empty;
        }

        private void LblTemizleSuruculer_Click(object sender, EventArgs e)
        {
            TxtSuruculerSurucuID.Text = string.Empty;
            TxtSurucuAd.Text = string.Empty;
            TxtSurucuSoyad.Text = string.Empty;
            TxtSurucuTel.Text = string.Empty;
        }



        #endregion

    }
}
