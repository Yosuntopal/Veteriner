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
    public partial class AsiIslemleriGUI : Form
    {
        public AsiIslemleriGUI()
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

            string query = "select * from Vaccine";

            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }

            dataGridView1.Columns[0].Visible = false;
            baglanti.con.Close();
            textBox1.Text = null;

            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[3, 0];


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AsiIslemleriGUI_Load(object sender, EventArgs e)
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
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            tarih = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            tarih = tarih.Replace(".", "-");
            cmd.CommandText = "INSERT INTO Vaccine(Operation,Medicine,Date,Tani,Users,Animal) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + tarih + "','" + textBox6.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "')";




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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                tarih = tarih.Replace(".", "-");
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "UPDATE Vaccine SET Operation='" + textBox1.Text + "' , Medicine='" + textBox3.Text + "',Date='" + tarih + "',Tani='" + textBox6.Text + "',Users='" + comboBox1.SelectedItem + "',Animal='" + comboBox2.SelectedItem + "' where ID='" + dataGridView1.CurrentRow.Cells["ID"].Value.ToString() + "'";



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
                cmd.CommandText = "DELETE Vaccine where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
