using BANKING.DB.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKING
{
    public partial class BtnReset : Form
    {
        List<Nasabah> KoleksiNasabah = new List<Nasabah>();
        public BtnReset()
        {
            InitializeComponent();
            listview();
            ReloadListViewNasabah();
        }

        public void ReloadListViewNasabah()
        {
            listviewNasabah();
        }

        private void listviewNasabah()
        {
            KoleksiNasabah = Nasabah.GetAll();

            listView1.Items.Clear();

            foreach (var nasabah in KoleksiNasabah)
            {
                var item = new ListViewItem(nasabah.IdNasabah.ToString());
                item.SubItems.Add(nasabah.Nama);
                item.SubItems.Add(nasabah.TanggalLahir);
                item.SubItems.Add(nasabah.Username);
                item.SubItems.Add(nasabah.NoTelepon);
                item.SubItems.Add(nasabah.IdRekening);
                item.SubItems.Add(nasabah.Saldo.ToString());
                item.SubItems.Add(nasabah.Nik);
                item.SubItems.Add(nasabah.Email);
                item.SubItems.Add(nasabah.WaktuRegister);
                listView1.Items.Add(item);
            }
        }
        private void listview()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listView1.Columns.Add("Nama", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Tanggal lahir", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Username", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Nomor Telpon", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Id Rekening", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Saldo", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Nik", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Email", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Waktu Register", 150, HorizontalAlignment.Center);

        }

        private void BTNhapus_Click_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data barang ingin di hapus?", "konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (konfirmasi == DialogResult.Yes)
                {
                    var selectedNasabahIndex = listView1.SelectedIndices[0];
                    Nasabah selectedNasabah = KoleksiNasabah[selectedNasabahIndex];

                    Nasabah.Hapus(selectedNasabah.IdNasabah);
                    listviewNasabah();
                }
            }
        }

        private void BTNexit_Click_1(object sender, EventArgs e)
        {
            buka buka = new buka();
            buka.Show();
            this.Close();
        }

        private void BtnDepo_Click(object sender, EventArgs e)
        {
            int SelectedNasabah = listView1.SelectedIndices[0];
            Nasabah selectedNasabah = KoleksiNasabah[SelectedNasabah];
            DateTime currTime = DateTime.Now;
            string tanggal = currTime.ToString();
            string status = "Pemasukkan";
            string virtualaccount = "PuhPay Bank"; 

            int currSaldo = Nasabah.GetSaldoWithIdNasabah(selectedNasabah.IdNasabah);
            int depositAmount = int.Parse(depoTB.Text);
            int totalDeposit = currSaldo + depositAmount;

            Nasabah.DepositSaldo(selectedNasabah.IdNasabah, totalDeposit);

            // Simpan data Mutasi ke database
            Mutasi.CreateMutasi(depositAmount, status, selectedNasabah.IdRekening, tanggal, virtualaccount);
            if (this.ParentForm != null)
            {
                About aboutForm = (About)this.ParentForm.Controls["about1"];
                aboutForm?.ReloadMutasi();
            }
            ReloadListViewNasabah();

            MessageBox.Show("Data berhasil ditambah");
        }


    }
}