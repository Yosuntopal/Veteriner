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
    public partial class HayvanIslemleriGUI : Form
    {
        public HayvanIslemleriGUI()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        public int degisken;
        public int kulID;
        public string kulName;
        public string veri;


  
         void Getir()
        {
    
            comboBox1.Items.Clear();
            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            cmd.CommandText = "SELECT* FROM  Type";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                degisken = int.Parse(reader["ID"].ToString());
                veri = reader["Type"].ToString();



                comboBox1.Items.Add(veri);

            }

            comboBox1.SelectedIndex = 0;


            baglanti.con.Close();

            string query = "select * from Animal";

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




        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Baglan();
            cmd.Connection = baglanti.con;

            cmd.CommandText = "INSERT INTO Animal(Genus,Type,Name,Age,Users,Size,Weight,Picture) VALUES ('" + comboBox2.SelectedItem + "','" + comboBox1.SelectedItem + "','" + textBox1.Text + "','" + textBox3.Text + "','" + comboBox3.SelectedItem + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "')";




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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void HayvanIslemleriGUI_Load(object sender, EventArgs e)
        {


            Getir();

            SqlCommand cmd = new SqlCommand();
            Connection baglanti = new Connection();
            comboBox3.Items.Clear();
            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            cmd.CommandText = "SELECT* FROM  Users";
            SqlDataReader reader1 = cmd.ExecuteReader();

            while (reader1.Read())
            {
                kulID = int.Parse(reader1["ID"].ToString());
                kulName = reader1["NameSurname"].ToString();



                comboBox3.Items.Add(kulName);

            }

            comboBox3.SelectedIndex = 0;


            baglanti.con.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            Connection baglanti = new Connection();

            baglanti.Baglan();
            cmd.Connection = baglanti.con;
            cmd.CommandText = "select * from Genus where Type = " + "'" + comboBox1.SelectedItem.ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                degisken = int.Parse(reader["ID"].ToString());
                veri = reader["Genus"].ToString();



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
            //datagridviewden nesneyi sçtiğimizde form içini dolduran bölüm
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        public int secili;

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox2.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[8].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "UPDATE Animal SET Genus='" + comboBox2.SelectedItem + "' , Type='" + comboBox1.SelectedItem + "',Name='" + textBox1.Text + "',Age='" + textBox3.Text + "',Users='" + comboBox3.SelectedItem + "',Size='" + textBox4.Text + "',Weight='" + textBox5.Text + "',Picture='" + textBox2.Text + "' where ID='" + dataGridView1.CurrentRow.Cells["ID"].Value.ToString() + "'";

              

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
                cmd.CommandText = "DELETE Animal where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
