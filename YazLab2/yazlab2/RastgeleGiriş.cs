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
    public partial class RastgeleGiriş : Form
    {
        double[,] matris;
        double[,] transpoz;
        public RastgeleGiriş()
        {
            InitializeComponent();
        }

        private void RastgeleGiriş_Load(object sender, EventArgs e)
        {
          
          //  int adet = 0;
            double rastsayi=0.0;
            Random rastgele = new Random();
         
          int satir = rastgele.Next(1,6);        
          int sutun = rastgele.Next(1,6);
             textBox3.Text = ""+satir;
             textBox4.Text = ""+sutun;
            while (satir == sutun)
            {
                sutun= rastgele.Next(1, 6); 
            }
         //   MessageBox.Show(satir + " " + sutun);

            matris = new double[satir, sutun];
            transpoz = new double[sutun, satir];
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j <sutun; j++)
                {
                    rastsayi = 1+rastgele.NextDouble()*9;
                    rastsayi = Math.Round(rastsayi, 1);
                    matris[i, j] = rastsayi;
                    transpoz[j, i] = matris[i, j];
                }              
            }
            dataGridView1.ColumnCount = sutun;
            dataGridView1.RowCount = satir;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matris[i, j];
                }
            }
            dataGridView2.ColumnCount = satir;
            dataGridView2.RowCount = sutun;
            for (int i = 0; i < sutun; i++)
            {
                for (int j = 0; j < satir; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = transpoz[i, j];
                }

            }
            textBox1.Text = "0";
            textBox2.Text = "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MatrisÇarpımı mç = new MatrisÇarpımı(matris, transpoz);
            mç.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
