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
    public partial class MatrisÇarpımı : Form
    {
        double[,] matris;
        double[,] transpoz;
        double[,] carpimMatrisi;
        double det;
        string durum;
        int toplam=0, carpım=0;
        public MatrisÇarpımı(double[,] d1, double[,] d2)
        {
            InitializeComponent();
            matris = d1;
            transpoz = d2;
        }

        private void MatrisÇarpımı_Load(object sender, EventArgs e)
        {
            double topla = 0;
            int row = matris.GetLength(0);
            int col = matris.GetLength(1);

            if (row > col)
            {
                durum = "matris";
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/buyuk2.png");
                carpimMatrisi = new double[transpoz.GetLength(0), matris.GetLength(1)];

                for (int i = 0; i < transpoz.GetLength(0); i++) // matrisin satır sayısı 
                {
                    for (int j = 0; j < matris.GetLength(1); j++) // matrisin satır sayısı
                    {
                        topla = 0;
                        for (int k = 0; k < matris.GetLength(0); k++) // transpozun satır sayısı
                        {
                            topla = topla + transpoz[i, k] * matris[k, j];
                            carpimMatrisi[i, j] = topla;
                            toplam++;
                            carpım++;
                        }
                    }
                }
                dataGridView1.ColumnCount = carpimMatrisi.GetLength(1);
                dataGridView1.RowCount = carpimMatrisi.GetLength(0);

                for (int i = 0; i < carpimMatrisi.GetLength(0); i++)
                {
                    for (int j = 0; j < carpimMatrisi.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = carpimMatrisi[i, j];
                    }
                }
         
    }

else if (row < col)
            {
                durum = "transpoz";
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/kucuk2.png");
                carpimMatrisi = new double[matris.GetLength(0), transpoz.GetLength(1)];

                for (int i = 0; i < matris.GetLength(0); i++) // matrisin satır sayısı 
                {
                    for (int j = 0; j < transpoz.GetLength(1); j++) // matrisin satır sayısı
                    {
                        topla = 0;
                        for (int k = 0; k < transpoz.GetLength(0); k++) // transpozun satır sayısı
                        {
                            topla = topla + matris[i, k] * transpoz[k, j];
                            carpimMatrisi[i, j] = topla;
                            toplam++;
                            carpım++;
                        }
                        
                    }
                   
                }
                dataGridView1.ColumnCount = carpimMatrisi.GetLength(1);
                dataGridView1.RowCount = carpimMatrisi.GetLength(0);

                for (int i = 0; i < carpimMatrisi.GetLength(0); i++)
                {
                    for (int j = 0; j < carpimMatrisi.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = carpimMatrisi[i, j];
                    }
                }

            }
            textBox3.Text = "" + toplam;
            textBox4.Text = "" + carpım;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EkMatris em = new EkMatris(carpimMatrisi,transpoz,det,durum,toplam,carpım);
            em.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            det = DetHesap(carpimMatrisi);
            textBox1.Text = Convert.ToString(det);
        
            if (det == 0)
            {
                MessageBox.Show("Matrisin Tersi Bulunamaz! (Determinant=0)");
            }
            textBox3.Text = "" + toplam;
            textBox4.Text = "" + carpım;
        }

     
    /*    public void carpimtoplam(int boyut)
        {
            if (boyut == 2)
            {
                carpım = carpım + 2;
                toplam = toplam + 1;
            }
            else if (boyut == 3)
            {
                carpım = carpım + 12;
                toplam = toplam + 3;
            }
            else if (boyut == 4)
            {
                carpım = carpım + 48;
                toplam = toplam + 12;
            }
        }*/
        public double DetHesap(double[,] matris)
        {
            int boyut = matris.GetLength(0);
            int üs = 1;
            double top = 0;
            if (boyut == 1)
                return matris[0, 0];
            for (int i = 0; i < boyut; i++)
            {
                double[,] altMatris = new double[boyut - 1, boyut - 1];
                for (int j = 1; j < boyut; j++)
                {
                    for (int k = 0; k < boyut; k++)
                    {
                        if (k < i)
                        { altMatris[j - 1, k] = matris[j, k]; }
                        else if (k > i)
                        { altMatris[j - 1, k - 1] = matris[j, k]; }
                    }
                }
                if (i % 2 == 0)
                { üs = 1; }
                else
                { üs = -1; }
                top += üs * matris[0, i] * (DetHesap(altMatris));
               toplam++;
               carpım+=2;
            }
           
            return top;
        }
     
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
