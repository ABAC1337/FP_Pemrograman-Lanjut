using System;
using System.Windows.Forms;
using BANKING.DB.Repos;

namespace BANKING
{
    public partial class login_admin : Form
    {
        public login_admin()
        {
            InitializeComponent();
        }



        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            admin_or_user admin_Or_User = new admin_or_user();
            admin_Or_User.Show();
            this.Close();
        }

        private int loginAttempts = 0;

        private void BTNlogin_Click_1(object sender, EventArgs e)
        {
            
            string username = usernameAdmin.Text;
            string password = passwordAdmin.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Masukan Username dan Password!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoginAdmin adminLogin = LoginAdmin.getAdminLogin(username, password);

            if (adminLogin != null)
            {
                // Successful login
                BtnReset admin = new BtnReset();
                admin.Show();
                this.Close();
            }
            else
            {
                loginAttempts++;

                if (loginAttempts >= 3)
                {
                    MessageBox.Show("Username atau Password anda salah 3x!! Applikasi akan ditutup (Security System).", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Username atau Password anda salah silahkan coba lagi!!", "Peringatan.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
