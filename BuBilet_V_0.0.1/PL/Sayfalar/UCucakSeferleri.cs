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
    public partial class UCucakSeferleri : UserControl
    {
        public UCucakSeferleri()
        {
            InitializeComponent();
            ucakSeferleriListele();
            ucakListele();
            DtgvUcaklar.ColumnHeadersHeight = 20;
            DtgvUcakSeferleri.ColumnHeadersHeight = 20;
        }

        private int _kullaniciID;
        public int KullaniciID
        {
            get => _kullaniciID;
            set
            {
                _kullaniciID = value;
            }
        }


        #region Listeleme işlemleri
        private void ucakSeferleriListele()
        {
            using(var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    string query = "SELECT ucakseferno, kalkisyeri, varisyeri, tarih, sure::TIME, fiyat, ucakid, alinabilirkoltuksayisi FROM seferler_ucak;";
                    using(var da = new NpgsqlDataAdapter(query,connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DtgvUcakSeferleri.DataSource = dt;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucakListele()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                try
                {
                    string query = "SELECT * FROM ucaklar;";
                    using (var da = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DtgvUcaklar.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region CRUD işlemleri
        private void BtnSeferEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir uçak seferi eklemek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL insert_seferler_ucak(@p_kalkisyeri, @p_varisyeri, @p_tarih, @p_sure, @p_fiyat, @p_ucakid);";

                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("p_kalkisyeri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CmbxkalkisYeri.Text;
                            command.Parameters.AddWithValue("p_varisyeri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CmbxVarisYeri.Text;
                            command.Parameters.Add(new NpgsqlParameter("p_tarih", NpgsqlTypes.NpgsqlDbType.Date)
                            {
                                Value = Dtpckrtarih.Value.Date
                            });

                            // DateTimePicker'dan gelen saat ve dakika bilgisini TimeSpan'e çevirme
                            DateTime sureZamani = Dtpckrtarih.Value.Date.Add(TimeSpan.Parse(MskdTxtsure.Text));

                            // TimeSpan doğrudan PostgreSQL'e gönderiliyor
                            command.Parameters.AddWithValue("p_sure", sureZamani);
                            command.Parameters.AddWithValue("p_fiyat", Convert.ToInt32(TxtFiyat.Text));
                            command.Parameters.AddWithValue("p_ucakid", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcakID.Text;
                            command.ExecuteNonQuery();

                            ucakSeferleriListele();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnSeferGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir uçak seferi güncellemek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL update_seferler_ucak(@p_ucakseferno, @p_kalkisyeri, @p_varisyeri, @p_tarih, @p_sure, " +
                            "@p_fiyat, @p_ucakid, @p_alinabilirkoltuksayisi);";

                        using(var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@p_ucakseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcakSeferNo.Text;
                            command.Parameters.AddWithValue("@p_kalkisyeri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CmbxkalkisYeri.Text;
                            command.Parameters.AddWithValue("@p_varisyeri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = CmbxVarisYeri.Text;

                            command.Parameters.Add(new NpgsqlParameter("p_tarih", NpgsqlTypes.NpgsqlDbType.Date)
                            {
                                Value = Dtpckrtarih.Value.Date
                            });

                            DateTime sureZamani = Dtpckrtarih.Value.Date.Add(TimeSpan.Parse(MskdTxtsure.Text));
                            command.Parameters.AddWithValue("@p_sure", sureZamani);
                            command.Parameters.AddWithValue("@p_fiyat", Convert.ToInt32(TxtFiyat.Text));
                            command.Parameters.AddWithValue("@p_ucakid", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcakID.Text;
                            command.Parameters.AddWithValue("@p_alinabilirkoltuksayisi", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(TxtFiyat.Text);

                            command.ExecuteNonQuery();
                            ucakSeferleriListele();
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
        private void BtnSeferSil_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bir uçak seferi güncellemek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL delete_seferler_ucak(@p_ucakseferno);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_ucakseferno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcakSeferNo.Text;
                            command.ExecuteNonQuery();
                            ucakSeferleriListele();
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
        private void BtnUcakEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir uçak eklemek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL insert_ucaklar(@p_toplamkoltuksayisi);";

                        using(var command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@p_toplamkoltuksayisi", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(TxtToplamKoltukSayisi.Text);
                            command.ExecuteNonQuery();

                            ucakListele();
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnUcakGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir uçak güncellemek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL update_ucaklar(@p_ucakid, @p_toplamkoltuksayisi);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_ucakid", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcaklarUcakID.Text;
                            command.Parameters.AddWithValue("@p_toplamkoltuksayisi", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(TxtToplamKoltukSayisi.Text);
                            command.ExecuteNonQuery();

                            ucakListele();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
             
        }
        private void BtnUcakSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir uçak silmek üzeresiniz, devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        string query = "CALL delete_ucaklar(@p_ucakid);";

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            command.Parameters.AddWithValue("@p_ucakid", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TxtUcaklarUcakID.Text;
                            command.ExecuteNonQuery();

                            ucakListele();
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region DataGridView eventleri
        private void DtgvUcakSeferleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtUcakSeferNo.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[0].Value.ToString();
            CmbxkalkisYeri.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[1].Value.ToString();
            CmbxVarisYeri.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[2].Value.ToString();
            string sureBilgisi = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime tarih = Convert.ToDateTime(sureBilgisi);
            Dtpckrtarih.Value = tarih;
            MskdTxtsure.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtFiyat.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtUcakID.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAlinabilirKoltuk.Text = DtgvUcakSeferleri.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void DtgvUcaklar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtUcakID.Text = DtgvUcaklar.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtUcaklarUcakID.Text = DtgvUcaklar.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtToplamKoltukSayisi.Text = DtgvUcaklar.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        #endregion

        private void LblAlanTemizle_Click(object sender, EventArgs e)
        {
            TxtAlinabilirKoltuk.Text = string.Empty;
            TxtFiyat.Text = string.Empty;
            TxtUcakID.Text = string.Empty;
            TxtUcakSeferNo.Text = string.Empty;
            MskdTxtsure.Text = string.Empty;
            CmbxkalkisYeri.Text = null;
            CmbxVarisYeri.Text = null;
        }

        private void LblAlanTemizleUcaklar_Click(object sender, EventArgs e)
        {
            TxtUcaklarUcakID.Text = null;
            TxtToplamKoltukSayisi.Text = null;
        }

        
    }
}
