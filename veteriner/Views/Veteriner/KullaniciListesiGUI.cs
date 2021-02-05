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
    public partial class KullaniciListesiGUI : Form
    {
        public KullaniciListesiGUI()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        Connection baglanti = new Connection();

        void Getir()
        {

            string query = "select * from Users";

            using (SqlDataAdapter adpt = new SqlDataAdapter(query, baglanti.con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }
            dataGridView1.Columns[0].Visible = false;

            baglanti.con.Close();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[1, 0];


        }

        private void KullaniciListesiGUI_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "insert into Users(NameSurname,Tcno,Email,Password,Adress,Tel) values('" + textBox1.Text + "' , '" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox6.Text + "')";
            
                 
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string olan nesneyi int çevirdik
                secili = int.Parse(dataGridView1.CurrentRow.Index.ToString());

                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "UPDATE Users SET NameSurname='" + textBox1.Text + "' , Tcno='" + textBox3.Text + "',Email='" + textBox4.Text + "',Password='" + textBox5.Text + "',Adress='" + textBox2.Text + "',Tel='" + textBox6.Text + "' where ID='" + dataGridView1.CurrentRow.Cells["ID"].Value.ToString() + "'";

                object sonuc = null;
                sonuc = cmd.ExecuteNonQuery();


                if (sonuc != null)
                {
                    MessageBox.Show("başarılı");
                }
                baglanti.con.Close();
                dataGridView1.DataSource = null;
                Getir();
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();

                dataGridView1.CurrentCell = dataGridView1[1, secili];
            }
            catch (Exception)
            {

                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }
        }

        public int secili;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("SEÇİLİ KAYDI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    baglanti.Baglan();
                    cmd.Connection = baglanti.con;
                    cmd.CommandText = "DELETE FROM Users where ID=('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";

                    object sonuc = null;
                    sonuc = cmd.ExecuteNonQuery();


                    if (sonuc != null)
                    {
                        MessageBox.Show("başarılı");
                    }
                    baglanti.con.Close();
                    dataGridView1.DataSource = null;

                    dataGridView1.Refresh();
                    dataGridView1.ClearSelection();
                    if (secili > 0)
                        dataGridView1.CurrentCell = dataGridView1[1, secili - 1];


                }
                Getir();
            }
            catch (Exception)
            {

                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Veriler Getirilirken Hata Oluştu!");
            }
        }
    }
}
