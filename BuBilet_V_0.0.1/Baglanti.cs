using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BuBilet_V_0._0._1
{
    internal class Baglanti
    {
        // Berkay'ın PostgreSQL bilgileri
        public static string ConnectionString = "Server = localhost; port=5432;Database=BuBilet;User Id = postgres; Password=admin123;";
        public static NpgsqlConnection baglan = new NpgsqlConnection("Server = localhost; port=5432;Database=BuBilet;User Id = postgres; Password=admin123;");

        // Ahmet'in PostgreSQL bilgileri
        //public static string ConnectionString = "Server = localhost; port=5432;Database=BuBilet;User Id = postgres; Password=ahmet1234;";
        //public static NpgsqlConnection baglan = new NpgsqlConnection("Server = localhost; port=5432;Database=BuBilet;User Id = postgres; Password=ahmet1234;");
    }
}
