using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBForm {
    public partial class Form1 : Form {
        public SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBPract;Integrated Security=True");
        SqlCommand cmd;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                con.Open();
                MessageBox.Show("Connection done.");
                con.Close();
            } catch {
                MessageBox.Show("Connection couldn't be done.");
                this.Close();
            }
        }

        private void dbLoadBtn_Click(object sender, EventArgs e) {
            con.Open();

            string query = "Select * from Alumni";
            cmd = new SqlCommand(query, con);

            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dAdapter.Fill(ds);

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
    }
}
