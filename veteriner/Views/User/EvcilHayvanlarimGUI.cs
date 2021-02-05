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
using veteriner.Data;
using veteriner.Models;

namespace veteriner.Views.User
{
    public partial class EvcilHayvanlarimGUI : Form
    {
        public EvcilHayvanlarimGUI()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();
        
        void Getir()
        {
            string query = "SELECT* FROM  Animal where Users = '" + Users.NameSurname + "' ";

            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }

            dataGridView1.Columns[0].Visible = false;
            baglanti.con.Close();

            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[3, 0];


        }


        private void EvcilHayvanlarimGUI_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //formu seçime göre dolduran kod
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
