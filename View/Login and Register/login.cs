using BANKING.DB.Repos;
using System;
using System.Windows.Forms;

namespace BANKING
{
    public partial class login : Form
    {
        // declare everything you need
        regis regis;
        Dashboard dashboard;
        buka buka;
        public static string LoggedUsername { get; private set; }

        public login()
        {
            InitializeComponent();
        }

        // declare some simple anti bruteforce, but i think its enough. i dont know if its sql injection got bypass or no 
        private int loginAttempts = 0;
        private int nullAttempts = 0;

        private void gunaButton2_Click(object sender, EventArgs e) // button login biasa (bukan login admin)
        {
            // declare everything you need
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;

            // detect if null = error, if 3x = exit (simple anit bruteforce)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                nullAttempts++;

                if (nullAttempts >= 3)
                {
                    MessageBox.Show("\"Anda belum memasukkan Username dan Password 3x. Aplikasi akan ditutup", "[PuhPay] Security System (Bruteforce)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Anda belum memasukkan Username dan Password!!", "[PuhPay] Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
            // declare the Login class
            Login userLogin = Login.GetLogin(username, password);

            if (userLogin != null) // if its not null we can go to the next step :)
            {
                LoggedUsername = username; // make sure we have this data in local 
                // Redirect to dashboard -> next step
                dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                loginAttempts++; // increase the login attempts

                if (loginAttempts >= 3) // if its 3x app is exited
                {
                    MessageBox.Show("Username atau Password anda salah 3x. Applikasi akan ditutup", "[PuhPay] Security System (Bruteforce)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Username atau Password anda salah silahkan coba lagi", "[PuhPay] Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // back to prelogin
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            buka = new buka();
            buka.Show();
            this.Hide();
        }
    }
}
