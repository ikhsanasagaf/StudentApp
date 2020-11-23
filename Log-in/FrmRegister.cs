using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_in
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        oCenter oC = new oCenter();

        
        private void label3_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "First Name";
            txtLastName.Text = "Last Name";
            txtUsername.Text = "Username";
            txtEmail.Text = "Email";
            txtPassword.Text = "Password";
            
        }
       
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            oC.CheckEnterTextBox(txtFirstName, "First Name");
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            oC.CheckEnterTextBox(txtLastName, "Last Name");
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            oC.CheckEnterTextBox(txtUsername, "Username");
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            oC.CheckEnterTextBox(txtEmail, "Email");
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            oC.CheckEnterTextBox(txtPassword, "Password");
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            oC.CheckLeaveTextBox(txtFirstName, "First Name");
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            oC.CheckLeaveTextBox(txtLastName, "Last Name");
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            oC.CheckLeaveTextBox(txtUsername, "Username");
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            oC.CheckLeaveTextBox(txtEmail, "Email");
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            oC.CheckLeaveTextBox(txtPassword, "Password");
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#8f3939");
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#eb9898");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button3.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }


        private void cmdRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Equals("") || txtFirstName.Text.Equals("First Name"))
            {
                MessageBox.Show("Input First Name", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtLastName.Text.Equals("") || txtLastName.Text.Equals("Last Name"))
            {
                MessageBox.Show("Input Last Name", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEmail.Text.Equals("") || txtEmail.Text.Equals("Email"))
            {
                MessageBox.Show("Input Email", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            string sSqlSave = "SELECT * FROM tbUser WHERE Username = '" + txtUsername.Text.Trim() + "'";
            dsAction = oC.ShowData(sSqlSave, "tbUser", dsAction);
            if (dsAction.Tables["tbUser"].Rows.Count <= 0)
            {
                DataRow dr = dsAction.Tables["tbUser"].NewRow();
                dr["FirstName"] = txtFirstName.Text;
                dr["LastName"] = txtLastName.Text;
                dr["Email"] = txtEmail.Text;
                dr["Username"] = txtUsername.Text;
                dr["LPassword"] = txtPassword.Text;

                dsAction.Tables["tbUser"].Rows.Add(dr);
                oC.ReturnAda.Update(dsAction, "tbUser");
            }

            MessageBox.Show("Input Success", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
