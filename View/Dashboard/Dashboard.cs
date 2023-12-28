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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
           uidashboard1.BringToFront();
            lblTitle.BringToFront();
        }
        bool transferExpand = false;
        private void transfertransisi_Tick(object sender, EventArgs e)
        {
            

            if (transferExpand == false)
            {
                transfercontainer.Height += 10;
                if (transfercontainer.Height >= 140)
                {
                    transfertransisi.Stop();
                    transferExpand = true;
                }
            }
            else
            {
                transfercontainer.Height -= 10;
                if (transfercontainer.Height <= 55)
                {
                    transfertransisi.Stop();
                    transferExpand = false;
                }
            }
        }

        private void btntransfer_Click(object sender, EventArgs e)
        {
            transfertransisi.Start();
        }
        bool sidebarexpand = false;
        private void sidebartransisi_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 54)
                {
                    sidebarexpand = false;
                    sidebartransisi.Stop();
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 134)
                {
                    sidebarexpand = true;
                    sidebartransisi.Stop();


                }
            }
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            sidebartransisi.Start();
        }
        
        private void uidasbor_Tick(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
           profile1.BringToFront();
            label1.BringToFront();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
           uidashboard1.BringToFront();
            lblTitle.BringToFront();
        }

        private void profile1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ceksaldo1_Load(object sender, EventArgs e)
        {

        }

        private void btnceksaldo_Click(object sender, EventArgs e)
        {
            //ceksaldo1.BringToFront();
            label2.BringToFront();
        }

        private void btnkeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
           about1.BringToFront();
            label3.BringToFront();
        }

        private void btndompetdigital_Click(object sender, EventArgs e)
        {
         topup1.BringToFront();
            label4.BringToFront();
        }

        private void btnrekening_Click(object sender, EventArgs e)
        {
          tfrek1.BringToFront();
            label4.BringToFront();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
          
        }

        private void topup1_Load(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void topup1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
