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
    public partial class EkMatris : Form
    {
        double[,] matrix;
        double[,] cofmatrix;
        double[,] adjmatrix;
        double[,] transpose;
        double[,] cof;
        double determinant;
        string durum;
        int toplam, carpım;
        public EkMatris(double [,] mat,double[,] transpoz,double d,string du, int t, int c)
        {
            matrix = mat;
            transpose = transpoz;
            determinant=d ;
            durum = du;
            toplam = t;
            carpım = c;
            InitializeComponent();
        }

        private void EkMatris_Load(object sender, EventArgs e)
        {
            int boyut = matrix.GetLength(0);
            cofmatrix = new double[boyut, boyut];
            adjmatrix = new double[boyut, boyut];
            dataGridView1.RowCount = boyut;
            dataGridView1.ColumnCount = boyut;
            dataGridView2.RowCount = boyut;
            dataGridView2.ColumnCount = boyut;

     if (boyut == 1)
            {
                //  cofmatrix[0, 0] = matrix[0, 0];
                cofmatrix[0, 0] = 1;
                // adjmatrix[0, 0] = matrix[0, 0];
                adjmatrix[0, 0] = 1;
                dataGridView1.Rows[0].Cells[0].Value = cofmatrix[0, 0];
                dataGridView2.Rows[0].Cells[0].Value = adjmatrix[0, 0];
            }

     else if (boyut == 2)
            {
                cofmatrix[0, 0] = matrix[1, 1];
                cofmatrix[0, 1] = (-1)*matrix[1, 0]; carpım++;
                cofmatrix[1, 0] = (-1)*matrix[0, 1]; carpım++;
                cofmatrix[1, 1] = matrix[0, 0];
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = cofmatrix[i, j];
                    }
                }
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        adjmatrix[i, j] = cofmatrix[j, i];
                        dataGridView2.Rows[i].Cells[j].Value = adjmatrix[i, j];
                    }
                }
            }

     else if (boyut == 3)
            {
                int sign = 1;
                cof=new double[boyut,boyut]; 
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        Kofaktör(matrix, cof, i, j);
                        
                        if ((i + j) % 2 == 0)   { sign = 1; }
                        else sign = -1;
                        cofmatrix[i,j] = (sign) * (cof[0,0]*cof[1,1]-cof[0,1]*cof[1,0]);
                        carpım += 3;
                        toplam++;
                        dataGridView1.Rows[i].Cells[j].Value = cofmatrix[i, j];
                        adjmatrix[j, i] = cofmatrix[i, j];
                    }
                }
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {    
                        dataGridView2.Rows[i].Cells[j].Value = adjmatrix[i, j];
                    }
                }
            }

  else if (boyut == 4 || boyut== 5)
            {
                int sign = 1;
                cof = new double[boyut-1, boyut-1];
                double det ;
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        Kofaktör(matrix, cof, i, j);

                        if ((i + j) % 2 == 0) { sign = 1; }
                        else                  { sign = -1;}
                        det = DetHesap(cof);
                        cofmatrix[i, j] = (sign) * det;
                        carpım++;
                        dataGridView1.Rows[i].Cells[j].Value = cofmatrix[i, j];
                        adjmatrix[j, i] = cofmatrix[i, j];
                    }
                }
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = adjmatrix[i, j];
                    }
                }
            }
            textBox1.Text = "" + toplam;
            textBox2.Text = "" + carpım;

        }
      
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
                carpım += 2;
                toplam++;
            }
            return top;
        }

        void Kofaktör(double[,]matris, double[,]cof, int p, int q)
        {
            int i = 0, j = 0;
            int n = matris.GetLength(0);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)
                    {
                        cof[i,j++] = matris[row,col];

                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatrisTersi mt = new MatrisTersi(adjmatrix, matrix, transpose, determinant,durum,toplam,carpım);
            mt.Show();
        }
    }
}
