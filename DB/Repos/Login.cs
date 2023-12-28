using System;
using System.Data.SQLite;

namespace BANKING.DB.Repos
{
    public class Login // Classes for login
    {
        // declare everything you need
        public int IdNasabah { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // constructor
        public Login(int idNasabah, string username, string password)
        {
            this.IdNasabah = idNasabah;
            this.Username = username;
            this.Password = password;
        }

        // method for login (read username and password)
        public static Login GetLogin(string username, string password) 
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
            {
                connection.Open();

                // Query untuk mengambil informasi login berdasarkan username dan password
                string query = "SELECT * FROM Nasabah WHERE username=@username AND password=@password";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", Encryption.GetHash(password));

                    using (SQLiteDataReader loginReader = command.ExecuteReader())
                    {
                        if (loginReader.Read())
                        {
                            int id = Convert.ToInt32(loginReader["IdNasabah"]);
                            string user = loginReader["username"].ToString();
                            string pass = loginReader["password"].ToString();
                            connection.Close();
                            return new Login(id, user, pass);
                        }
                    }
                }
                return null;
            }
        }
    }

    public class LoginAdmin // classes for login admin
    {
        // declare everything you need
        public int IdAdmin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        // constructor
        public LoginAdmin(int idAdmin, string username, string password)
        {
            IdAdmin = idAdmin;
            this.username = username;
            this.password = password;
        }
        // same method for login
        public static LoginAdmin getAdminLogin(string username, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseConnection.connection))
            {
                connection.Open();
                string query = "SELECT * FROM Admin WHERE username=@username AND password=@password";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (SQLiteDataReader loginReader = command.ExecuteReader())
                    {
                        if (loginReader.Read())
                        {
                            int id = Convert.ToInt32(loginReader["IdAdmin"]);
                            string user = loginReader["username"].ToString();
                            string pass = loginReader["password"].ToString();
                            connection.Close();
                            return new LoginAdmin(id, user, password);
                        }
                    }
                }
            }
            return null;
        }
    }
}
