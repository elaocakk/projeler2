using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlab4
{
    public partial class Form1 : Form
    {
        string resimKonum;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Resim dosyası";
       //    theDialog.Filter = "Jpeg dosya|*.jpg";
            

         
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = theDialog.FileName.ToString();
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resimKonum = textBox1.Text;            
            
            Karıştır k = new Karıştır(resimKonum);
            k.Show();
        }
    }
}
