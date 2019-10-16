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
    public partial class MatrisTersi : Form
    {
        double[,] adjmatrix;
        double[,] matrix;
        double[,] mat;
        double[,] transpose;
        double determinant;
        string durum;
        int toplam, carpım;
        public MatrisTersi(double [,] adj, double [,] m,double [,] t, double d,string du, int a, int b)
        {
            adjmatrix = adj;
            mat = m;
            determinant = d;
            transpose = t;
            durum = du;
            toplam = a;
            carpım = b;
            InitializeComponent();
        }

        private void MatrisTersi_Load(object sender, EventArgs e)
        {
            int row = adjmatrix.GetLength(0);
            int col = adjmatrix.GetLength(1);
            if (durum == "matris")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/buyuk1.png");
            }
            else if (durum == "transpoz")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Asus/Desktop/yazlab2/kucuk1.png");
            }
            matrix = new double[row, col];
            dataGridView1.RowCount = row;
            dataGridView1.ColumnCount = col;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <col; j++)
                {
                    matrix[i, j] = (1 / determinant) * adjmatrix[i, j];
                    carpım+=2;
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            textBox1.Text = "" + toplam;
            textBox2.Text = "" + carpım;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Son s = new Son(matrix, transpose, durum,toplam,carpım);
            s.Show();
        }
    }
}
