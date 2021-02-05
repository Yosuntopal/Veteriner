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

namespace veteriner.Views
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                SqlCommand cmd = new SqlCommand();

                Connection baglanti = new Connection();

                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "SELECT * FROM Veteriner where NameSurname='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    VeterinerGUI yeni = new VeterinerGUI();
                    yeni.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre");

                }


                baglanti.con.Close();

            }
            else if (radioButton2.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                Connection baglanti = new Connection();

                baglanti.Baglan();
                cmd.Connection = baglanti.con;
                cmd.CommandText = "SELECT * FROM Users where NameSurname='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //capsülleme

                    Users.NameSurname = textBox1.Text;
                    
                    UserGUI yeni = new UserGUI();
                    yeni.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre");

                }

                baglanti.con.Close();
               
            }    

        }

        private void LoginGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
