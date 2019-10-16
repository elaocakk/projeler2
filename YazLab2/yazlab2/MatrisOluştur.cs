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
    public partial class MatrisOluştur : Form
    {
        int sat, sut;
        double[,] matris;
        double[,] transpoz;
        public MatrisOluştur(int satır,int sutun)
        {
            sat = satır;
            sut = sutun;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] parcalar;
            string k = " ";
            char[] ayrac = k.ToCharArray();
            matris = new double[sat, sut];
            parcalar = textBox1.Text.Split(ayrac);
          
            for (int i = 0; i < parcalar.Length; i++)
            {
                if (Convert.ToDouble(parcalar[i]) >= 10)
                {
                    MessageBox.Show("10dan küçük değer giriniz!");
                    ElleGiriş eg = new ElleGiriş();
                    this.Hide();
                }
            }
            
            dataGridView1.ColumnCount = sut;
            dataGridView1.RowCount = sat;
            int m = 0;
            for (int i = 0; i < sat; i++)
            {
                for (int j = 0; j < sut; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = parcalar[m];
                    matris[i, j] =Convert.ToDouble(parcalar[m]);
                    m++;
                }
            }

            dataGridView2.ColumnCount = sat;
            dataGridView2.RowCount = sut;
            transpoz = new double[sut, sat];
            for (int i = 0; i < sat; i++)
            {
                for (int j = 0; j < sut; j++)
                {
                    transpoz[j, i] = matris[i, j];
                //    MessageBox.Show(" " + transpoz[j, i]);
                }
            }
            for (int i = 0; i < sut; i++)
            {
                for (int j = 0; j < sat; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = transpoz[i, j];
                }
            }

                textBox3.Text = "0";
                textBox4.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MatrisÇarpımı mç = new MatrisÇarpımı(matris,transpoz);
            mç.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void MatrisOluştur_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/matris.png");
            pictureBox2.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/transpoz.png");

        }
        private void MatrisOluştur_Load2(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/matris.png");
            pictureBox2.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/transpoz.png");

        }
    }
}
