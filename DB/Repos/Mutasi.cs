using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BANKING.DB.Repos
{
    public class Mutasi
    {
        public int IdMutasi { get; set; }
        public int Saldo { get; set; }
        public string StatusMutasi { get; set; }
        public string IdRekening { get; set; }
        public string Tanggal { get; set; }
        public string TujuanRekening { get; set; }

        public Mutasi(int id, int saldo, string status, string IdRekening, string tanggal, string tujuanRekening)
        {
            this.IdMutasi = id;
            this.Saldo = saldo;
            this.StatusMutasi = status;
            this.IdRekening = IdRekening;
            this.Tanggal = tanggal;
            TujuanRekening = tujuanRekening;
        }

        public static Mutasi CreateMutasi(int saldo, string statusMutasi, string IdRekening, string tanggal, string tujuanRekening)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Mutasi (saldo, StatusMutasi, IdRekening, tanggal, tujuanRekening) VALUES (@saldo, @statusMutasi, @IdRekening, @tanggal, @tujuanRekening)";
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@saldo", saldo);
                        insertCommand.Parameters.AddWithValue("@statusMutasi", statusMutasi);
                        insertCommand.Parameters.AddWithValue("@IdRekening", IdRekening);
                        insertCommand.Parameters.AddWithValue("@tanggal", tanggal);
                        insertCommand.Parameters.AddWithValue("@tujuanRekening", tujuanRekening);
                        insertCommand.ExecuteNonQuery();
                    }

                    string selectQuery = "SELECT last_insert_rowid()";
                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                    {
                        int idMutasi = Convert.ToInt32(selectCommand.ExecuteScalar());

                        // Return the newly created Mutasi object
                        return new Mutasi(idMutasi, saldo, statusMutasi, IdRekening, tanggal, tujuanRekening);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat data mutasi " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public static List<Mutasi> GetAllMutasiWithRekening(string IdRekening)
        {
            List<Mutasi> mutasiList = new List<Mutasi>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT * FROM Mutasi WHERE IdRekening = @IdRekening";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdRekening", IdRekening);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idMutasi = Convert.ToInt32(reader["IdMutasi"]);
                                int saldo = Convert.ToInt32(reader["Saldo"]);
                                string statusMutasi = reader["StatusMutasi"].ToString();
                                string tanggal = reader["tanggal"].ToString();
                                IdRekening = reader["IdRekening"].ToString();
                                string tujuanRekening = reader["tujuanRekening"].ToString();
                                Mutasi mutasi = new Mutasi(idMutasi, saldo, statusMutasi, IdRekening, tanggal, tujuanRekening);
                                mutasiList.Add(mutasi);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data mutasi " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return mutasiList;
        }

    }
}