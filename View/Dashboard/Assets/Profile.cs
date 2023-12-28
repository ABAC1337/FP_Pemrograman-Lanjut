using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class Profile : UserControl
    {
        // declare ui and list
        uidashboard uidashboard;
        List<Nasabah> KoleksiNasabah = new List<Nasabah>();
        public Profile()
        {
            InitializeComponent();
            ReloadProfileInfo();
        }
        // back to dashboard    
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            uidashboard.BringToFront();
        }
        // print profile info
        private void ReloadProfileInfo()
        {
            KoleksiNasabah = Nasabah.GetAllWithUsername(login.LoggedUsername); // get data from database using username for browse it

            usernameOutput.Text = "";   
            namaOutput.Text = "";
            notelponOutput.Text = "";
            emailOutput.Text = "";
            wakturegisterOutput.Text = "";
            tanggalLahirOutput.Text = "";
            nikOutput.Text = "";

            foreach (var nasabah in KoleksiNasabah)
            {
                usernameOutput.Text = nasabah.Username;
                namaOutput.Text = nasabah.Nama;
                notelponOutput.Text = nasabah.NoTelepon;
                emailOutput.Text = nasabah.Email;
                wakturegisterOutput.Text = nasabah.WaktuRegister;
                tanggalLahirOutput.Text = nasabah.Nik;
                nikOutput.Text = nasabah.TanggalLahir;
            }

        }
    }   
}
