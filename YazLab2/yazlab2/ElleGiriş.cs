using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlab2
{
    public partial class ElleGiriş : Form
    {
        public ElleGiriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int satır = Convert.ToInt32(textBox1.Text);
            int sutun = Convert.ToInt32(textBox2.Text);
            if((satır<1 || satır>5) || (sutun < 1 || sutun > 5))
            {
                MessageBox.Show("1-5 arası değer giriniz!");
            }
            else if (satır == sutun)
            {
                MessageBox.Show("Satır-sütun değerlerini farklı giriniz!");
            }
           else
            {
                MatrisOluştur mo = new MatrisOluştur(satır, sutun);
                mo.Show();
            }

        }

        private void ElleGiriş_Load(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            textBox4.Text = "0";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
