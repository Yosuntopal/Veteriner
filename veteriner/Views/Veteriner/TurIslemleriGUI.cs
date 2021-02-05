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

namespace veteriner.Views.Veteriner
{
    public partial class TurIslemleriGUI : Form
    {
        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        public TurIslemleriGUI()
        {
            InitializeComponent();
        }

        void Getir()
        {

            string query = "select * from Type";

            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }
            dataGridView1.Columns[0].Visible = false;
            baglanti.con.Close();
            textBox1.Text = null;


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //ekleme işlemi
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "insert into Type(Type) values('" + textBox1.Text + "')";

                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("Correct");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //forma tıklar isem gelen fonksiyon
        private void TurIslemleriGUI_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "UPDATE Type set Type='" + textBox1.Text + "' where ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();

                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("Correct");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
            }
          

               catch (Exception)
            {

                MessageBox.Show("Lütfen Seçim Yapınız!");
                baglanti.con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "DELETE FROM Type where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("Correct");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Seçim Yapınız!");
                baglanti.con.Close();
            }
        }
    }
}
