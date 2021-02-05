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
    public partial class MuayeneGUI : Form
    {
        public MuayeneGUI()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        public int degisken;
        public string veri;

        void Getir()
        {

            comboBox1.Items.Clear();

            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            cmd.CommandText = "SELECT* FROM  Users";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                degisken = int.Parse(reader["ID"].ToString());
                veri = reader["NameSurname"].ToString();



                comboBox1.Items.Add(veri);

            }

            comboBox1.SelectedIndex = 0;


            baglanti.con.Close();

            string query = "select * from Examination";

            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }
            /* dataGridView1.Columns[1].HeaderText = "Menü";
             dataGridView1.Columns[2].HeaderText = "Kategori";
             dataGridView1.Columns[3].HeaderText = "Ürün Adı";
             dataGridView1.Columns[4].HeaderText = "Alış Fiyatı";
             dataGridView1.Columns[5].HeaderText = "Satış Fiyatı";
             dataGridView1.Columns[6].HeaderText = "Adet";
             */
            dataGridView1.Columns[0].Visible = false;
            baglanti.con.Close();
            textBox1.Text = null;

            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[3, 0];






        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            tarih = tarih.Replace(".", "-");
            cmd.CommandText = "INSERT INTO Examination(ExaminationName,Explanation,Date,Fee,Animal,Users,Veteriner,Tani) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + tarih + "','" + textBox5.Text + "','" + comboBox2.SelectedItem + "','" + comboBox1.SelectedItem+ "','" + textBox5.Text + "','" + textBox6.Text + "')";




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

        private void MuayeneGUI_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            Connection baglanti = new Connection();

            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            cmd.CommandText = "select * from Animal where Users = " + "'" + comboBox1.SelectedItem.ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                degisken = int.Parse(reader["ID"].ToString());
                veri = reader["Name"].ToString();



                comboBox2.Items.Add(veri);

            }
            try
            {
                comboBox2.SelectedIndex = 0;
            }
            catch
            {
                comboBox2.Text = "";
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            tarih = tarih.Replace(".", "-");

            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
       

            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tarih = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                tarih = tarih.Replace(".", "-");
                cmd.CommandText = "UPDATE Examination SET ExaminationName='" + textBox1.Text + "' ,Explanation='" + textBox3.Text + "',Date='" + tarih + "',Fee='" + textBox5.Text + "',Animal='" + comboBox2.SelectedItem + "',Users='" + comboBox1.SelectedItem + "',Tani='" + textBox6.Text + "' where ID='" + dataGridView1.CurrentRow.Cells["ID"].Value.ToString() + "'";



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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "DELETE Examination where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

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
