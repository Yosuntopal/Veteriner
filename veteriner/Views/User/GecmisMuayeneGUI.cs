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
    public partial class GecmisMuayeneGUI : Form
    {
        public GecmisMuayeneGUI()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();
        public int degisken;
        public string veri;
        string query;
        void Getir()
        {

          

                query = "SELECT* FROM  Examination where Users = '" + Users.NameSurname + "' ";

            
         
            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }

            dataGridView1.Columns[0].Visible = false;
   
            baglanti.con.Close();
     

        }



        private void GecmisMuayeneGUI_Load(object sender, EventArgs e)
        {
            try
            {
                Getir();
            }
            catch (Exception)
            {

                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }

        }


     
    }
}
