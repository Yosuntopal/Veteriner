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
    public partial class AsiTakvimiGUI : Form
    {
        public AsiTakvimiGUI()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        
        string query;

        void Getir()
        {

                query = "select * from Vaccine where  Users = '" + Users.NameSurname + "'";


            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }

            dataGridView1.Columns[0].Visible = false;
            //  dataGridView1.Columns[2].Visible = false;
            baglanti.con.Close();
    

        }

       

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AsiTakvimiGUI_Load(object sender, EventArgs e)
        {
            Getir();
           
        }

     
    }
}
