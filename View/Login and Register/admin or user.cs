using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANKING
{
    public partial class admin_or_user : Form
    {
        public admin_or_user()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e) //button login (admin) or user
        {
            login_admin login_Admin = new login_admin();
            login_Admin.Show();
            this.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e) //button login (nasabah) or admin
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            buka buka = new buka();
            buka.Show();
            this.Close();
        }
    }
}
