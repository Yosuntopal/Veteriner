using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veteriner.Views
{
    public partial class VeterinerGUI : Form
    {
        public VeterinerGUI()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Veteriner.MuayeneGUI yeni = new Veteriner.MuayeneGUI();
            yeni.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veteriner.AsiIslemleriGUI yeni = new Veteriner.AsiIslemleriGUI();
            yeni.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veteriner.KullaniciListesiGUI yeni = new Veteriner.KullaniciListesiGUI();
            yeni.ShowDialog();
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Veteriner.TurIslemleriGUI yeni = new Veteriner.TurIslemleriGUI();
            yeni.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Veteriner.CinsIslemleriGUI yeni = new Veteriner.CinsIslemleriGUI();
            yeni.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Veteriner.HayvanIslemleriGUI yeni = new Veteriner.HayvanIslemleriGUI();
            yeni.ShowDialog();
        }
    }
}
