using Npgsql;
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
        }

        private void BtnSeferEkle_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            {
                connection.Open();

                // SQL sorgusunda :parametre kullanımı
                string query = "INSERT INTO seferler_otobus (otobusSeferNo, kalkisYeri, varisYeri, tarih, sure, fiyat, otobusID) " +
                               "VALUES (:seferNo, :kalkisYeri, :varisYeri, :tarih, :sure, :fiyat, :otobusID)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parametreleri ekleyelim
                    command.Parameters.AddWithValue("seferNo", "1253");
                    command.Parameters.AddWithValue("kalkisYeri", kalkisYeri.Text);
                    command.Parameters.AddWithValue("varisYeri", varisYeri.Text);

                    // Tarih
                    command.Parameters.Add(new NpgsqlParameter("tarih", NpgsqlTypes.NpgsqlDbType.Date)
                    {
                        Value = tarih.Value.Date
                    });

                    // DateTimePicker'dan gelen tarih
                    DateTime tarihDegeri = tarih.Value.Date; // datetimepicker'dan sadece tarih alıyoruz

                    // sure.Text'ten gelen saat ve dakika bilgisini TimeSpan'e çevir
                    TimeSpan sureZamani = TimeSpan.Parse(sure.Text); // Örneğin sure.Text = "02:30"

                    // Tarih ve zamanı birleştir
                    DateTime sureDegeri = tarihDegeri.Add(sureZamani); // Örneğin: "2024-06-07 02:30:00"

                    command.Parameters.AddWithValue("sure", sureDegeri);

                    // Fiyat (integer olarak)
                    command.Parameters.AddWithValue("fiyat", Convert.ToInt32(fiyat.Text));

                    // OtobusID
                    command.Parameters.AddWithValue("otobusID", otobusID.Text);

                    // Sorguyu çalıştır
                    command.ExecuteNonQuery();

                    MessageBox.Show("Sefer başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }





            //using (var connection = new NpgsqlConnection(Baglanti.ConnectionString))
            //{
            //    connection.Open();

            //    string query = "INSERT INTO otobusSeferleri VALUES ('@seferNo', '@kalkisYeri', '@varisYeri', '@tarih', '@sure', '@fiyat', '@otobusID')";



            //    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            //    {


            //        command.Parameters.AddWithValue("@seferNo", "1253");
            //        command.Parameters.AddWithValue("@kalkisYeri", kalkisYeri.Text);
            //        command.Parameters.AddWithValue("@varisYeri", varisYeri.Text);

            //        //AMK KODUNU BELİRTİP GONDERİYOM YİNE OLMUYO FORMATLAYIP GONDERİNCE DE OLMUYO
            //        //FRONTEND KSIMINA DA TAKILMA ONCE BACKEND YAPILIR KARDESİM
            //        command.Parameters.Add(new NpgsqlParameter("@tarih", NpgsqlTypes.NpgsqlDbType.Date)
            //        {
            //            Value = tarih.Value.Date
            //        });

            //        command.Parameters.AddWithValue("@sure", sure.Text);
            //        command.Parameters.AddWithValue("@fiyat", fiyat.Text);
            //        command.Parameters.AddWithValue("@otobusID", otobusID.Text);

            //        command.ExecuteNonQuery();
            //    }
            //}
        }
    
    }
}
