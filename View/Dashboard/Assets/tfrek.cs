using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class tfrek : UserControl
    {
        // declare some variable
        private static int newSaldo;
        private static int newSaldoPuhPay;
        private static string IdRekening;

        public tfrek()
        {
            // initialize some function
            InitializeComponent();
            ReloadSaldo();                          // for reload current nasabah
            ReloadSaldoNasabahPuhPay(IdRekening);  // for reload other nasabah
        }

        // reload data (saldo) current nasabah
        public void ReloadSaldo()
        {
            newSaldo = SaldoManager.GetSaldo();
        }

        // reload data (saldo) from other nasabah
        // why we put in here, cuz we only use this function on transfer (not actual value for current nasabah, its for other nasabah) 
        public static int ReloadSaldoNasabahPuhPay(string IdRekening)
        {
            List<Nasabah> koleksiNasabah = Nasabah.GetAllSaldoWithRekening(IdRekening); // get all saldo means that search saldo from other nasabah with same rekening

            foreach (var nasabah in koleksiNasabah)
            {
                newSaldoPuhPay = nasabah.Saldo;
            }

            return newSaldoPuhPay;
        }

        private void BTNtransfer_Click(object sender, EventArgs e)
        {
            ReloadSaldo();
            // declare variable and everything we need
            string username = login.LoggedUsername;
            string tujuan = CBbanktujuan.SelectedItem.ToString();
            string norekeningTujuan = tujuannoRekening.Text;
            string jumlah = jumlahTransferRek.Text;
            string layanan = CBlayanantrf.Text;
            string jenis = "Transfer";
            DateTime currtime = DateTime.Now;
            string tanggal = currtime.ToString("yyyy-MM-dd HH:mm:ss");
            int taxes;
            int jumlahTransfer = int.Parse(jumlah);
            int currSaldo = Nasabah.GetSaldoWithUsername(username); // get current saldo from current nasabah    
            string currRekening = Nasabah.GetRekeningByUsername(username); //  get current rekening from current nasabah
            string status = "Pengeluaran"; // for mutasi
            int totalMutasi;


            // its like admin taxes but same like other mobile banking
            // taxes too high :))

            if (layanan == "Bifast")
            {
                taxes = 2500;
            }
            else if (layanan == "Realtime")
            {
                taxes = 6500;
            }
            else
            {
                MessageBox.Show("Layanan transfer tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // make puhpay diffrent, need verify rekening for it, 
            // no admin taxes (combobox for layanan not affected), get saldo from other nasabah, send money to other nasabah
            if (tujuan == "PuhPay")
            {
                Nasabah norek = Nasabah.VerifyRekening(norekeningTujuan);
                if (norek == null)
                {
                    MessageBox.Show("Nomor rekening tujuan tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                newSaldo = currSaldo - jumlahTransfer;
                int currSaldoPuhPay = Nasabah.GetSaldoWithIdRekening(norekeningTujuan); // get current saldo from other nasabah method searching rekening
                
                int totalTransfer = currSaldoPuhPay + jumlahTransfer;
                totalMutasi = jumlahTransfer;
                // update
                Nasabah.UpdateSaldoNasabahPuhPay(norekeningTujuan, totalTransfer);

                // create data for mutasi other nasabah
                string status2 = "Pemasukan";
                Mutasi.CreateMutasi(totalMutasi, status2, currRekening, tanggal, norekeningTujuan);

                // reload
                ReloadSaldoNasabahPuhPay(norekeningTujuan);
            }
            else // regular bank have taxes and no need verify
            {
                newSaldo = currSaldo - (jumlahTransfer + taxes);

                totalMutasi = jumlahTransfer + taxes;
                // create data for mutasi current nasabah
                Mutasi.CreateMutasi(totalMutasi, status, currRekening, tanggal, norekeningTujuan);
            }

            // if saldo minus its not enough, so make it pop up
            if (newSaldo < 0)
            {
                MessageBox.Show("Saldo tidak mencukupi untuk melakukan transfer.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update saldo current nasabah
            Nasabah.UpdateSaldoNasabah(username, newSaldo);

            // Simpan data transfer ke database
            Pembayaran.Create(jenis, jumlahTransfer, tujuan, norekeningTujuan, tanggal, currRekening);

            // parent form
            uidashboard dashboard = (uidashboard)this.ParentForm.Controls["uidashboard1"];
            dashboard?.ReloadSaldo();
            dashboard?.LoadTransactionHistory();
            About aboutForm = (About)this.ParentForm.Controls["about1"];
            aboutForm?.ReloadMutasi();

            // success
            MessageBox.Show("Transfer berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
