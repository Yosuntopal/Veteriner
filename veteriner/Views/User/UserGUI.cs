using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using veteriner.Models;

namespace veteriner.Views
{
    public partial class UserGUI : Form
    {
        public UserGUI()
        {
            InitializeComponent();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            User.EvcilHayvanlarimGUI yeni = new User.EvcilHayvanlarimGUI();
            yeni.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User.GecmisMuayeneGUI yeni = new User.GecmisMuayeneGUI();
            yeni.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User.AsiTakvimiGUI yeni = new User.AsiTakvimiGUI();
            yeni.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void UserGUI_Load(object sender, EventArgs e)
        {
            label1.Text = Users.NameSurname;
        }
    }
}
