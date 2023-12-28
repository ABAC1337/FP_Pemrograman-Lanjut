using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BANKING.DB.Repos
{
    public class Nasabah : DatabaseConnection // Class Nasabah and so many code in this class   
    {
        // declare everything you need
        public int IdNasabah { get; set; }
        public string Nik { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string TanggalLahir { get; set; }
        public string NoTelepon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IdRekening { get; set; }
        public int Saldo { get; set; }
        public string WaktuRegister { get; set; }

        // checking account using username its exists or no
        public static bool IsAccExists(string username)
        {
            connection.Open();
            string queryFind = "SELECT COUNT (*) AS RESULT FROM Nasabah WHERE username=@username";
            SQLiteCommand commandFind = new SQLiteCommand(queryFind, connection);
            commandFind.Parameters.AddWithValue("@username", username);
            SQLiteDataReader countReader = commandFind.ExecuteReader();

            bool exist = false;

            while (countReader.Read())
            {
                exist = int.Parse(countReader["result"].ToString()) > 0;
            }

            connection.Close();

            return exist;
        }
        // checking limit for nama
        public static bool IsNamaLimit3x(string nama)
        {
            connection.Open();
            string queryFind = "SELECT COUNT (*) AS RESULT FROM Nasabah WHERE nama=@nama";
            SQLiteCommand commandFind = new SQLiteCommand(queryFind, connection);
            commandFind.Parameters.AddWithValue("@nama", nama);
            SQLiteDataReader countReader = commandFind.ExecuteReader();

            bool exist = false;

            while (countReader.Read())
            {
                exist = int.Parse(countReader["result"].ToString()) > 0;
            }

            connection.Close();

            return exist;
        }
        // checking limit for nik
        public static bool IsNikLimit3x(string nik)
        {
            connection.Open();
            string queryFind = "SELECT COUNT (*) AS RESULT FROM Nasabah WHERE nik=@nik";
            SQLiteCommand commandFind = new SQLiteCommand(queryFind, connection);
            commandFind.Parameters.AddWithValue("@nik", nik);
            SQLiteDataReader countReader = commandFind.ExecuteReader();

            bool exist = false;

            while (countReader.Read())
            {
                exist = int.Parse(countReader["result"].ToString()) > 0;
            }

            connection.Close();

            return exist;
        }
        // checkig limit for email
        public static bool IsEmailLimit3x(string email)
        {
            connection.Open();
            string queryFind = "SELECT COUNT (*) AS RESULT FROM Nasabah WHERE email=@email";
            SQLiteCommand commandFind = new SQLiteCommand(queryFind, connection);
            commandFind.Parameters.AddWithValue("@email", email);
            SQLiteDataReader countReader = commandFind.ExecuteReader();

            bool exist = false;

            while (countReader.Read())
            {
                exist = int.Parse(countReader["result"].ToString()) > 0;
            }

            connection.Close();

            return exist;
        }
        // constructor
        public Nasabah(int idNasabah, string nama, string tanggalLahir, string username, string password, string noTelepon, string idRekening, int saldo, string Nik, string email, string waktuRegister)
        {
            this.IdNasabah = idNasabah;
            this.Nama = nama;
            this.TanggalLahir = tanggalLahir;
            this.Username = username;
            this.Password = password;
            this.NoTelepon = noTelepon;
            this.IdRekening = idRekening;
            this.Saldo = saldo;
            this.Nik = Nik;
            this.Email = email;
            this.WaktuRegister = waktuRegister;
        }
        // constructor
        public Nasabah(string idRekening)
        {
            this.IdRekening = idRekening;
        }
        // constructor
        public Nasabah(int saldo)
        {
            this.Saldo = saldo;
        }
        // method for incrementing IdNasabah
        private static int GenerateNewIdNasabah(SQLiteConnection connection)
        {
            string query = "SELECT MAX(IdNasabah) FROM Nasabah";

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
        public static Nasabah Create(string nama, string tanggalLahir, string username, string password, string nomortelpon, string idRekening, int saldo, string nik, string email, string waktuRegister)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();

                    // Assuming IdNasabah is an auto-incrementing primary key
                    string query = "INSERT INTO Nasabah (idNasabah, nama, tanggalLahir, username, password, notelpon, idRekening, saldo, nik, email, waktuRegister) " +
                                    "values (@idNasabah, @nama, @tanggalLahir, @username, @password, @notelpon, @idRekening, @saldo, @nik, @email, @waktuRegister)";

                    // If IdNasabah needs to be provided explicitly, use the following line to generate a new value
                    int idNasabah = GenerateNewIdNasabah(connection);
                    string hashedPassword = Encryption.GetHash(password);

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // If IdNasabah needs to be provided explicitly, use the following line to set the parameter
                        command.Parameters.AddWithValue("@idNasabah", idNasabah);
                        command.Parameters.AddWithValue("@nama", nama);
                        command.Parameters.AddWithValue("@tanggalLahir", tanggalLahir); // Use a valid date format
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.Parameters.AddWithValue("@notelpon", nomortelpon);
                        command.Parameters.AddWithValue("@idRekening", idRekening);
                        command.Parameters.AddWithValue("@saldo", saldo);
                        command.Parameters.AddWithValue("@nik", nik);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@waktuRegister", waktuRegister); // Use a valid date format
                        command.ExecuteNonQuery();
                        MessageBox.Show("Register Berhasil", "[PuhPay] Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        // method to get all data from database using username
        public static List<Nasabah> GetAllWithUsername(string username)
        {
            connection.Open();

            string query = "SELECT * FROM Nasabah WHERE username = @username";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                List<Nasabah> KoleksiNasabah = new List<Nasabah>();
                using (SQLiteDataReader nasabahReader = command.ExecuteReader())
                {
                    while (nasabahReader.Read())
                    {
                        Nasabah NasabahDariDB = new Nasabah(
                        int.Parse(nasabahReader["idNasabah"].ToString()),
                        nasabahReader["nama"].ToString(),
                        nasabahReader["tanggalLahir"].ToString(),
                        nasabahReader["username"].ToString(),
                        nasabahReader["password"].ToString(),
                        nasabahReader["notelpon"].ToString(),
                        nasabahReader["idRekening"].ToString(),
                        int.Parse(nasabahReader["saldo"].ToString()),
                        nasabahReader["nik"].ToString(),
                        nasabahReader["email"].ToString(),
                        nasabahReader["waktuRegister"].ToString()
                            );

                        KoleksiNasabah.Add(NasabahDariDB);
                    }
                }
                connection.Close();
                return KoleksiNasabah;
            }
        }
        // method to get all saldo from database using rekening
        public static List<Nasabah> GetAllSaldoWithRekening(string IdRekening)
        {
            connection.Open();

            string query = "SELECT saldo FROM Nasabah WHERE IdRekening = @IdRekening";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdRekening", IdRekening);
                List<Nasabah> KoleksiNasabah = new List<Nasabah>();
                using (SQLiteDataReader nasabahReader = command.ExecuteReader())
                {
                    while (nasabahReader.Read())
                    {
                        Nasabah NasabahDariDB = new Nasabah(
                        int.Parse(nasabahReader["saldo"].ToString())

                            );

                        KoleksiNasabah.Add(NasabahDariDB);
                    }
                }
                connection.Close();
                return KoleksiNasabah;
            }
        }
        // method to get all data from database
        public static List<Nasabah> GetAll()
        {
            connection.Open();

            string query = "SELECT * FROM Nasabah";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                List<Nasabah> KoleksiNasabah = new List<Nasabah>();
                using (SQLiteDataReader nasabahReader = command.ExecuteReader())
                {
                    while (nasabahReader.Read())
                    {
                        Nasabah NasabahDariDB = new Nasabah(
                        int.Parse(nasabahReader["idNasabah"].ToString()),
                        nasabahReader["nama"].ToString(),
                        nasabahReader["tanggalLahir"].ToString(),
                        nasabahReader["username"].ToString(),
                        nasabahReader["password"].ToString(),
                        nasabahReader["notelpon"].ToString(),
                        nasabahReader["idRekening"].ToString(),
                        int.Parse(nasabahReader["saldo"].ToString()),
                        nasabahReader["nik"].ToString(),
                        nasabahReader["email"].ToString(),
                        nasabahReader["waktuRegister"].ToString()
                        );

                        KoleksiNasabah.Add(NasabahDariDB);
                    }
                }
                connection.Close();
                return KoleksiNasabah;
            }

        }
        // method for get rekening with username
        public static string GetRekeningByUsername(string username)
        {
            string IdRekening = null;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT IdRekening FROM Nasabah WHERE username = @username";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IdRekening = reader["IdRekening"].ToString();
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data rekening (get) " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return IdRekening;
        }
        // method for get saldo with username
        public static int GetSaldoWithUsername(string username)
        {
            int saldo = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT saldo FROM Nasabah WHERE username = @username";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                saldo = Convert.ToInt32(reader["saldo"]);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data saldo" + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return saldo;
        }
        public static int GetSaldoWithIdNasabah(int IdNasabah)
        {
            int saldo = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT saldo FROM Nasabah WHERE IdNasabah = @IdNasabah";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdNasabah", IdNasabah);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                saldo = Convert.ToInt32(reader["saldo"]);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data saldo" + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return saldo;
        }
        // method for get saldo with id rekening
        public static int GetSaldoWithIdRekening(string IdRekening)
        {
            int saldo = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT saldo FROM Nasabah WHERE IdRekening = @IdRekening";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdRekening", IdRekening);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                saldo = Convert.ToInt32(reader["saldo"]);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data saldo " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return saldo;
        }
        // method for verify rekening
        public static Nasabah VerifyRekening(string idRekeningToVerify)
        {
            Nasabah verifiedNasabah = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "SELECT * FROM Nasabah WHERE IdRekening = @IdRekening";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdRekening", idRekeningToVerify);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Menggunakan reader.HasRows untuk mengecek apakah ada baris hasil
                            if (reader.HasRows)
                            {
                                // Jika ada hasil dari query, baca data Nasabah dan buat objek Nasabah
                                reader.Read();
                                verifiedNasabah = new Nasabah(
                                    reader["IdRekening"].ToString()
                                );
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data rekening (verify) " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return verifiedNasabah;
        }
        // method for update saldo current nasabah
        public static void UpdateSaldoNasabah(string username, int saldo)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "UPDATE Nasabah SET saldo = @saldo WHERE username = @username";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@saldo", saldo);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate data  " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // method for update saldo other nasabah
        public static void UpdateSaldoNasabahPuhPay(string IdRekening, int saldo)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();
                    string query = "UPDATE Nasabah SET saldo = @saldo WHERE IdRekening = @IdRekening";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdRekening", IdRekening);
                        command.Parameters.AddWithValue("@saldo", saldo);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate data  " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Hapus(int Idnasabah)
        {
            connection.Open();
            string query = "delete from Nasabah where IdNasabah = @IdNasabah";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@IdNasabah", Idnasabah);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void DepositSaldo(int idNasabah, int saldo)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Nasabah SET saldo = @saldo WHERE IdNasabah = @IdNasabah";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@saldo", saldo);
                        updateCommand.Parameters.AddWithValue("@IdNasabah", idNasabah);
                        updateCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to deposit: " + ex.Message, "[PuhPay] Debug System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
