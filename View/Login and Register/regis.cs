using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BANKING.DB.Repos;

namespace BANKING
{
    public partial class regis : Form
    {
        login login;
        public regis()
        {
            InitializeComponent();
        }
        // we dont have time to add from admin listview, so we just generate random number
        // time is money
        private string GenerateNoRek(string idRekening)
        {
            Random random = new Random();  // declare random
            HashSet<int> uniqueNum = new HashSet<int>(); // using hash to make sure we not generate same uniqe number
            int numRek = 0;

            while (uniqueNum.Count < 1)
            {
                numRek = random.Next(1000000, 9999999); // rekening have 10-13 digit in general, so we choose 10

                if (!uniqueNum.Contains(numRek))
                {
                    uniqueNum.Add(numRek);
                }
            }

            idRekening = "133" + numRek.ToString(); // convert to string, if not error :)
            return idRekening;
        }

        private void gunaButton2_Click(object sender, EventArgs e) //button login register
        {
            // checking with null if null its error, also checking if account is exists or email, nik, nama are limit, limit = 3x
            if (string.IsNullOrEmpty(usernameReg.Text) || string.IsNullOrEmpty(passwordReg.Text) || string.IsNullOrEmpty(namaReg.Text)
                || string.IsNullOrEmpty(emailReg.Text) || string.IsNullOrEmpty(nikReg.Text))
            {
                MessageBox.Show("Silahkan memasukkan data diri anda!", "[PuhPay] Data diri kosong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!this.emailReg.Text.Contains('@') || !this.emailReg.Text.Contains('.')) // email must contain @ and .
            {
                MessageBox.Show("Anda memasukkan email yang salah!", "[PuhPay] Email Salah!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Nasabah.IsAccExists(usernameReg.Text))
            {
                MessageBox.Show("Sudah mempunyai akun", "[PuhPay] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Nasabah.IsNikLimit3x(nikReg.Text))
            {
                MessageBox.Show("Nik anda sudah digunakan 3 rekening", "[PuhPay] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Nasabah.IsNamaLimit3x(namaReg.Text))
            {
                MessageBox.Show("Nama anda sudah digunakan 3 rekening", "[PuhPay] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Nasabah.IsEmailLimit3x(emailReg.Text))
            {
                MessageBox.Show("Email anda sudah digunakan 3 rekening", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // declare everything you need
            int saldo = 0;
            string idRekening = "";
            DateTime currtime = DateTime.Now;
            DateTime datetimepicker = guna2DateTimePicker1.Value;
            string waktuRegister = currtime.ToString("dd-MM-yyyy HH:mm:ss");
            string tanggalLahir = datetimepicker.ToString("dd-MM-yyyy");

            // create account is for insert database table Nasabah
            Nasabah Account = Nasabah.Create(
                namaReg.Text,
                tanggalLahir,
                usernameReg.Text,
                passwordReg.Text,
                notelpReg.Text,
                GenerateNoRek(idRekening),
                saldo,
                nikReg.Text,
                emailReg.Text,
                waktuRegister
                );

            // if its done, the next step is to login
            login = new login();
            login.Show();
            this.Hide();

        }
        // for back to first page / prelogin
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            buka buka = new buka();
            buka.Show();
            this.Close();
        }


    }
}
