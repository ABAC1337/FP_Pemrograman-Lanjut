using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class topup : UserControl
    {
        List<Nasabah> KoleksiNasabah = new List<Nasabah>();
        private static int newSaldo;
        public topup()
        {
            InitializeComponent();
            ReloadSaldo();
        }

        // reload data (saldo) current nasabah
        public void ReloadSaldo()
        {
            newSaldo = SaldoManager.GetSaldo();
        }

        private void BTNtransfer_Click(object sender, EventArgs e)
        {
            ReloadSaldo(); // dont forget to reload this
            string tujuan = CBtujuanrektopup.SelectedItem.ToString();
            string virtualaccount = norekTopup.Text;
            string jumlah = jumlahTopup.Text;
            string jenis = "Topup";
            DateTime curr = DateTime.Now;
            string tanggal = curr.ToString("yyyy-MM-dd HH:mm:ss");
            int topup = int.Parse(jumlah);
            int taxes = 1000;
            string username = login.LoggedUsername;
            int currSaldo = Nasabah.GetSaldoWithUsername(username); // get current saldo from current nasabah   
            string currRekening = Nasabah.GetRekeningByUsername(username);
            string status = "Pengeluaran";
            int TotalMutasi = topup + taxes;

            // continue for the payment logic
            newSaldo = currSaldo - (topup + taxes); // new saldo after topup

            // if saldo minus its not enough, so make it pop up
            if (newSaldo < 0)
            {
                MessageBox.Show("Saldo tidak mencukupi untuk melakukan transfer.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // parent form
            uidashboard dashboard = (uidashboard)this.ParentForm.Controls["uidashboard1"];

            // update
            Nasabah.UpdateSaldoNasabah(username, newSaldo); // update new saldo for current nasabah
            dashboard?.ReloadSaldo();
           

            // Simpan data topup ke database
            Pembayaran.Create(jenis, topup, tujuan, virtualaccount, tanggal, currRekening);
            dashboard?.LoadTransactionHistory();

            // Simpan data Mutasi ke database
            Mutasi.CreateMutasi(TotalMutasi, status, currRekening, tanggal, virtualaccount);
            About aboutForm = (About)this.ParentForm.Controls["about1"];
            aboutForm?.ReloadMutasi();


            // success
            MessageBox.Show("Topup berhasil!", "[PuhPay] Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
