using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Software_Toko
{
    public partial class FormHutang : Form
    {
        Database databaseCRUD;
        DataTable dt = new DataTable();

        public FormHutang()
        {
            InitializeComponent();
            databaseCRUD = new Database();
        }

        private void FormHutang_Load(object sender, EventArgs e)
        {
            showHutang();
            buttonBayarHutang.Enabled = false;
        }

        private void showHutang()
        {
            dt = databaseCRUD.showTbHutang();
            dgHutang.DataSource = dt;
        }

        private void resetFormHutang()
        {
            txtNoFaktur.Text = "";
            txtJumlahHutang.Text = "0";
            txtBayarHutang.Text = "0";
            txtKembalian.Text = "0";
            txtSisaHutang.Text = "0";
            buttonBayarHutang.Enabled = false;
        }

        private void txtBayarHutang_TextChanged(object sender, EventArgs e)
        {
            double kembalian;
            double total_bayar;
            double sisa_hutang;

            if (txtBayarHutang.Text.Equals(""))
            {
                total_bayar = 0;
            }
            else
            {
                total_bayar = Convert.ToDouble(txtBayarHutang.Text.ToString());
            }
            double total_hutang = Convert.ToDouble(txtJumlahHutang.Text.ToString());
            kembalian = total_bayar - Math.Abs(total_hutang);
            txtKembalian.Text = Convert.ToString(kembalian.ToString());
            sisa_hutang = Convert.ToDouble(txtKembalian.Text.ToString());

            if (sisa_hutang >= 0)
            {
                txtSisaHutang.Text = "0";
            }
            else
            {
                txtSisaHutang.Text = Convert.ToString(sisa_hutang.ToString());
            }
        }

        private void dgHutang_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgHutang.Rows.Count > 0)
            {
                txtNoFaktur.Text = dgHutang.SelectedRows[0].Cells[1].Value.ToString();
                txtJumlahHutang.Text = dgHutang.SelectedRows[0].Cells[2].Value.ToString();

                buttonBayarHutang.Enabled = true;
                txtBayarHutang.Focus();
            }
            else
            {
                MessageBox.Show("No Data");
            }
        }

        private void buttonBayarHutang_Click(object sender, EventArgs e)
        {
            string no_faktur = txtNoFaktur.Text.ToString();
            double hutang = Convert.ToDouble(txtJumlahHutang.Text.ToString());
            double pembayaran = Convert.ToDouble(txtBayarHutang.Text.ToString());
            double kembalian = Convert.ToDouble(txtKembalian.Text.ToString());
            double sisa_hutang = Convert.ToDouble(txtSisaHutang.Text.ToString());

            databaseCRUD.updateTbHutang(no_faktur, sisa_hutang);
            databaseCRUD.insertTbDetailHutang(no_faktur, hutang, pembayaran, kembalian, sisa_hutang);

            resetFormHutang();
            showHutang();
        }
    }
}
