using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class uidashboard : UserControl
    {
        List<Nasabah> KoleksiNasabah = new List<Nasabah>();
        List<Pembayaran> KoleksiPembayaran = new List<Pembayaran>();
        private string getUsername = login.LoggedUsername;
        public uidashboard()
        {
            InitializeComponent();
            SetupListView();
            ReloadSaldo();
            LoadTransactionHistory();
        }

        private void SetupListView()
        {
            HistoryLV.View = View.Details;
            HistoryLV.Columns.Add("Tanggal", 80, HorizontalAlignment.Center);
            HistoryLV.Columns.Add("Jenis", 70, HorizontalAlignment.Center);
            HistoryLV.Columns.Add("Jumlah", 70, HorizontalAlignment.Center);
            HistoryLV.Columns.Add("Tujuan", 70, HorizontalAlignment.Center);
            HistoryLV.Columns.Add("ke Rekening", 120, HorizontalAlignment.Center);
        }

        public void ReloadSaldo()
        {
            KoleksiNasabah = Nasabah.GetAllWithUsername(getUsername);

            saldoOutput.Text = "";

            foreach (var nasabah in KoleksiNasabah)
            {
                saldoOutput.Text = "Rp." + nasabah.Saldo.ToString();
                rekeningOutput.Text = nasabah.IdRekening;
            }
        }

        public void LoadTransactionHistory()
        {
            // get the rekening from nasabah
            string getRekening = Nasabah.GetRekeningByUsername(getUsername);
            // get history with rekening
            KoleksiPembayaran = Pembayaran.GetTransactionHistoryByIdRekening(getRekening);

            // Membersihkan dan menambahkan data ke ListView
            HistoryLV.Items.Clear();

            foreach (var pembayaran in KoleksiPembayaran)
            {
                ListViewItem item = new ListViewItem(pembayaran.Tanggal);
                item.SubItems.Add(pembayaran.Jenis);
                item.SubItems.Add(pembayaran.Jumlah.ToString());
                item.SubItems.Add(pembayaran.Tujuan);
                item.SubItems.Add(pembayaran.TujuanRekening);

                HistoryLV.Items.Add(item);
            }
        }
    }
}
