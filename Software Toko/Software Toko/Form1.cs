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
    public partial class Form1 : Form
    {
        Database databaseCRUD;
        DataTable dtPegawai, dtUser, dtMasterBarang;
        DataTable dt = new DataTable();

        int w = 0;
        public int h;

        public Form1()
        {
            InitializeComponent();
            databaseCRUD = new Database();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GlobalVariabel.logedIn == 0)
            {
                button1.BackColor = Color.FromArgb(255, 192, 192);
                button1.Text = "Login";
                pictureBoxUser.Image = null;
                lblIdUser.Visible = false;
                lblUsername.Visible = false;
                btnUbahPassword.Visible = false;
                pictureBoxUser.Visible = false;
                toolStripStatusLabel3.Text = "User Online = -";
                tabControl1.Enabled = false;
            }
            else
            {
                button1.BackColor = Color.FromArgb(192, 255, 192);
                button1.Text = "Logout";
                pictureBoxUser.Visible = true;
                lblIdUser.Visible = true;
                lblIdUser.Text = GlobalVariabel.idPegawai;
                lblUsername.Visible = true;
                lblUsername.Text = GlobalVariabel.username;
                btnUbahPassword.Visible = true;
                toolStripStatusLabel3.Text = "User Online = " + GlobalVariabel.username;
                tabControl1.Enabled = true;

                //Load data pegawai
                dtPegawai = new DataTable();
                dtPegawai = databaseCRUD.showtDataPegawai();
                dvgPegawai.Rows.Clear();
                for (int i = 0; i < dtPegawai.Rows.Count; i++)
                {
                    dvgPegawai.Rows.Add(dtPegawai.Rows[i][0].ToString(), dtPegawai.Rows[i][1].ToString(), dtPegawai.Rows[i][2].ToString());
                }

                //load data user
                dtUser = new DataTable();
                dtUser = databaseCRUD.showtDataUser();
                dvgUser.Rows.Clear();
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    dvgUser.Rows.Add(dtUser.Rows[i][0].ToString(), dtUser.Rows[i][1].ToString(), dtUser.Rows[i][2].ToString(), dtUser.Rows[i][3].ToString(), dtUser.Rows[i][4].ToString(), dtUser.Rows[i][5].ToString(), dtUser.Rows[i][6].ToString());
                }

                showMaster();
                buttonUpdate.Enabled = false;
            }
        }

        private void showMaster()
        {
            dtMasterBarang = databaseCRUD.showMasterBarang();
            dgMasterBarang.DataSource = dtMasterBarang;
        }

        private void resetMaster()
        {
            txtIdBarang.Text = "";
            txtNamaBarang.Text = "";
            txtSatuan.Text = "";
            txtHargaJual.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel6.Text = DateTime.Today.ToLongDateString();
            toolStripStatusLabel9.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalVariabel.logedIn == 0)
            {
                this.Hide();
                Login formLogin = new Login();
                formLogin.ShowDialog();
                this.Close();
            }
            else 
            {
                Logout formLogout = new Logout();
                formLogout.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPegawai_Click(object sender, EventArgs e)
        {
            Tambah_Pegawai formTambahPegawai = new Tambah_Pegawai(2);
            formTambahPegawai.ShowDialog();
        }

        private void btnEditPegawai_Click(object sender, EventArgs e)
        {
            Tambah_Pegawai formEditPegawai = new Tambah_Pegawai(1);
            formEditPegawai.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string kode_barang = txtIdBarang.Text.ToString();//id
            string nama_barang = txtNamaBarang.Text.ToString();//nama
            string satuan = txtSatuan.Text.ToString();//satuan
            double harga_jual = double.Parse(txtHargaJual.Text.ToString());

            if (kode_barang.Equals("") || nama_barang.Equals(""))
            {
                MessageBox.Show("Silahkan lengkapi informasi barang");
            }
            else
            {
                databaseCRUD.insertTbMasterBarang(kode_barang, nama_barang, satuan, harga_jual);
                databaseCRUD.insertTbStok(kode_barang, 0, 0);

                showMaster();
                resetMaster();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string kode_barang = txtIdBarang.Text.ToString();//id
            string nama_barang = txtNamaBarang.Text.ToString();//nama
            string satuan = txtSatuan.Text.ToString();//satuan
            double harga_jual = double.Parse(txtHargaJual.Text.ToString());

            if (kode_barang.Equals("") || nama_barang.Equals(""))
            {
                MessageBox.Show("Silahkan lengkapi informasi barang");
            }
            else
            {
                databaseCRUD.updateTbMasterBarang(nama_barang, satuan, harga_jual, kode_barang);

                showMaster();
                resetMaster();

                buttonUpdate.Enabled = false;
                buttonAdd.Enabled = true;
                txtIdBarang.Enabled = true;
            }
        }

        private void dgMasterBarang_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgMasterBarang.Rows.Count > 0)
            {
                txtIdBarang.Enabled = false;

                txtIdBarang.Text = dgMasterBarang.SelectedRows[0].Cells[0].Value.ToString();//id
                txtNamaBarang.Text = dgMasterBarang.SelectedRows[0].Cells[1].Value.ToString();//nama
                txtSatuan.Text = dgMasterBarang.SelectedRows[0].Cells[2].Value.ToString();//satuan
                txtHargaJual.Text = dgMasterBarang.SelectedRows[0].Cells[4].Value.ToString();//hargajual

                buttonUpdate.Enabled = true;
                buttonAdd.Enabled = false;
            }
            else
            {
                MessageBox.Show("No Data");
            }
        }

        private void txtKodeBarangPembelian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable deskripsi = new DataTable();
                string id = txtKodeBarangPembelian.Text.ToString();
                deskripsi = databaseCRUD.selectTbMasterBarang(id);
                if (deskripsi.Rows.Count > 0)
                {
                    txtNamaBarangPembelian.Text = Convert.ToString(deskripsi.Rows[0][1].ToString());
                    txtSatuanBarangPembelian.Text = Convert.ToString(deskripsi.Rows[0][2].ToString());
                    txtHargaBarangPembelian.Focus();
                }
                else if (id == "")
                {
                    MessageBox.Show("Silahkan isi kode barangnya");
                }
                else
                {
                    MessageBox.Show("Silahkan daftarkan barang pada master barang terlebih dahulu");
                }
            }
        }

        private void resetPembelian()
        {
            txtKodeBarangPembelian.Text = "";
            txtNamaBarangPembelian.Text = "";
            txtSatuanBarangPembelian.Text = "";
            txtHargaBarangPembelian.Text = "0";
            txtJumlahBarangPembelian.Text = "0";
            txtDiskonBarangPembelian.Text = "0";

            txtPembayaranPembelian.Text = "0";
            txtTotalPembelian.Text = "0";

            subTotalPembelian();
        }

        private void subTotalPembelian()
        {
            double harga;
            if (txtHargaBarangPembelian.Text.Equals(""))
            {
                harga = 0;
            }
            else
            {
                harga = Convert.ToDouble(txtHargaBarangPembelian.Text.ToString());
            }

            int jumlah;
            if (txtJumlahBarangPembelian.Text.Equals(""))
            {
                jumlah = 0;
            }
            else
            {
                jumlah = Convert.ToInt32(txtJumlahBarangPembelian.Text.ToString());
            }


            double diskon;
            if (txtDiskonBarangPembelian.Text.Equals(""))
            {
                diskon = 0;
            }
            else
            {
                diskon = Convert.ToDouble(txtDiskonBarangPembelian.Text.ToString());
            }

            double total_harga = jumlah * harga;
            double total_diskon = (diskon / 100) * total_harga;

            double subtotal_pembelian = total_harga - total_diskon;
            txtSubTotalPembelian.Text = Convert.ToString(subtotal_pembelian.ToString());

        }

        private void txtHargaBarangPembelian_TextChanged(object sender, EventArgs e)
        {
            subTotalPembelian();
        }

        private void txtJumlahBarangPembelian_TextChanged(object sender, EventArgs e)
        {
            subTotalPembelian();
        }

        private void txtDiskonBarangPembelian_TextChanged(object sender, EventArgs e)
        {
            subTotalPembelian();
        }

        private void totalKeseluruhanPembelian()
        {
            double totalPembelian = 0;
            for (int i = 0; i < dataGridViewPembelian.Rows.Count; ++i)
            {
                totalPembelian += Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[6].Value);
            }

            txtTotalPembelian.Text = Convert.ToString(totalPembelian.ToString());
        }

        private void totalKembalianPembelian()
        {
            double kembalian;
            double total_bayar;
            
            if (txtPembayaranPembelian.Text.Equals(""))
            {
                total_bayar = 0;
            }
            else
            {
                total_bayar = Convert.ToDouble(txtPembayaranPembelian.Text.ToString());
            }
            double total_pembelian=Convert.ToDouble(txtTotalPembelian.Text.ToString());
            kembalian = total_bayar - total_pembelian;

            txtKembalianPembelian.Text = Convert.ToString(kembalian.ToString());
        }

        private void txtPembayaranPembelian_TextChanged(object sender, EventArgs e)
        {
            totalKembalianPembelian();
        }

        private void addBarangPembelian_Click(object sender, EventArgs e)
        {
            
            int status = 0;
            if (dataGridViewPembelian.Rows.Count > 1)
            {
                int j = (dataGridViewPembelian.Rows.Count) - 2;
                for (int i = 0; i <= j; i++)
                {
                    string id_barang = dataGridViewPembelian.Rows[i].Cells[0].Value.ToString();
                    double hrg_beli = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[3].Value.ToString());
                    int stok = Convert.ToInt32(dataGridViewPembelian.Rows[i].Cells[4].Value.ToString());
                    double diskon2 = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[5].Value.ToString());
                    double total2 = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[6].Value.ToString());

                    if (id_barang == txtKodeBarangPembelian.Text.ToString() && hrg_beli == double.Parse(txtHargaBarangPembelian.Text.ToString()) && diskon2 == Convert.ToDouble(txtDiskonBarangPembelian.Text.ToString()))
                    {
                        stok = stok + Convert.ToInt32(txtJumlahBarangPembelian.Text.ToString());
                        total2 = total2 + double.Parse(txtSubTotalPembelian.Text.ToString()); // Convert.ToDouble(txtTotal.Text.ToString());

                        dataGridViewPembelian.Rows[i].Cells[4].Value = stok.ToString();
                        dataGridViewPembelian.Rows[i].Cells[6].Value = total2.ToString();
                        status = 1;
                        break;
                    }
                }

                if (status == 0)
                {
                    MessageBox.Show("test 1");
                    int n = dataGridViewPembelian.Rows.Add();

                    dataGridViewPembelian.Rows[n].Cells[0].Value = txtKodeBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[1].Value = txtNamaBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[2].Value = txtSatuanBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[3].Value = txtHargaBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[4].Value = txtJumlahBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[5].Value = txtDiskonBarangPembelian.Text.ToString();
                    dataGridViewPembelian.Rows[n].Cells[6].Value = txtSubTotalPembelian.Text.ToString();
                }

            }
            else
            {
                MessageBox.Show("test2");
                int n = dataGridViewPembelian.Rows.Add();

                dataGridViewPembelian.Rows[n].Cells[0].Value = txtKodeBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[1].Value = txtNamaBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[2].Value = txtSatuanBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[3].Value = txtHargaBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[4].Value = txtJumlahBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[5].Value = txtDiskonBarangPembelian.Text.ToString();
                dataGridViewPembelian.Rows[n].Cells[6].Value = txtSubTotalPembelian.Text.ToString();

            }
            resetPembelian();
            totalKeseluruhanPembelian();
            txtKodeBarangPembelian.Focus();
        }

        private void updateBarangPembelian_Click(object sender, EventArgs e)
        {
            dataGridViewPembelian.SelectedRows[0].Cells[0].Value = txtKodeBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[1].Value = txtNamaBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[2].Value = txtSatuanBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[3].Value = txtHargaBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[4].Value = txtJumlahBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[5].Value = txtDiskonBarangPembelian.Text.ToString();
            dataGridViewPembelian.SelectedRows[0].Cells[6].Value = txtSubTotalPembelian.Text.ToString();

            resetPembelian();
            totalKeseluruhanPembelian();
            txtKodeBarangPembelian.Focus();
        }

        private void deleteBarangPembelian_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin menghapus barang ini dalam pembelian?", "Peringatan", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                //MessageBox.Show("tidak jadi hapus data");
            }
            else
            {
                foreach (DataGridViewRow item in this.dataGridViewPembelian.SelectedRows)
                {
                    dataGridViewPembelian.Rows.RemoveAt(item.Index);
                }
            }

            resetPembelian();
            totalKeseluruhanPembelian();

            addBarangPembelian.Enabled = true;
            deleteBarangPembelian.Enabled = false;
            updateBarangPembelian.Enabled = false;

            txtKodeBarangPembelian.Focus();
        }

        private void bayarPembelian_Click(object sender, EventArgs e)
        {
            int jmlStokAkhir, stokAwal;

            string id_pembelian=txtFakturPembelian.Text.ToString();
            double totalpembelian=Convert.ToDouble(txtTotalPembelian.Text.ToString());
            double totalbayar=Convert.ToDouble(txtPembayaranPembelian.Text.ToString());
            double kembali=Convert.ToDouble(txtKembalianPembelian.Text.ToString());
            string id_pegawai=lblIdUser.Text;

            databaseCRUD.insertTbPembelian(id_pembelian, totalpembelian, totalbayar, kembali, id_pegawai);

            int n = (dataGridViewPembelian.Rows.Count) - 2;
            for (int i = 0; i <= n; i++)
            {
                string id_barang = dataGridViewPembelian.Rows[i].Cells[0].Value.ToString();
                string nama_barang = dataGridViewPembelian.Rows[i].Cells[1].Value.ToString();
                string satuan = dataGridViewPembelian.Rows[i].Cells[2].Value.ToString();
                double hrg_beli_awal = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[3].Value.ToString());
                int jmlBarangPembelian = Convert.ToInt32(dataGridViewPembelian.Rows[i].Cells[4].Value.ToString());
                double diskon_barang = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[5].Value.ToString());
                double subTotal = Convert.ToDouble(dataGridViewPembelian.Rows[i].Cells[6].Value.ToString());

                double hrg_beli_akhir = hrg_beli_awal - (hrg_beli_awal * (diskon_barang / 100));


                DataTable id_stok = new DataTable();
                id_stok = databaseCRUD.selectTbStok(id_barang, hrg_beli_akhir);
                
                DataTable stk = new DataTable();
                stk = databaseCRUD.selectTotalStok(id_barang);
                stokAwal = Convert.ToInt32(stk.Rows[0][0].ToString());


                if (id_stok.Rows.Count > 0)
                {
                    jmlStokAkhir = Convert.ToInt32(id_stok.Rows[0][1].ToString()) + jmlBarangPembelian;

                    databaseCRUD.updateTbStok(jmlStokAkhir, (Convert.ToInt32(id_stok.Rows[0][0].ToString())));
                    stk = databaseCRUD.selectTotalStok(id_barang);
                }
                else
                {
                    databaseCRUD.insertTbStok(id_barang, jmlBarangPembelian, hrg_beli_akhir);
                    stk = databaseCRUD.selectTotalStok(id_barang);
                }

                databaseCRUD.insertTbDetailPembelian(id_pembelian, id_barang, hrg_beli_awal, jmlBarangPembelian, diskon_barang, subTotal, stokAwal, Convert.ToInt32(stk.Rows[0][0].ToString()));
            }
            MessageBox.Show("Save Success");
            resetPembelian();
            dataGridViewPembelian.Rows.Clear();
            dataGridViewPembelian.Refresh();
        }

        private void dataGridViewPembelian_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewPembelian.Rows.Count > 0)
            {
                txtKodeBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[0].Value.ToString();
                txtNamaBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[1].Value.ToString();
                txtSatuanBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[2].Value.ToString();
                txtHargaBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[3].Value.ToString();
                txtJumlahBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[4].Value.ToString();
                txtDiskonBarangPembelian.Text = dataGridViewPembelian.SelectedRows[0].Cells[5].Value.ToString();
                //txtTotal.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0.00}", int.Parse(dataGridViewPembelian.SelectedRows[0].Cells[6].Value.ToString()));
                
                addBarangPembelian.Enabled = false;
                deleteBarangPembelian.Enabled = true;
                updateBarangPembelian.Enabled = true;

                txtKodeBarangPembelian.Focus();
            }
            else
            {
                MessageBox.Show("No Data");
            }
        }

        private void txtKodeBarangPenjualan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable deskripsi = new DataTable();
                string id = txtKodeBarangPenjualan.Text.ToString();
                deskripsi = databaseCRUD.selectTbMasterBarang(id);
                if (deskripsi.Rows.Count > 0)
                {
                    txtNamaBarangPenjualan.Text = Convert.ToString(deskripsi.Rows[0][1].ToString());
                    txtSatuanBarangPenjualan.Text = Convert.ToString(deskripsi.Rows[0][2].ToString());
                    txtHargaBarangPenjualan.Text = Convert.ToString(deskripsi.Rows[0][3].ToString());
                    txtJumlahBarangPenjualan.Focus();
                }
                else if (id == "")
                {
                    MessageBox.Show("Silahkan isi kode barangnya");
                }
                else
                {
                    MessageBox.Show("Silahkan daftarkan barang pada master barang terlebih dahulu");
                }
            }
        }

        private void resetPenjualan()
        {
            txtKodeBarangPenjualan.Text = "";
            txtNamaBarangPenjualan.Text = "";
            txtSatuanBarangPenjualan.Text = "";
            txtHargaBarangPenjualan.Text = "0";
            txtJumlahBarangPenjualan.Text = "0";
            txtDiskonBarangPenjualan.Text = "0";
            txtTotalPenjualan.Text = "0";
            txtPembayaranPenjualan.Text = "0";

            subTotalPenjualan();
        }

        private void subTotalPenjualan()
        {
            double harga;
            if (txtHargaBarangPenjualan.Text.Equals(""))
            {
                harga = 0;
            }
            else
            {
                harga = Convert.ToDouble(txtHargaBarangPenjualan.Text.ToString());
            }
            
            int jumlah;
            if (txtJumlahBarangPenjualan.Text.Equals(""))
            {
                jumlah = 0;
            }
            else
            {
                jumlah = Convert.ToInt32(txtJumlahBarangPenjualan.Text.ToString());
            }
            
            
            double diskon;
            if (txtDiskonBarangPenjualan.Text.Equals(""))
            {
                diskon = 0;
            }
            else
            {
                diskon = Convert.ToDouble(txtDiskonBarangPenjualan.Text.ToString());
            }

            double total_harga = jumlah * harga;
            double total_diskon = (diskon / 100) * total_harga;

            double subtotal_penjualan = total_harga - total_diskon;
            txtSubTotalPenjualan.Text = Convert.ToString(subtotal_penjualan.ToString());
        }

        private void txtHargaBarangPenjualan_TextChanged(object sender, EventArgs e)
        {
            subTotalPenjualan();
        }

        private void txtJumlahBarangPenjualan_TextChanged(object sender, EventArgs e)
        {
            subTotalPenjualan();
        }

        private void txtDiskonBarangPenjualan_TextChanged(object sender, EventArgs e)
        {
            subTotalPenjualan();
        }

        private void totalKeseluruhanPenjualan()
        {
            double totalPenjualan = 0;
            for (int i = 0; i < dataGridViewPenjualan.Rows.Count; ++i)
            {
                totalPenjualan += Convert.ToDouble(dataGridViewPenjualan.Rows[i].Cells[6].Value);
            }

            txtTotalPenjualan.Text = Convert.ToString(totalPenjualan.ToString());
        }

        private void totalKembalianPenjualan()
        {
            double kembalian;
            double total_bayar;
            if (txtPembayaranPenjualan.Text.Equals(""))
            {
                total_bayar = 0;
            }
            else
            {
                total_bayar = Convert.ToDouble(txtPembayaranPenjualan.Text.ToString());
            }
            double total_penjualan = Convert.ToDouble(txtTotalPenjualan.Text.ToString());
            kembalian = total_bayar - total_penjualan;

            txtKembalianPenjualan.Text = Convert.ToString(kembalian.ToString());
        }

        private void txtPembayaranPenjualan_TextChanged(object sender, EventArgs e)
        {
            totalKembalianPenjualan();
        }

        private void addBarangPenjualan_Click(object sender, EventArgs e)
        {
            int status = 0;
            if (dataGridViewPenjualan.Rows.Count > 1)
            {
                int j = (dataGridViewPenjualan.Rows.Count) - 2;
                for (int i = 0; i <= j; i++)
                {
                    string id_barang = dataGridViewPenjualan.Rows[i].Cells[0].Value.ToString();
                    double hrg_beli = Convert.ToDouble(dataGridViewPenjualan.Rows[i].Cells[3].Value.ToString());
                    int stok = Convert.ToInt32(dataGridViewPenjualan.Rows[i].Cells[4].Value.ToString());
                    double diskon2 = Convert.ToDouble(dataGridViewPenjualan.Rows[i].Cells[5].Value.ToString());
                    double total2 = Convert.ToDouble(dataGridViewPenjualan.Rows[i].Cells[6].Value.ToString());

                    if (id_barang == txtKodeBarangPenjualan.Text.ToString() && hrg_beli == double.Parse(txtHargaBarangPenjualan.Text.ToString()) && diskon2 == Convert.ToDouble(txtDiskonBarangPenjualan.Text.ToString()))
                    {
                        stok = stok + Convert.ToInt32(txtJumlahBarangPenjualan.Text.ToString());
                        total2 = total2 + double.Parse(txtSubTotalPenjualan.Text.ToString()); // Convert.ToDouble(txtTotal.Text.ToString());

                        dataGridViewPenjualan.Rows[i].Cells[4].Value = stok.ToString();
                        dataGridViewPenjualan.Rows[i].Cells[6].Value = total2.ToString();
                        status = 1;
                        break;
                    }
                }

                if (status == 0)
                {
                    MessageBox.Show("test 1");
                    int n = dataGridViewPenjualan.Rows.Add();

                    dataGridViewPenjualan.Rows[n].Cells[0].Value = txtKodeBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[1].Value = txtNamaBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[2].Value = txtSatuanBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[3].Value = txtHargaBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[4].Value = txtJumlahBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[5].Value = txtDiskonBarangPenjualan.Text.ToString();
                    dataGridViewPenjualan.Rows[n].Cells[6].Value = txtSubTotalPenjualan.Text.ToString();
                }

            }
            else
            {
                MessageBox.Show("test2");
                int n = dataGridViewPenjualan.Rows.Add();

                dataGridViewPenjualan.Rows[n].Cells[0].Value = txtKodeBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[1].Value = txtNamaBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[2].Value = txtSatuanBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[3].Value = txtHargaBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[4].Value = txtJumlahBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[5].Value = txtDiskonBarangPenjualan.Text.ToString();
                dataGridViewPenjualan.Rows[n].Cells[6].Value = txtSubTotalPenjualan.Text.ToString();

            }
            resetPenjualan();
            totalKeseluruhanPenjualan();
            txtKodeBarangPenjualan.Focus();
        }

        private void updateBarangPenjualan_Click(object sender, EventArgs e)
        {
            dataGridViewPenjualan.SelectedRows[0].Cells[0].Value = txtKodeBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[1].Value = txtNamaBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[2].Value = txtSatuanBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[3].Value = txtHargaBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[4].Value = txtJumlahBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[5].Value = txtDiskonBarangPenjualan.Text.ToString();
            dataGridViewPenjualan.SelectedRows[0].Cells[6].Value = txtSubTotalPenjualan.Text.ToString();

            resetPenjualan();
            totalKeseluruhanPenjualan();
            txtKodeBarangPenjualan.Focus();
        }

        private void deleteBarangPenjualan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin menghapus barang ini?", "Peringatan", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                //MessageBox.Show("tidak jadi hapus data");
            }
            else
            {
                foreach (DataGridViewRow item in this.dataGridViewPenjualan.SelectedRows)
                {
                    dataGridViewPenjualan.Rows.RemoveAt(item.Index);
                }
            }

            resetPenjualan();
            totalKeseluruhanPenjualan();

            addBarangPenjualan.Enabled = true;
            deleteBarangPenjualan.Enabled = false;
            updateBarangPenjualan.Enabled = false;

            txtKodeBarangPenjualan.Focus();
        }

        private void bayarPenjualan_Click(object sender, EventArgs e)
        {
            string id_penjualan = txtFakturPenjualan.Text.ToString();
            double totalpenjualan = Convert.ToDouble(txtTotalPenjualan.Text.ToString());
            double totalbayar = Convert.ToDouble(txtPembayaranPenjualan.Text.ToString());
            double kembali = Convert.ToDouble(txtKembalianPenjualan.Text.ToString());
            string id_pegawai = lblIdUser.Text;

            databaseCRUD.insertTbPenjualan(id_penjualan, totalpenjualan, totalbayar, kembali, id_pegawai);

            int sisa;
            int stok2, stok3;
            int n = (dataGridViewPenjualan.Rows.Count) - 1;
            int i = 0;
            double harga_beli, total_beli;
            do
            {
                string id_barang = dataGridViewPenjualan.Rows[i].Cells[0].Value.ToString();
                string nama_barang = dataGridViewPenjualan.Rows[i].Cells[1].Value.ToString();
                //string satuan = dataGridView1.Rows[i].Cells[2].Value.ToString();//GA PERLU UNIT DI DB
                double harga_jual = double.Parse(dataGridViewPenjualan.Rows[i].Cells[3].Value.ToString());
                int quantity = Convert.ToInt32(dataGridViewPenjualan.Rows[i].Cells[4].Value.ToString());
                double diskon2 = Convert.ToDouble(dataGridViewPenjualan.Rows[i].Cells[5].Value.ToString());
                double total2 = double.Parse(dataGridViewPenjualan.Rows[i].Cells[6].Value.ToString());

                DataTable stok = new DataTable();
                stok = databaseCRUD.selectDetailStok(id_barang);
                n = 0;
                //stok[i][0]=id_stok int
                //stok[i][1]=stok_barang int
                //stok[i][2]=harga_beli double
                do
                {
                    stok2 = Convert.ToInt32(stok.Rows[n][1].ToString());
                    harga_beli = Convert.ToDouble(stok.Rows[n][2].ToString());
                    DataTable stk = new DataTable();
                    stk = databaseCRUD.selectTotalStok(id_barang);
                    stok3 = Convert.ToInt32(stk.Rows[0][0].ToString());

                    sisa = quantity;
                    quantity = quantity - stok2;
                    if (quantity >= 0)
                    {
                        total_beli = stok2 * harga_beli;
                        databaseCRUD.updateTbStok(0, Convert.ToInt32(stok.Rows[n][0].ToString()));
                        stk = databaseCRUD.selectTotalStok(id_barang);

                        databaseCRUD.insertTbDetailPenjualan(id_penjualan, id_barang, harga_jual, stok2, diskon2, ((harga_jual * stok2) - (diskon2 / 100) * (harga_jual * stok2)), harga_beli, total_beli, stok3, Convert.ToInt32(stk.Rows[0][0].ToString()));


                    }
                    else
                    {
                        total_beli = sisa * harga_beli;
                        databaseCRUD.updateTbStok((stok2 - sisa), Convert.ToInt32(stok.Rows[n][0].ToString()));
                        stk = databaseCRUD.selectTotalStok(id_barang);

                        databaseCRUD.insertTbDetailPenjualan(id_penjualan, id_barang, harga_jual, sisa, diskon2, (harga_jual * sisa) - (diskon2 / 100) * (harga_jual * sisa), harga_beli, total_beli, stok3, Convert.ToInt32(stk.Rows[0][0].ToString()));
                        break;
                    }
                    n++;
                } while (quantity > 0);
                i++;
            } while (i <= (dataGridViewPenjualan.Rows.Count - 2));

            ///////////--PERINT
            dt = databaseCRUD.rePrint(txtFakturPenjualan.Text.ToString());
            int jum = dt.Rows.Count;
            int w = 220 + (25 * (jum + 1));
            //PaperSize ps = new PaperSize("Custom", 300, h); // ne wa paling ar, enken carane parsing nilai H ne to, nyanan h ne to kal dadi dinamic ukuran kertasne
            PaperSize ps = new PaperSize("Custom", 300, w);
            printDocument1.DefaultPageSettings.PaperSize = ps;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            MessageBox.Show("Save Success");
            resetPenjualan();
            dataGridViewPenjualan.Rows.Clear();
            dataGridViewPenjualan.Refresh();
        }

        private void dataGridViewPenjualan_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewPenjualan.Rows.Count > 0)
            {
                txtKodeBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[0].Value.ToString();
                txtNamaBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[1].Value.ToString();
                txtSatuanBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[2].Value.ToString();
                txtHargaBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[3].Value.ToString();
                txtJumlahBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[4].Value.ToString();
                txtDiskonBarangPenjualan.Text = dataGridViewPenjualan.SelectedRows[0].Cells[5].Value.ToString();
                //txtTotal.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,##0.00}", int.Parse(dataGridViewPenjualan.SelectedRows[0].Cells[6].Value.ToString()));

                addBarangPenjualan.Enabled = false;
                deleteBarangPenjualan.Enabled = true;
                updateBarangPenjualan.Enabled = true;

                txtKodeBarangPenjualan.Focus();
            }
            else
            {
                MessageBox.Show("No Data");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            h = 95;

            dt = databaseCRUD.rePrint(txtFakturPenjualan.Text.ToString());
            int jum = dt.Rows.Count;

            e.Graphics.DrawString("Bali Tunjung Media", new Font("Courier New", 8), Brushes.Black, new Point(80, 15));
            e.Graphics.DrawString("Jl Sunset Road 333, Seminyak, Badung-Bali", new Font("Courier New", 8), Brushes.Black, new Point(10, 25));
            e.Graphics.DrawString(" Telp : (0361) 8887026", new Font("Courier New", 8), Brushes.Black, new Point(73, 35));

            e.Graphics.DrawString("ID Bill  : " + dt.Rows[0][0].ToString(), new Font("Courier New", 8, FontStyle.Regular), Brushes.Black, new Point(10, 60)); //(10,100) 25 kirikanan, 100 atas bawwah
            e.Graphics.DrawString("Employee : " + dt.Rows[0][10].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString("Date     : " + DateTime.Now, new Font("Courier New", 8), Brushes.Black, new Point(10, 80));

            //// Draw line to screen.
            //e.Graphics.DrawLine(blackPen, point1, point2);
            Pen myPen = new Pen(Color.Black, 1.0F);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // Create points that define line.
            Point point1 = new Point(10, 95);
            Point point2 = new Point(290, 95);

            // Draw line to screen.
            e.Graphics.DrawLine(myPen, point1, point2);

            for (int i = 0; i < jum; i++)
            {
                h = h + 10;
                //Group
                e.Graphics.DrawString(dt.Rows[i][2].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(10, h));

                h = h + 10;
                //Detail
                e.Graphics.DrawString(dt.Rows[i][1].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(10, h));
                e.Graphics.DrawString(dt.Rows[i][3].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(65, h));
                e.Graphics.DrawString(dt.Rows[i][4].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(115, h));
                e.Graphics.DrawString(dt.Rows[i][5].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(165, h));
                e.Graphics.DrawString(dt.Rows[i][6].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(215, h));
            }

            h = h + 20;
            //return
            e.Graphics.DrawString("Total  :", new Font("Courier New", 8), Brushes.Black, new Point(150, h));
            e.Graphics.DrawString(dt.Rows[0][7].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(215, h));

            h = h + 10;
            e.Graphics.DrawString("Pay    :", new Font("Courier New", 8), Brushes.Black, new Point(150, h));
            e.Graphics.DrawString(dt.Rows[0][8].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(215, h));

            h = h + 10;
            e.Graphics.DrawString("Change :", new Font("Courier New", 8), Brushes.Black, new Point(150, h));
            e.Graphics.DrawString(dt.Rows[0][9].ToString(), new Font("Courier New", 8), Brushes.Black, new Point(215, h));


            //detail pembeli/member
            h = h + 20;


            //Footer
            h = h + 30;
            e.Graphics.DrawString(" Terima Kasih", new Font("Courier New", 8), Brushes.Black, new Point(83, h));

            this.w = h;
        }
    }
}
