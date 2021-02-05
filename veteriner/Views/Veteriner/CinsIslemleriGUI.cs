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
    public partial class CinsIslemleriGUI : Form
    {
        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        public CinsIslemleriGUI()
        {
            InitializeComponent();
        }

        public int degisken;
        public string veri;
        string query;
        void Getir()
        {

            if (comboBox1.Items.Count == 0)
            {

                query = "select * from Genus";

            }
            else
            {
                query = "select * from Genus where Type=" + "'" + comboBox1.SelectedItem.ToString() + "'";
            }


            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }

            dataGridView1.Columns[0].Visible = false;
          //  dataGridView1.Columns[2].Visible = false;
            baglanti.con.Close();
            textBox1.Text = null;

        }

        private void CinsIslemleriGUI_Load(object sender, EventArgs e)
        {
            try
            {
                Getir();



                SqlCommand cmd = new SqlCommand();
                Connection baglanti = new Connection();

                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "SELECT * FROM  Type";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    degisken = int.Parse(reader["ID"].ToString());
                    veri = reader["Type"].ToString();



                    comboBox1.Items.Add(veri);

                }
                comboBox1.SelectedIndex = 0;
                comboBox1.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;

                cmd.CommandText = "INSERT INTO Genus(Genus, Type) VALUES ('" + textBox1.Text + "', '" + comboBox1.SelectedItem + "')";




                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("başarılı");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
                baglanti.con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "DELETE Genus where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "UPDATE Genus set Genus='" + textBox1.Text + "' where ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();

                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("başarılı");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
            }
            catch (Exception)
            {


                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }

        }
    }
}
