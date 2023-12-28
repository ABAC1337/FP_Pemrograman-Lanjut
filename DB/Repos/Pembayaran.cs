using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BANKING.DB.Repos
{
    public class Pembayaran // classes for pembayaran
    {
        // declare everything you need
        public int IdPembayaran { get; set; }
        public string Jenis { get; set; }
        public int Jumlah { get; set; }
        public string Tujuan { get; set; }
        public string TujuanRekening { get; set; }
        public string Tanggal { get; set; }
        public string idRekening { get; set; }
        // constructor
        public Pembayaran(int idPembayaran, string jenis, int jumlah, string tujuan, string tujuanRekening, string tanggal, string IdRekening)
        {
            this.IdPembayaran = idPembayaran;
            this.Jenis = jenis;
            this.Jumlah = jumlah;
            this.Tujuan = tujuan;
            this.TujuanRekening = tujuanRekening;
            this.Tanggal = tanggal;
            this.idRekening = IdRekening;
        }
        // method for incrementing IdPembayaran
        private static int GenerateNewIdPembayaran(SQLiteConnection connection)
        {
            string query = "SELECT MAX(IdPembayaran) FROM Pembayaran";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) + 1;
                }

                return 1;
            }
        }
        // method for create or insert data to database
        public static Pembayaran Create(string jenis, int jumlah, string tujuan, string tujuanRekening, string tanggal, string IdRekening)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
            {
                connection.Open();
                string query = "INSERT INTO Pembayaran (IdPembayaran, jenis, jumlah, tujuan, tujuanRekening, tanggal, IdRekening)" +
                               "VALUES (@IdPembayaran, @jenis, @jumlah, @tujuan, @tujuanRekening, @tanggal, @IdRekening)";

                int IdPembayaran = GenerateNewIdPembayaran(connection);

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPembayaran", IdPembayaran);
                    command.Parameters.AddWithValue("@jenis", jenis);
                    command.Parameters.AddWithValue("@jumlah", jumlah);
                    command.Parameters.AddWithValue("@tujuan", tujuan);
                    command.Parameters.AddWithValue("@tujuanRekening", tujuanRekening);
                    command.Parameters.AddWithValue("@tanggal", tanggal);
                    command.Parameters.AddWithValue("@IdRekening", IdRekening);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return null;
            }
        }
        // method for get data from database
        public static List<Pembayaran> GetTransactionHistoryByIdRekening(string IdRekening)
        {
            List<Pembayaran> transactions = new List<Pembayaran>();

            using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
            {
                connection.Open();

                string query = "SELECT * FROM Pembayaran WHERE IdRekening = @IdRekening";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdRekening", IdRekening);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pembayaran transaction = new Pembayaran(
                                Convert.ToInt32(reader["IdPembayaran"]),
                                reader["jenis"].ToString(),
                                Convert.ToInt32(reader["jumlah"]),
                                reader["tujuan"].ToString(),
                                reader["tujuanRekening"].ToString(),
                                reader["tanggal"].ToString(),
                                reader["IdRekening"].ToString()
                            );

                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }
    }
}
