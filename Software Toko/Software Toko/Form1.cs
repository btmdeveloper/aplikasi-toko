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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GlobalVariabel.logedIn == 0)
            {
                button1.BackColor = Color.FromArgb(255, 192, 192);
                button1.Text = "Login";
                pictureBox1.Image = null;
            }
            else
            {
                button1.BackColor = Color.FromArgb(192, 255, 192);
                button1.Text = "Logout";
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
    }
}
