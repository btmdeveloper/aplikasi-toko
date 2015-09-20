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
    public partial class Login : Form
    {
        string username, password, status;
        Database databaseCRUD = new Database();
        DataTable dtUser;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtUser = new DataTable();
            username = textBox1.Text.ToString();
            password = textBox2.Text.ToString();
            status = databaseCRUD.loginUser(username, password);
            if (status.Equals("1"))
            {
                this.Hide();
                dtUser = databaseCRUD.getDataUser(username);
                databaseCRUD.updateLastLogin(dtUser.Rows[0][0].ToString());
                GlobalVariabel.logedIn = 1;
                GlobalVariabel.idPegawai = dtUser.Rows[0][1].ToString();
                GlobalVariabel.username = dtUser.Rows[0][3].ToString();
                Form1 formUtama = new Form1();
                formUtama.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password dan username tidak cocok!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
