using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Toko
{
    public partial class Tambah_Pegawai : Form
    {
        int mode;
        Database databaseCRUD = new Database();

        public Tambah_Pegawai(int mode)
        {
            this.mode = mode;
            InitializeComponent();
            if (mode == 1)
            {
                lblEdit.Text = "Edit Data Pegawai";
            }
            else
            {
                lblEdit.Text = "Insert Data Pegawai";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
        }
    }
}
