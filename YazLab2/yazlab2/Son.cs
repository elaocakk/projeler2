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
    public partial class Son : Form
    {
        double[,] matrix;
        double[,] transpose;
        double[,] sonuç;
        string durum;
        int toplam, carpım;
        public Son(double[,] m, double [,] t, string d, int a, int b)
        {
            matrix = m;
            transpose = t;
            durum = d;
            toplam = a;
            carpım = b;
            InitializeComponent();
        }

        private void Son_Load(object sender, EventArgs e)
        {

            if (durum == "matris")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/buyuk.png");
                sonuç = new double[matrix.GetLength(0), transpose.GetLength(1)];
                double topla;

                // matris*tranpoz
                for (int i = 0; i < matrix.GetLength(0); i++) 
                {
                    for (int j = 0; j < transpose.GetLength(1); j++)
                    {
                        topla = 0;
                        for (int k = 0; k < transpose.GetLength(0); k++)
                        {
                            topla = topla + matrix[i, k] * transpose[k, j];
                            toplam++;
                            carpım++;
                            sonuç[i, j] = topla;
                        }
                    }

                }
                dataGridView1.ColumnCount = sonuç.GetLength(1);
                dataGridView1.RowCount = sonuç.GetLength(0);

                for (int i = 0; i < sonuç.GetLength(0); i++)
                {
                    for (int j = 0; j < sonuç.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sonuç[i, j];
                    }

                }



            }
            else if (durum == "transpoz")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/kucuk.png");
                sonuç = new double[transpose.GetLength(0), matrix.GetLength(1)];
                double topla;

                //transpoz*matris
                for (int i = 0; i < transpose.GetLength(0); i++) // matrisin satır sayısı 
                {
                    for (int j = 0; j < matrix.GetLength(1); j++) // matrisin satır sayısı
                    {
                        topla = 0;
                        for (int k = 0; k < matrix.GetLength(0); k++) // transpozun satır sayısı
                        {
                            topla = topla +transpose[i, k] * matrix[k, j];
                            toplam++;
                            carpım++;
                            sonuç[i, j] = topla;
                        }
                    }

                }
                dataGridView1.ColumnCount = sonuç.GetLength(1);
                dataGridView1.RowCount = sonuç.GetLength(0);

                for (int i = 0; i < sonuç.GetLength(0); i++)
                {
                    for (int j = 0; j < sonuç.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sonuç[i, j];
                    }

                }

            }
            textBox1.Text = "" + toplam;
            textBox2.Text = "" + carpım;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
