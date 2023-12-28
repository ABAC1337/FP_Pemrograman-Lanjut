using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace BANKING
{
    public partial class Tambah : Form
    {
        public int SelectedNasabahIndex { get; set; }
        List<Nasabah> KoleksiNasabah = new List<Nasabah>();
        public Tambah()
        {
            InitializeComponent();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            // Check if the selected index is within the bounds of the collection
            if (SelectedNasabahIndex >= 0 && SelectedNasabahIndex < KoleksiNasabah.Count)
            {
                int currSaldo = Nasabah.GetSaldoWithIdNasabah(SelectedNasabahIndex);
                int depositAmount = int.Parse(TBsaldo.Text);
                int totalDeposit = currSaldo + depositAmount;

                Nasabah selectedNasabah = KoleksiNasabah[SelectedNasabahIndex];
                Nasabah.DepositSaldo(selectedNasabah.IdNasabah, totalDeposit);

                // Reload the ListView in the BtnReset form
                ((BtnReset)this.Owner).ReloadListViewNasabah();

                MessageBox.Show("Data berhasil ditambah");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid selected index.", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
