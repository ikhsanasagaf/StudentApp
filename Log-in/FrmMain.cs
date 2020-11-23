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
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {
            InitializeComponent();
            panel5.Height = btnHome.Height;
            panel5.Top = btnHome.Top;
            home2.BringToFront();
        }

        oCenter oC = new oCenter();
        private void FrmMain_Load(object sender, EventArgs e)
        { 
            label5.Text = "Hello, icunasagaf";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panel5.Height = btnHome.Height;
            panel5.Top = btnHome.Top;
            home2.BringToFront();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            panel5.Height = btnTodo.Height;
            panel5.Top = btnTodo.Top;
            to_Do1.BringToFront();
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            panel5.Height = btnTools.Height;
            panel5.Top = btnTools.Top;
            tools1.BringToFront();
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            panel5.Height = btnAbout.Height;
            panel5.Top = btnAbout.Top;
            about1.BringToFront();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
