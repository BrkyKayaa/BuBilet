using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuBilet_V_0._0._1.PL.Sayfalar
{
    public partial class UCotobusSeferiEkle : UserControl
    {
        public UCotobusSeferiEkle()
        {
            InitializeComponent();
            otobusleriListele();
            otobusSeferleriListele();
            DtgvOtobusSeferleri.ColumnHeadersHeight = 20;
            DtgwOtobusler.ColumnHeadersHeight = 20;
        }

        private void BtnSeferEkle_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();

                // SQL'de seferler_otobus tablosuna ekleme yapan sorgu
                string query = "INSERT INTO seferler_otobus (kalkisYeri, varisYeri, tarih, sure, fiyat, otobusID) " +
                               "VALUES (:kalkisYeri, :varisYeri, :tarih, :sure, :fiyat, :otobusID)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parametreleri ekliyoruz
                    //command.Parameters.AddWithValue("seferNo", "1253");
                    command.Parameters.AddWithValue("kalkisYeri", CmbxkalkisYeri.Text);
                    command.Parameters.AddWithValue("varisYeri", CmbxvarisYeri.Text);

                    // Tarih
                    command.Parameters.Add(new NpgsqlParameter("tarih", NpgsqlTypes.NpgsqlDbType.Date)
                    {
                        Value = Dtpckrtarih.Value.Date
                    });

                    // DateTimePicker'dan gelen tarih
                    DateTime tarihDegeri = Dtpckrtarih.Value.Date; // datetimepicker'dan sadece tarih alıyoruz

                    // sure.Text'ten gelen saat ve dakika bilgisini TimeSpan'e çevirme
                    TimeSpan sureZamani = TimeSpan.Parse(MskdTxtsure.Text);

                    // Tarih ve zamanı birleştir
                    DateTime sureDegeri = tarihDegeri.Add(sureZamani); // Örnek: "2024-06-07 02:30:00"

                    command.Parameters.AddWithValue("sure", sureDegeri);

                    // Fiyat
                    command.Parameters.AddWithValue("fiyat", Convert.ToInt32(Txtfiyat.Text));

                    // OtobusID
                    command.Parameters.AddWithValue("otobusID", TxtotobusID.Text);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Sefer başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    otobusSeferleriListele();
                }
            }
        }

        private void otobusleriListele()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();

                string query = "SELECT otobusid, plaka, marka, model, toplamkoltuksayisi FROM otobusler";
                try
                {
                    using (var da = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DtgwOtobusler.DataSource = dt;
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Bir hata oluştu {ex.Message}", "Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void otobusSeferleriListele()
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();
                string query = "SELECT otobusseferno, kalkisyeri, varisyeri, tarih, sure::TIME, otobusid, fiyat, alinabilirkoltuksayisi" +
                    " FROM seferler_otobus;";

                try
                {
                    using (var da = new NpgsqlDataAdapter(query,connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DtgvOtobusSeferleri.DataSource = dt;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu {ex.Message}","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DtgwOtobusler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Datagrid view'e double click atıldığında ilk hücredeki değeri saklar.
            string cellValue = DtgwOtobusler.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtotobusID.Text = cellValue;
        }

        private void DtgvOtobusSeferleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string otobusSeferNo = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[0].Value.ToString();
            string kalkisYeri = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[1].Value.ToString();
            string varisYeri = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[2].Value.ToString();
            string tarihBilgisi = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime tarih = Convert.ToDateTime(tarihBilgisi);
            string sure = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[4].Value.ToString();
            string otobusid = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[5].Value.ToString();
            string fiyat = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[6].Value.ToString();
            string alinabilirKoltukSayisi = DtgvOtobusSeferleri.Rows[e.RowIndex].Cells[7].Value.ToString();

            TxtSeferNo.Text = otobusSeferNo;
            CmbxkalkisYeri.Text = kalkisYeri;
            CmbxvarisYeri.Text = varisYeri;
            Dtpckrtarih.Value = tarih;
            TxtotobusID.Text = otobusid;
            MskdTxtsure.Text = sure;
            Txtfiyat.Text = fiyat;
            TxtAlinabilirKoltukSayisi.Text = alinabilirKoltukSayisi;
        }

        private void LblAlanTemizle_Click(object sender, EventArgs e)
        {
            TxtSeferNo.Text = "";
            CmbxkalkisYeri.Text = null;
            CmbxvarisYeri.Text = null;
            MskdTxtsure.Text = "";
            Txtfiyat.Text = "";
            TxtotobusID.Text = "";
            TxtAlinabilirKoltukSayisi.Text = "";
        }

        private void BtnSeferSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir seferi silmek üzeresin yine de devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM seferler_otobus WHERE otobusSeferNo = @p1;";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p1", TxtSeferNo.Text);
                        int affectedRows = command.ExecuteNonQuery();
                        
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Sefer başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            otobusSeferleriListele();
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen sefer numarasına ait kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                
            }
            
        }

        private void BtnSeferGuncelle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bir seferi güncellemek üzeresin, devam etmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
                {
                    string query = "CALL update_sefer_otobus_procedure(@p_otobusseferno, @p_kalkisyeri, @p_varisyeri, @p_tarih," +
                        " @p_sure, @p_fiyat, @p_otobusid, @p_alinabilirkoltuksayisi);";

                    try
                    {
                        connection.Notice += (connSender, args) =>
                        {
                            MessageBox.Show($"Bilgi: {args.Notice.MessageText}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };

                        connection.Open();

                        using (var command = new NpgsqlCommand(query, connection)) 
                        {
                            var tarih = Dtpckrtarih.Value.Date; // Sadece tarih kısmı
                            DateTime sure;

                            // Saatin doğru formatta olduğundan emin olun
                            if (DateTime.TryParseExact(
                                    MskdTxtsure.Text,          // Kullanıcıdan gelen saat değeri
                                    "HH:mm",                   // Beklenen format
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None,
                                    out sure))                 // Çıkış değeri DateTime
                            {
                                DateTime tamTarihSaat = tarih.Add(sure.TimeOfDay);

                                // Parametreleri ekleme
                                command.Parameters.Add(new NpgsqlParameter("@p_tarih", NpgsqlDbType.Date) { Value = tarih });
                                command.Parameters.Add(new NpgsqlParameter("@p_sure", NpgsqlDbType.Timestamp) { Value = tamTarihSaat });
                            }
                            else
                            {
                                MessageBox.Show("Saat formatı geçersiz! Lütfen HH:mm formatında bir saat girin.");
                                return;
                            }

                            command.Parameters.Add(new NpgsqlParameter("@p_otobusseferno", NpgsqlDbType.Varchar) { Value = TxtSeferNo.Text });
                            command.Parameters.Add(new NpgsqlParameter("@p_kalkisyeri", NpgsqlDbType.Varchar) { Value = CmbxkalkisYeri.Text });
                            command.Parameters.Add(new NpgsqlParameter("@p_varisyeri", NpgsqlDbType.Varchar) { Value = CmbxvarisYeri.Text });
                            command.Parameters.Add(new NpgsqlParameter("@p_fiyat", NpgsqlDbType.Integer) { Value = int.Parse(Txtfiyat.Text) });
                            command.Parameters.Add(new NpgsqlParameter("@p_otobusid", NpgsqlDbType.Varchar) { Value = TxtotobusID.Text });
                            command.Parameters.Add(new NpgsqlParameter("@p_alinabilirkoltuksayisi", NpgsqlDbType.Integer) { Value = int.Parse(TxtAlinabilirKoltukSayisi.Text) });

                            command.ExecuteNonQuery();
                            otobusSeferleriListele();

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                }
            }
            else
            {

            }
        }

        private void UCotobusSeferiEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
