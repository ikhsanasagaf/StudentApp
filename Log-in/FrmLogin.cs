using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Log_in
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        oCenter oC = new oCenter();

        private void label1_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void label1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#8f3939");
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#eb9898");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button3.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("") || txtUsername.Text.Equals("Username"))
            {
                MessageBox.Show("Input Username", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Equals("") || txtPassword.Text.Equals("Password"))
            {
                MessageBox.Show("Input Password", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet dsAction = new DataSet("Sample");
            string sSqlSave = "SELECT * FROM tbUser WHERE Username = '" + txtUsername.Text.Trim() + "' AND LPassword = '" + txtPassword.Text + "'";
            dsAction = oC.ShowData(sSqlSave, "tbUser", dsAction);
            if (dsAction.Tables["tbUser"].Rows.Count > 0)
            {
            
                new FrmMain().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Fail", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Text = "";
                txtPassword.Text = "";

            }
        }
    }
}