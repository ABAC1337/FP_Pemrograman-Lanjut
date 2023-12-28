using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class About : UserControl
    {
    
        public About()
        {
            InitializeComponent();
            SetupListView();
            ReloadMutasi();
        }

        private void SetupListView()
        {
            MutasiLV.View = View.Details;
            MutasiLV.FullRowSelect = true;
            MutasiLV.GridLines = true;

            MutasiLV.Columns.Add("No.", 30, HorizontalAlignment.Center);
            MutasiLV.Columns.Add("Tanggal", 150, HorizontalAlignment.Center);
            MutasiLV.Columns.Add("Status", 100, HorizontalAlignment.Center);
            MutasiLV.Columns.Add("Jumlah", 100, HorizontalAlignment.Center);
            MutasiLV.Columns.Add("Rekening", 100, HorizontalAlignment.Center);
        }

        public void ReloadMutasi()
        {
            string usernameLogin = login.LoggedUsername;
            string rekening = Nasabah.GetRekeningByUsername(usernameLogin);
            List<Mutasi> koleksiMutasi = Mutasi.GetAllMutasiWithRekening(rekening);

            MutasiLV.Items.Clear();

            foreach (var mutasi in koleksiMutasi)
            {
                var item = new ListViewItem(mutasi.IdMutasi.ToString());
                item.SubItems.Add(mutasi.Tanggal);
                item.SubItems.Add(mutasi.StatusMutasi);
                item.SubItems.Add(mutasi.Saldo.ToString());
                item.SubItems.Add(mutasi.TujuanRekening);

                MutasiLV.Items.Add(item);
            }
        }
    }
}
