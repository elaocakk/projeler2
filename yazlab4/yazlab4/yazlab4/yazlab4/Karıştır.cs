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
    public partial class Karıştır : Form
    {
        String resimKonum;
        int[] a = new int[20];
        public Karıştır(String rk)
        {
            resimKonum = rk;
            InitializeComponent();
        }

        private void Karıştır_Load(object sender, EventArgs e)
        {
            Image resim = Image.FromFile(resimKonum);

            int kare = resim.Height / 4;
            int kare1 = resim.Width / 4;
            int dikeyParca = resim.Height / kare;
            int yatayParca = resim.Width / kare1;
            Rectangle cropAlani = new Rectangle(0, 0, kare1, kare);
            Directory.CreateDirectory(@"C:\Users\st\Desktop\wall");
            int say=0;
            for (int dik = 0; dik < dikeyParca; dik++)
            {
                for (int y = 0; y < yatayParca; y++)
                {
                    cropAlani.Y = dik * kare;
                    cropAlani.X = y * kare1;
                    Image parcaResim = Crop(resim, cropAlani);

                       parcaResim.Save(@"C:\Users\st\Desktop\wall"+say+".jpg", ImageFormat.Jpeg);
                    say++;
                }
            }
            var sayilar = Enumerable.Range(0, 15).OrderBy(x => Guid.NewGuid());
            int sayac = 0;
            foreach(int ea in sayilar)
            {
               // MessageBox.Show(ea + " ");
                a[sayac] = ea;
                sayac++;
            }
/*
            pictureBox1.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[0] + ".jpg");
            pictureBox2.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[1] + ".jpg");
            pictureBox3.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[2] + ".jpg");
            pictureBox4.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[3] + ".jpg");
            pictureBox5.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[4] + ".jpg");
            pictureBox6.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[5] + ".jpg");
            pictureBox7.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[6] + ".jpg");
            pictureBox8.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[7] + ".jpg");
            pictureBox9.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[8] + ".jpg");
            pictureBox10.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[9] + ".jpg");
            pictureBox11.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[10] + ".jpg");
            pictureBox12.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[11] + ".jpg");
            pictureBox13.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[12] + ".jpg");
            pictureBox14.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[13] + ".jpg");
            pictureBox15.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[14] + ".jpg");
            pictureBox16.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[15] + ".jpg");
            */

            if (a[0] == 0 && a[1] == 1 && a[2] == 2 && a[3] == 3 && a[4] == 4 && a[5] == 5 && a[6] == 6 && a[7] == 7 && a[8] == 8 && a[9] == 9 && a[10] == 10 &&
       a[11] == 11 && a[12] == 12 && a[13] == 13 && a[14] == 14 && a[15] == 15)
            {
                MessageBox.Show("100 puan");
            }
            else if (a[0] == 0 || a[1] == 1 || a[2] == 2 || a[3] == 3 || a[4] == 4 || a[5] == 5 || a[6] == 6 || a[7] == 7 || a[8] == 8 || a[9] == 9 || a[10] == 10 ||
                 a[11] == 11 || a[12] == 12 || a[13] == 13 || a[14] == 14 || a[15] == 15)
            {
                MessageBox.Show("en az biri doğru");
            }
        }
     

        private void button1_Click(object sender, EventArgs e)
        {

            //   MessageBox.Show( a[0] + " " + a[1] + " " + a[2] + " " + a[3] + " " + a[4] + " " + a[5] + " " + a[6] + " " + a[7] + " " + a[8] + " " + a[9] + " " + a[10] + " " + a[11] + " " + a[12]+
            //       " " + a[13] + " " + a[14] + " " + a[15] + " ");

                 var sayilar = Enumerable.Range(0, 15).OrderBy(x => Guid.NewGuid());
                 int sayac = 0;
                 foreach (int ea in sayilar)
                 {
                     // MessageBox.Show(ea + " ");
                     a[sayac] = ea;
                     sayac++;
                 }
                 
            //for (int b=0; b<16; b++) { a[b] = b; }                  //   100 puan olsun diye
        /*    pictureBox1.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[0] + ".jpg");
            pictureBox2.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[1] + ".jpg");
            pictureBox3.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[2] + ".jpg");
            pictureBox4.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[3] + ".jpg");
            pictureBox5.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[4] + ".jpg");
            pictureBox6.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[5] + ".jpg");
            pictureBox7.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[6] + ".jpg");
            pictureBox8.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[7] + ".jpg");
            pictureBox9.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[8] + ".jpg");
            pictureBox10.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[9] + ".jpg");
            pictureBox11.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[10] + ".jpg");
            pictureBox12.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[11] + ".jpg");
            pictureBox13.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[12] + ".jpg");
            pictureBox14.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[13] + ".jpg");
            pictureBox15.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[14] + ".jpg");
            pictureBox16.Image = Image.FromFile("C:/Users/st/Desktop/wall/" + a[15] + ".jpg");

         */
            if (a[0] == 0 || a[1] == 1 || a[2] == 2 || a[3] == 3 || a[4] == 4 || a[5] == 5 || a[6] == 6 || a[7] == 7 || a[8] == 8 || a[9] == 9 || a[10] == 10 ||
           a[11] == 11 || a[12] == 12 || a[13] == 13 || a[14] == 14 || a[15] == 15)
            {
                MessageBox.Show("en az biri doğru");
            }
        }











        private static Image Crop(Image image, Rectangle rect)
        {
            Bitmap resim = new Bitmap(image);
            Bitmap parcaResim = resim.Clone(rect, resim.PixelFormat);

            return (Image)(parcaResim);
        }
    }
}
