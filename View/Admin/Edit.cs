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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data berhasil diedit");
            this.Close();
        }

        private void TBnamanasabah_TextChanged(object sender, EventArgs e) //button edit pada nasabah (nama nasabah)
        {

        }

        private void TBnomorrekening_TextChanged(object sender, EventArgs e) //button edit pada nasabah (nomor rekening)
        {

        }

        private void TBjeniskartu_TextChanged(object sender, EventArgs e) //button edit pada nasabah (jenis kartu)
        {

        }

        private void TBsaldo_TextChanged(object sender, EventArgs e) //button edit pada nasabah (saldo)
        {

        }
    }
}
