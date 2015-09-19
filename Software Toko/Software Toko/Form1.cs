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
    public partial class Form1 : Form
    {
        Database databaseCRUD;
        DataTable dtPegawai, dtUser;

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
                
            }
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

        private void txtPay_TextChanged(object sender, EventArgs e)
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
    }
}
