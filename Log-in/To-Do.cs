using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Log_in
{
    public partial class To_Do : UserControl        

    {

        OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\ASUS\source\repos\ProjectApp\Log-in\bin\Debug\login_regis.mdb");
        public To_Do()
        {
            InitializeComponent();
            
        }

        private void To_Do_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from tbTodo";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtTaskname.Text == "" && txtNotes.Text == "")
            {
                MessageBox.Show("Fill the Data!");
            }

            try
            {
                String sql = "INSERT INTO tbTodo (taskname, notes) VALUES ('" + txtTaskname.Text + "', '" + txtNotes.Text + "')";
                OleDbCommand command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Data Successfully Added!");
                command.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Add Data!");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update tbTodo set taskname='" + txtTaskname.Text + "',notes='" + txtNotes.Text +"' where taskname ='" + txtTaskname.Text + "'";
                OleDbCommand command = new OleDbCommand(sql, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Data Successfully Edited!");
                command.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Edit Data!");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("delete from tbTodo where taskname ='" + txtTaskname.Text + "'");
                OleDbCommand perintah = new OleDbCommand(sql, con);
                perintah.ExecuteNonQuery();
                MessageBox.Show("Data Deleted!");
                perintah.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Delete Data!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtTaskname.Text = row.Cells[0].Value.ToString();
            txtNotes.Text = row.Cells[1].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from tbTodo";
                OleDbCommand perintah = new OleDbCommand(query, con);
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(perintah);
                adapter.Fill(ds, "res");
                dataGridView1.DataSource = ds.Tables["res"];
                adapter.Dispose();
                perintah.Dispose(); 
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Show Data!");
            }
        }
    }
}
